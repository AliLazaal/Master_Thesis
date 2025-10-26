using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Evaluation_Tool_for_ENNA_.Enums;
using Evaluation_Tool_for_ENNA_.Helper;

namespace Evaluation_Tool_for_ENNA_
{
    public class Test_Case_Properties
    {

        string caseNo;
        string testResult = string.Empty;
        string reqID;
        string caseName;
        string ECUNO = string.Empty;

        string lineWithoutExtraInfoString = string.Empty;
        string shortLog = string.Empty;
        string singleCompleteShortLog;

        string diagTraceIssue = string.Empty;

        // REGEXP Patterns

        public static string regexPattrenTestAttr = @"Report message: <-- (?<TestID>.+?(?= )) \[(?<ReqID>Dia_Cod_\d{1,}|KSD-Anf_\d{1,}|Dia_Err_\d{1,}|Dia_Rou_\d{1,}|Dia_Mes_\d{1,}|Dia_Ident_\d{1,}|Dia_Anp_\d{1,}|Dia_Ds_\d{1,})\] (?<TestName>.+?(?= )) -->";
        public static string regexPattrenforTestResults = @"Report message: (?<TestResult>(?i)Test Passed|Test Failed):(?<TestCaseNo>.+?(?= )) \[(?<ReqID>Dia_Cod_\d{1,}|KSD-Anf_\d{1,}|Dia_Err_\d{1,}|Dia_Rou_\d{1,}|Dia_Mes_\d{1,}|Dia_Ident_\d{1,}|Dia_Anp_\d{1,}|Dia_Ds_\d{1,})\] (?<TestName>.+?(?=\|))\| Valuation:(?<Valuation> PASS| FAIL)";
        public static string TimeOverheadPattern = @"(?<Date>\d{4}-\d{2}-\d{2}) \| (?<Time>\d{2}:\d{2}:\d{2}.\d{3}) \| ((?i)Serial|Reporting|MainProcess|Utilities) \| (MainThread|Worker_\d{0,}|Thread-\d{0,}) \| (INFO|DEBUG|WARNING|ERROR) \| ([a-zA-Z0-9_.]+:\d{1,}) \| (?<Message>.*)";
        public static string ECUNo = @"(?<ECUNo>ECU \d{1}x\d{0,}[a-zA-Z0-9]+)";
        public static string UnnecessaryLinesPattren = @"(?<UnnecessaryData>(?i)default \| Connect to ECU \d{1,}x\d{1,}[a-zA-Z0-9]+|(?i)default \| Disconnect from ECU \d{1,}x\d{1,}[a-zA-Z0-9]+|(?i)default \| send raw service to ECU \d{1,}x\d{1,}[a-zA-Z0-9]+|default \| Successfully disconnected from ECU|(?i)Precondition passed|(?i)starting action|(?i)starting precondition|(?i)postcondition passed|(?i)no precondition set|(?i)Reporting end of|(?i)SwitchOffClamp30|(?i)Reporting PASS status|(?i)No postcondition set|(?i)SwitchOnClamp30|(?i)ResetClamp30|(?i)Starting postcondition|(?i)SwitchOnClamp15|(?i)Set clamp 15 ON|(?i)DiagResetCL30)";
        public static string Clamp30ResetNotifyPattren = @"(DiagResetCL30pSwitch \| Action passed)";
        public static string issuePattern = @"(Valuation: FAIL)";
        public static string issueInLogPattern = @"Report message: (?<ResultLine>Test Failed: .* \| Valuation: FAIL)|Report message: (?<Issue>.*\| Valuation: FAIL)";
        public static string newLine = @"\n";
        public static string requestRegexPattren = @"send raw: (?<Request>[a-zA-Z0-9\s]+)";
        public static string responseRegexPattren = @"response: (?<Response>[a-zA-Z0-9\s]+)";
        public static string evaluationRegexPattren = @"(?s:.*\s)Report message: (?<Evaluation>.*) \| Valuation: FAIL";
        public static string sparePartNumberPattern = @"Report message: VW Spar Part Number: (?<SparePartNo>([A-Z0-9]{3})([0-9]{6})([ A-Z]{2}))";
        public static string hardwareNumberPattern = @"Report message: VW ECU Hardware Number: (?<HardwardNo>([A-Z0-9]{3})([0-9]{6})([ A-Z]{2}))";
        public static string softwareNumberPattern = @"Report message: VW ECU Software Version: (?<SoftwareNo>([A-Z0-9]{1})([0-9]{3}))";
        public static string ECUHardwareNumberPattern = @"Report message: VW ECU Hardware Version: (?<ECUHardwareNo>([HXYZ0-9]{1})([0-9]{2}))";
        public static string systemNameEngineTypePattern = @"Report message: Vw System Name or Engine Type: (?<EngineType>.*) \| Valuation: (PASS|FAIL)";
        

        private string completeTestCase = string.Empty;

        public string GetShortLog()

        {
            return completeTestCase;

        }

        public string GetCollectionofIssues()
        {
            return diagTraceIssue;
        }


        /// <summary>
        /// This method processes each test case line by line using RegExp patterns to match and save test attributes for each test case.
        /// </summary>
        /// <param name="test"></param>
        /// <param name="singleTestcase"></param>
        /// <param name="hardwareDetails"></param>
        /// <returns></returns>
        public string TestCaseProperties(string test, SingleTestCase singleTestcase, out HardwareDetails hardwareDetails)

        {
            hardwareDetails = new HardwareDetails();
            
            Match match = Regex.Match(test, newLine);
            string strAttr = string.Empty;

         
            if (match.Success)
            {
                string[] EachLine = Regex.Split(test, newLine);

                for (int ctr = 0; ctr < EachLine.Length; ctr++)
                {
                    object ShortTestCaseObject = EachLine.GetValue(ctr);
                    string SingleLineString = Convert.ToString(ShortTestCaseObject);


                    Regex regex2 = new Regex(TimeOverheadPattern);
                    Match match2 = regex2.Match(SingleLineString);

                    if (match2.Success) // Deleting unnecessary data from each entry in log file
                    {

                        lineWithoutExtraInfoString = match2.Groups["Message"].Value;

                        // ECU# used in the respective test case 
                        Regex regex3 = new Regex(ECUNo);
                        Match match3 = regex3.Match(lineWithoutExtraInfoString);

                        if (match3.Success) // Checking ECU Nnamespace Evaluation_Tool_for_ENNA_namespace
                        {
                            ECUNO = match3.Groups["ECUNo"].Value;
                            
                        }
                        // Assigning Test Attributes for each Test Case

                        Regex regex5 = new Regex(regexPattrenTestAttr);
                        Match match5 = regex5.Match(lineWithoutExtraInfoString);


                        if (match5.Success)
                        {

                            strAttr += "\n===========TEST ATTRIBUTES===========\n";
                            strAttr += "Test ID: ";
                            strAttr += match5.Groups["TestID"].Value;
                            strAttr += "\n";
                            caseNo = match5.Groups["TestID"].Value;

                            strAttr += "ReqID: ";
                            strAttr += match5.Groups["ReqID"].Value;
                            strAttr += "\n";
                            reqID = match5.Groups["ReqID"].Value;

                            strAttr += "TestName: ";
                            strAttr += match5.Groups["TestName"].Value;
                            strAttr += "\n";
                            caseName = match5.Groups["TestName"].Value;
                           


                        }

                        // Making Short Logs with only relevant info for daignosis
                        Regex regex4 = new Regex(UnnecessaryLinesPattren);
                        Match match4 = regex4.Match(lineWithoutExtraInfoString);

                        Regex regex6 = new Regex(Clamp30ResetNotifyPattren);
                        Match match6 = regex6.Match(lineWithoutExtraInfoString);

                        if (!match4.Success | match6.Success)
                        {

                            shortLog = lineWithoutExtraInfoString;

                            // List of strings of short logs which will passed on to SingleTestCase Class

                            //singleCompleteShortLog += "\n";
                            singleCompleteShortLog += shortLog;
                            singleCompleteShortLog += "\n";


                            completeTestCase += shortLog;
                            completeTestCase += "\n";


                        }

                        Regex regex7 = new Regex(regexPattrenforTestResults);
                        Match match7 = regex7.Match(lineWithoutExtraInfoString);
                        if (match7.Success)
                        {
                            strAttr += "ECU_No:";
                            strAttr += ECUNO;
                            strAttr += "\n";
                            strAttr += "TestCaseResult: ";
                            strAttr += match7.Groups["TestResult"].Value;
                            strAttr += "\n";
                            strAttr += "======================================\n";

                            testResult = match7.Groups["TestResult"].Value;

                        }

                        Match sparePartNoMatch = Regex.Match(lineWithoutExtraInfoString, sparePartNumberPattern);
                        Match hardwareNoMatch = Regex.Match(lineWithoutExtraInfoString, hardwareNumberPattern);
                        Match softwareNoMatch = Regex.Match(lineWithoutExtraInfoString, softwareNumberPattern);
                        Match ECUHardwareNoMatch = Regex.Match(lineWithoutExtraInfoString, ECUHardwareNumberPattern);
                        Match engineNoMatch = Regex.Match(lineWithoutExtraInfoString, systemNameEngineTypePattern);

                        if (sparePartNoMatch.Success)
                        {
                            hardwareDetails.SparePartNo = sparePartNoMatch.Groups["SparePartNo"].Value;
                        }
                        if (hardwareNoMatch.Success)
                        {
                            hardwareDetails.HardwarePartNo = hardwareNoMatch.Groups["HardwardNo"].Value;
                        }
                        if (softwareNoMatch.Success)
                        {
                            hardwareDetails.SoftwareVersion = softwareNoMatch.Groups["SoftwareNo"].Value;
                        }
                        if (ECUHardwareNoMatch.Success)
                        {
                            hardwareDetails.ECUHardwareNo = ECUHardwareNoMatch.Groups["ECUHardwareNo"].Value;
                        }
                        if (engineNoMatch.Success)
                        {
                            hardwareDetails.EngineNo = engineNoMatch.Groups["EngineType"].Value;
                        }

                    }

                }

                
                completeTestCase = completeTestCase.Insert(0, strAttr);

            }

            // passing parameter through a function as reference 
            // setting attributes for all single  test case 

            singleTestcase.CaseName = caseName;
            singleTestcase.TCId = caseNo;
            singleTestcase.ReqId = reqID;
            singleTestcase.CaseRes = testResult;
            singleTestcase.ECUNo = ECUNO;
            singleTestcase.ShortLog = singleCompleteShortLog;
            singleTestcase.Result = EnumHelpers.ParseTestcaseResults(testResult);

            if (reqID != null)
            {
                singleTestcase.Function = EnumHelpers.IssueFunction(reqID);
            }
            else { singleTestcase.Function = Function.Unkown; }

            return completeTestCase;

        }


    }

}
