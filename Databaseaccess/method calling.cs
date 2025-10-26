

using System;

namespace Testing_final
{
    public partial class DatabaseMethods
    {

        public class Testnames
        {
            public string Testname { get; set; }
            public DateTimeOffset? timeimport { get; set; }
            public Testnames(string name, DateTimeOffset? time)
            {
                Testname = name;
                timeimport = time;
            }

        }
        public class Occurances
        {
            public string Testname { get; set; }
            public TestStatus Status { get; set; }
            public string Clusterno { get; set; }
            public string DiagTrace { get; set; }
            public string HardwareNo { get; set; }
            public string HardwareVersionNo { get; set; }
            public string SoftwareVersionNo { get; set; }
            public string ECUNo { get; set; }
            public string SystemType { get; set; }
            public string Comment { get; set; }
            
            public Occurances(string testname,string diagTrace , TestStatus Procstatus, string clustor, string hardwareNo, string hardwareVersion
                                ,string softwareVersion, string ecuNo, string systemType)
            {
                Status= Procstatus;
                Clusterno = clustor;
                Testname = testname;
                DiagTrace = diagTrace;
                HardwareNo = hardwareNo;
                HardwareVersionNo = hardwareVersion;
                SoftwareVersionNo = softwareVersion;
                ECUNo = ecuNo;
                SystemType = systemType;
            }

        }

        public class Occurances1
        {
            public string Testname { get; set; }
            public string Result { get; set; }
            public string CaseName { get; set; }
            public string ReqID { get; set; }
            public string TCID { get; set; }
            public string ECUNo { get; set; }
            //public string Evaluation{ get; set; }
            public Occurances1(string testname, string testcaseresult, string testCaseName, string reqID, string TCId, string ECU)
            {
                Result = testcaseresult;
                CaseName = testCaseName;
                Testname = testname;
                ReqID = reqID;
                TCID = TCId;
                ECUNo = ECU;

            }

        }
    }
}
