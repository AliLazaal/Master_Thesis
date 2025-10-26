using Evaluation_Tool_for_ENNA_.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;





public class SingleTestCase
{
    
    public SingleTestCase()
    {
        TCId = string.Empty;
        Result = TestcaseResults.Open;
        CaseRes = string.Empty;
        ReqId = string.Empty;
        CaseName = string.Empty;
        ECUNo = string.Empty;
        ShortLog = string.Empty;
        Function = Function.Unkown;

    }


    // strCaseID 

    public string TCId { set; get; }
    public string ReqId { set; get; }
    public string CaseName { set; get; }
    public string ECUNo { set; get; }
    public string ShortLog { set; get; }
    public TestcaseResults Result { set; get; }
    public string CaseRes { set; get; }
    public Function Function { set; get; }
    public string SparePartNo { set; get; }
    public string HardwarePartNo { set; get; }
    public string SoftwareVersion { set; get; }
    public string ECUHardwareNo { set; get; }
    public string EngineNo { set; get; }



}
public struct HardwareDetails
{
    public string SparePartNo;
    public string HardwarePartNo;
    public string SoftwareVersion;
    public string ECUHardwareNo;
    public string EngineNo;

    
}

