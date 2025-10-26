using Npgsql;
using LinqToDB.DataProvider.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using LinqToDB;
using LinqToDB.Mapping;
using System.Reflection;
using LinqToDB.Data;
using DataModels;



namespace Testing_final
{
    
    public partial class DatabaseMethods
    {
        // For Testing Data Base

        // connection is initialized for each queryy
        public static MuazzamDB Database { get { return databaseProvider.Value; } }
        private static Lazy<MuazzamDB> databaseProvider = new Lazy<MuazzamDB>(() =>
        {
#if DEBUG

            string connectionString = $"Server={"L-DEA-000010"};Port={"5432"};Database={"Muazzam"};User Id={"postgres"};Password={"1234"};";
#else
            string connectionString = $"Server={"L-DEA-000010"};Port={"5432"};Database={"Evaluationtool"};User Id={"postgres"};Password={"1234"};";
#endif
            var db = new MuazzamDB(new PostgreSQLDataProvider(), connectionString);
            return db;
        });

      
            public static void Main(string[] args)

        {

            string i = "Testname is empty";                         // sample test name to be passed for insert operation
            int id = 18;                                  // id of a specific failure row used for update of comment and status fileds
            string newcomment = "details not specified";  // coment filed to be updated for a specific failure, old comments must also be passed
            string j = "High_Japan_TPU_P3750";           // sample test name used to match and retrieve data from tabel
            string idtomatch = "Iden_76";               //  to retrieve matching occurances of same failure from past
            string auswertungtomatch = "P";             // to retrieve matching occurances of same failure from past
            TestStatus Newstate = TestStatus.InConsultation; // failure status filed to be updated for a specific failure


          
        }
        ///////////////////////////////////////////////////// Method to retreive data from failure table to display on first window ///////////////////////////////////////////////////////////

        public static IQueryable<Failure> GetFailures(string nameoftest)
        {

            var query =
                from c in Database.Failures
                where c.Testname == nameoftest
                select c;
            

       

            return query;
        }
        ///////////////////////////////////////////////////// Method to retreive filtered data from failure table based on status to display on first window ///////////////////////////////////////////////////////////

        public static IQueryable<Failure> FilterFailuresStatus(string nameoftest ,TestStatus state )
        {

            var failurequery =
                from c in Database.Failures
                where c.Testname == nameoftest
                & c.Procstatus == state
                orderby c.Uuid descending
                select c;
          



            return failurequery;
        }
        ///////////////////////////////////////////////////// Method to retreive filtered data from failure table based on name and status to display on first window ///////////////////////////////////////////////////////////

        public static IQueryable<Failure> FilterFailuresNameStatus( TestStatus state)
        {

            var statusbasedquery =
                from c in Database.Failures
                where c.Procstatus == state
                orderby c.Uuid descending
                select c;
            



            return statusbasedquery;
        }
        ///////////////////////////////////////////////////// Method to join data of single Failure from multiple tables///////////////////////////////////////////////////////////
        public static IQueryable<Failure> RetrieveOneFailureData(string nameoftest)

        {

            var q =
                from c in Database.Failures
                from d in Database.L1tests.RightJoin(dc => dc.Testname == c.Testname)
                where c.Testname == nameoftest
                orderby c.Uuid descending

                select c;
                //select new { c.Uuid, c.Nrc, c.Testname, c.Function, c.Tcid, c.Reqid, c.Request, c.Response, d.timeimport, d.Hwteilnummer, d.Hwversion, d.Swteilnummer, d.Swversion, d.Systemtype, };


            return q;
        }

        ///////////////////////////////////////////////////// Method to match data from failure tables///////////////////////////////////////////////////////////
        public static IQueryable<Failure> MatchOccurances(string idtomatch, string auswertungtomatch)

        {

            
                var occurances =
                    from c in Database.Failures
                    from d in Database.L1tests.RightJoin(dc => dc.Testname == c.Testname)
                    where c.Auswertung == auswertungtomatch
                    & c.Tcid == idtomatch

                    select c;
              

            
            return occurances;
        }

        ///////////////////////////////////////////////////// Method to retrieve all test names from L1 tests table///////////////////////////////////////////////////////////
        public static IQueryable <Testnames> AllL1tests()
                        
        {
            DateTimeOffset now = DateTimeOffset.Now;
            TimeSpan duration = new TimeSpan(-29, 12, 12, 12);
            var testnames =
                from x in Database.L1tests
                where x.timeimport - now > duration
                orderby x.Uuid descending

                //select x;
                select new Testnames(x.Testname, x.timeimport);
                       
            return testnames;
        }
        ///////////////////////////////////////////////////// Method to insert bulk data into failure table///////////////////////////////////////////////////////////

        public static void Insertbulkdataintofailure(List<Failure> newlog)

        {
          
            {

                Database.Failures.BulkCopy(newlog);
            }
        }

        ///////////////////////////////////////////////////// Method to insert bulk data into Testcaselog table///////////////////////////////////////////////////////////

        public static void Insertbulkdataintotestcaselog(List<Testcaselog> newlog1)

        {
           
            {

                Database.Testcaselogs.BulkCopy(newlog1);
            }
        }
        ///////////////////////////////////////////////////// Method to insert single entry into failure table///////////////////////////////////////////////////////////

        public static void Insertdataintofailure(string nameoftest)

        {


            {
                Database.Failures.Insert(

                                        () => new Failure()
                                        {
                                            //Uuid = DEFAULT,
                                            Nrc = "NRC_56",
                                            Testname = nameoftest,
                                            Function = "identifikation",
                                            Tcid = "Iden_76",
                                            Reqid = "Iden_87",
                                            Request = "55 33 66",
                                            Response = "95 45 69",
                                            Diagtrace = "xxxxxxx",
                                            Comment = "no comments",
                                            Lasteditor = "SB",
                                            Lastedited = new DateTimeOffset(DateTime.Now),
                                            Ticket = "none",
                                            Session = "0x40",
                                            Procstatus = TestStatus.New,
                                            Auswertung = "P",
                                            Fehlertype = "This",
                                            Ecu = "ECU1"

                                        }

                                       );

            }

        }

        ///////////////////////////////////////////////////// Method to insert single entry into l1tests table///////////////////////////////////////////////////////////

        public static void L1testsinsert(string nameoftest,string systemType ,string sparePartNo, string hrwVersion, string ECUNo, string sfVersion , string clusterNo)
        {

            {
                Database.L1tests.Insert(

                                        () => new L1test()
                                        {
                                            //Uuid = DEFAULT,
                                            Testname = nameoftest,
                                            Systemtype = systemType,
                                            Hwteilnummer = sparePartNo,
                                            Hwversion = hrwVersion,
                                            Swteilnummer = ECUNo,
                                            Swversion = sfVersion,
                                            Clusterno = clusterNo,
                                            timeimport = new DateTimeOffset(DateTime.Now),

                                        }

                                       );

            }
        }
        ///////////////////////////////////////////////////// Method to insert single entry into testcaselogs table///////////////////////////////////////////////////////////

        public static void Testcaselogsinsertsingle(string nameoftest)
        {

            {
                Database.Testcaselogs.Insert(

                                        () => new Testcaselog()
                                        {
                                            //Uuid = DEFAULT,
                                            Testname = nameoftest,
                                            Tcid = "ident_6453",
                                            Reqid = "ident_4583",
                                            Funct = "identifikation",
                                            Testresult = "Passed",
                                            Ecu = "3456X45",
                                            timeofimport = new DateTimeOffset(DateTime.Now),

                                        }

                                       );

            }
        }
        ///////////////////////////////////////////////////// Method to update status in failures table ///////////////////////////////////////////////////////////

        public static void Updatefailuretablestatus(int id, TestStatus Newstate)
        {


            Database.Failures.Where(a => a.Uuid == id)

                                        .Set(a => a.Procstatus, Newstate)
                                        //.Set(a => a.Procstatus, ()  => changedValue)
                                        .Update();

        }


        ///////////////////////////////////////////////////// Method to update comment in failures table ///////////////////////////////////////////////////////////

        public static void Updatefailuretablecomment(int id, string newcomment)
        {


            Database.Failures.Where(a => a.Uuid == id)

                                      .Set(a => a.Comment, newcomment)

                                      .Update();

        }


        //////////////////////////////////////////////// Method to delete rows from testcaselogs table after 3 weeks ////////////////////////////////////////////////////

        public static void Deleteoutdatedtestcases()
        {
            DateTimeOffset now = DateTimeOffset.Now;
            TimeSpan duration = new TimeSpan(-21, 12, 12, 12);


            {
                Database.Testcaselogs.Where(a => a.timeofimport - now < duration)

                        .Delete();
            }

        }



    }

    
}




