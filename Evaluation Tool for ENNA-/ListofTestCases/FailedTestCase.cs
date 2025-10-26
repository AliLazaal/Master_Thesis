using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Evaluation_Tool_for_ENNA_.Enums;
using Evaluation_Tool_for_ENNA_.Helper;
using Evaluation_Tool_for_ENNA_;


public class FailedTestCase
{
    private const string failedPattern = @"Report message: (?<Evaluation>.*) \| Valuation: FAIL";
    private const string sessionChangePattern = @"send raw: 10 (?<session>[%dA-Fa-f][2])";

    public FailedTestCase()
    {
        CaseName = string.Empty;
        Function = Function.Unkown;
        TcId = string.Empty;
        ReqId = string.Empty;
        ECUNo = string.Empty;
        DiagTrace = string.Empty;
        ProcStatus = Testing_final.TestStatus.New;
        NRC = string.Empty;
        Request = string.Empty;
        Response = string.Empty;
        Comment = string.Empty;
        lastEditor = string.Empty;
        Ticket = string.Empty;
        Session = Sessions.Unknown;
        Evaluation = string.Empty;
        FailureType = string.Empty;

    }

    public FailedTestCase(FailedTestCase objFailedTestCase)
    {
        ProcStatus = objFailedTestCase.ProcStatus;
        CaseName = objFailedTestCase.CaseName;
        Function = objFailedTestCase.Function;
        TcId = objFailedTestCase.TcId;
        ReqId = objFailedTestCase.ReqId;
        ECUNo = objFailedTestCase.ECUNo;
        DiagTrace = objFailedTestCase.DiagTrace;
        Response = objFailedTestCase.Response;
        Request = objFailedTestCase.Request;
        Evaluation = objFailedTestCase.Evaluation;

        lastEdited = new DateTimeOffset(DateTime.Now);

    }

    public static List <FailedTestCase> CreateIssues (List<SingleTestCase> testCases)
    {
        List<FailedTestCase> failedTestCases = new List<FailedTestCase>();

        foreach (SingleTestCase tc in testCases.Where(c => c.Result == TestcaseResults.Failed ))
        {
            List<FailedTestCase> issuesInCurrent = new List<FailedTestCase>();
            MatchCollection failedLineMatches = Regex.Matches(tc.ShortLog, failedPattern, RegexOptions.Multiline);

            foreach (Match failedLineMatch in failedLineMatches)
            {
                if (Regex.IsMatch(failedLineMatch.Value, Test_Case_Properties.regexPattrenforTestResults))
                    continue;

                string evaluation = failedLineMatch.Groups["Evaluation"].Value;
                string request = Regex.Match(tc.ShortLog.Substring(0, failedLineMatch.Index), Test_Case_Properties.requestRegexPattren, RegexOptions.RightToLeft).Groups["Request"].Value;
                string response = Regex.Match(tc.ShortLog.Substring(0, failedLineMatch.Index), Test_Case_Properties.responseRegexPattren, RegexOptions.RightToLeft).Groups["Response"].Value;
                string sessiontext = Regex.Match(tc.ShortLog.Substring(0, failedLineMatch.Index), sessionChangePattern, RegexOptions.RightToLeft).Groups["session"].Value;

                if (CanFindSimilarIssue(issuesInCurrent, evaluation, request, response, out FailedTestCase exisitingIssue))
                {
                    //This isssue was already detected, so we only overwrite the attributes
                    exisitingIssue.DiagTrace = tc.ShortLog.Substring(0, failedLineMatch.Index + failedLineMatch.Length);
                    exisitingIssue.Request = request;
                    exisitingIssue.Response = response;
                    exisitingIssue.Evaluation = evaluation;
                    exisitingIssue.Session |= EnumHelpers.ParseSessionFromHexString(sessiontext);
                }
                else
                {
                    //There is no issue like this one yet => create a new one
                    FailedTestCase issue = new FailedTestCase()
                    {
                        CaseName = tc.CaseName,
                        Function = EnumHelpers.IssueFunction(tc.ReqId),
                        TcId = tc.TCId,
                        ReqId = tc.ReqId,
                        ECUNo = tc.ECUNo,
                        DiagTrace = tc.ShortLog.Substring(0, failedLineMatch.Index + failedLineMatch.Length),
                        Request = request,
                        Response = response,
                        Evaluation = evaluation,
                        Session = EnumHelpers.ParseSessionFromHexString(sessiontext)
                    };
                    issuesInCurrent.Add(issue);
                }
            }
            failedTestCases.AddRange(issuesInCurrent);
        }

        //// Add an Issue for each testcase with indecisive result for manual evaluation
        //foreach (SingleTestCase tc in testCases.Where(c => c.Result == TestcaseResults.Open))
        //{
        //    FailedTestCase issue = new FailedTestCase()
        //    {
        //        CaseName = tc.CaseName,
        //        //Function = EnumHelpers.IssueFunction(tc.ReqId),
        //        TcId = tc.TCId,
        //        ReqId = tc.ReqId,
        //        ECUNo = tc.ECUNo,
        //        DiagTrace = tc.ShortLog
        //    };
        //    failedTestCases.Add(issue);
        //}

        return failedTestCases;

    }

    private static bool CanFindSimilarIssue(IEnumerable<FailedTestCase> issues, string evaluation, string request, string response, out FailedTestCase similarIssue)
    {
        similarIssue = null;
        //requests are always parsed throug the regular expressions => no need to do any further input validation

        byte[] requestHex = ByteConversion.HexStringToBytes(request);
        byte[] responseHex = ByteConversion.HexStringToBytes(response);

        foreach (FailedTestCase issue in issues)
        {
            byte[] issueRequestHex = ByteConversion.HexStringToBytes(issue.Request);
            byte[] issueResponseHex = ByteConversion.HexStringToBytes(issue.Response);

            //The easiest case: everythings the same
            if (issue.Request.Equals(request) && issue.Response.Equals(response) && issue.Evaluation.Equals(evaluation))
                similarIssue = issue;

            else if (requestHex[0] == 0x19 && issueRequestHex[0] == 0x19
                && IsIssueMatchService19(issue, evaluation, requestHex, responseHex))
                similarIssue = issue;

            else if ((requestHex[0] == 0x22 || requestHex[0] == 0x2E) && (issueRequestHex[0] == 0x22 || issueRequestHex[0] == 0x2E)
                && IsIssueMatchService222E(issue, evaluation, requestHex, responseHex))
                similarIssue = issue;

            else if (requestHex[0] == 0x31 && issueRequestHex[0] == 0x31
                && IsIssueMatchService31(issue, evaluation, requestHex, responseHex))
                similarIssue = issue;
        }

        return similarIssue != null;
    }

    private static bool IsIssueMatchService222E(FailedTestCase issue, string evaluation, byte[] request, byte[] response)
    {
        byte[] issueRequestHex = ByteConversion.HexStringToBytes(issue.Request);
        byte[] issueResponseHex = ByteConversion.HexStringToBytes(issue.Response);
        // 2 issues may only be the same if the identifier is the same
        if (request.Length >= 3 && issueRequestHex.Length >= 3 && request[1] == issueRequestHex[1] && request[2] == issueRequestHex[2])
        {
            // group too short responses
            if (response.Length <= 2 && issueRequestHex.Length <= 2)
                return true;

            // negative reseponse with the same nrc will be grouped together
            if (response[0] == 0x7F && issueResponseHex[0] == 0x7F && response[2] == issueResponseHex[2])
                return true;

            if (evaluation.Equals(issue.Evaluation))
                return true;
        }

        return false;
    }

    private static bool IsIssueMatchService19(FailedTestCase issue, string evaluation, byte[] request, byte[] response)
    {
        byte[] issueRequestHex = ByteConversion.HexStringToBytes(issue.Request);
        byte[] issueResponseHex = ByteConversion.HexStringToBytes(issue.Response);
        // 2 issues may only be the same if the identifier is the same
        if (request.Length >= 6 && issueRequestHex.Length >= 6 && request[2] == issueRequestHex[2] && request[3] == issueRequestHex[3] && request[4] == issueRequestHex[4])
        {
            // group too short responses
            if (response.Length <= 2 && issueRequestHex.Length <= 2)
                return true;

            // negative reseponse with the same nrc will be grouped together
            if (response[0] == 0x7F && issueResponseHex[0] == 0x7F && response[2] == issueResponseHex[2])
                return true;

            if (evaluation.Equals(issue.Evaluation))
                return true;
        }

        return false;
    }

    private static bool IsIssueMatchService31(FailedTestCase issue, string evaluation, byte[] request, byte[] response)
    {
        byte[] issueRequestHex = ByteConversion.HexStringToBytes(issue.Request);
        byte[] issueResponseHex = ByteConversion.HexStringToBytes(issue.Response);
        // 2 issues may only be the same if the identifier is the same
        if (request.Length >= 4 && issueRequestHex.Length >= 4 && request[2] == issueRequestHex[2] && request[3] == issueRequestHex[3])
        {
            // group too short responses
            if (response.Length <= 2 && issueRequestHex.Length <= 2)
                return true;

            // negative reseponse with the same nrc will be grouped together
            if (response[0] == 0x7F && issueResponseHex[0] == 0x7F && response[2] == issueResponseHex[2])
                return true;

            if (evaluation.Equals(issue.Evaluation))
                return true;
        }
        return false;
    }


    public Testing_final.TestStatus ProcStatus { set; get; }
    public string NRC { set; get; }
    public string CaseName { set; get; }
    public Function Function { set; get; }
    public string TcId { set; get; }
    public string ReqId { set; get; }
    public string Request { set; get; }
    public string Response { set; get; }
    public string DiagTrace { set; get; }
    public string Comment { set; get; }
    public string lastEditor { set; get; }
    public DateTimeOffset? lastEdited { set; get; }
    public string Ticket { set; get; }
    public Sessions Session { set; get; }
    public string Evaluation { set; get; }
    public string FailureType { set; get; }
    public string ECUNo { set; get; }

}

