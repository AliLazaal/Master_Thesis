using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Evaluation_Tool_for_ENNA_.GUI_Forms;
using Testing_final;
using DataModels;
using Evaluation_Tool_for_ENNA_.Reporting;


namespace Evaluation_Tool_for_ENNA_
{
    public partial class Form1 : Form
    {

        private List<Failure> issuesList;
        private List<string> gTNameList;

        private string gTestName;
        private Testing_final.TestStatus selectedStatus;

        /// <summary>
        /// Create Constructor to assign Test Case No after reading each single test case.
        /// </summary>
        /// <param name="caseNo"></param>

        public Form1()
        {

            InitializeComponent();

            testStatusComboBox.DataSource = Enum.GetValues(typeof(TestStatus));
            // This method removes all the testcases which are older than specificied time period from the Testcaselog Table in the database.
            DatabaseMethods.Deleteoutdatedtestcases();

            AddTestNamesinDropDown();


        }

        /// <summary>
        /// Overload constructer taking in selected  
        /// </summary>
        /// <param name="List"></param>
        /// <param name="testName"></param>
        public Form1(IEnumerable<Failure> List, string testName)
        {
            this.issuesList = List.ToList();
            this.gTestName = testName;

            InitializeComponent();
            testStatusComboBox.DataSource = Enum.GetValues(typeof(TestStatus));
           
        }

        /// <summary>
        /// Method to Poppulate DataGrid with the Issues from DataBase
        /// </summary>
        public void PoppulateDataGridWithIssues(IEnumerable<Failure> List)
        {
            dataGridView1.DataSource = null;

            dataGridView1.Columns.Clear();
            testNameComboBox.Items.Clear();

            issuesList = List.ToList();

            
            // Binding entire list to be poppulated in DataGridView with its own structure 
            var source = new BindingSource();
            source.DataSource = issuesList;
            dataGridView1.DataSource = source;

            AddTestNamesinDropDown();

            dataGridView1.Columns["Diagtrace"].Visible = false;
            dataGridView1.Columns["Comment"].Visible = false;
            dataGridView1.Columns["Ticket"].Visible = false;
            dataGridView1.Columns["Session"].Visible = false;
            dataGridView1.Columns["Nrc"].Visible = false;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

        }
        

        /// <summary>
        /// Retreive All test names from DB to display in drop down box
        /// </summary>
        private void AddTestNamesinDropDown()
        {
            List<string> tNamesList = new List<string>();

            {
                foreach (DatabaseMethods.Testnames testNamesList in DatabaseMethods.AllL1tests())
                {
                    this.testNameComboBox.Items.Add(testNamesList.Testname);
                    tNamesList.Add(testNamesList.Testname);
                }

                this.gTNameList = tNamesList;
            }

        }

        public string selectedValue = string.Empty;

        /// <summary>
        /// Event Handler method called when a value is chnaged in the drop down box of Test name on Main Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testNameComboBox_SelectedValueChanged(object sender, EventArgs e)
        {

            selectedValue = testNameComboBox.SelectedItem.ToString();
        }

        /// <summary>
        /// Event Handler method called when a value is chnaged in the drop down box of Test status on Main Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testStatusComboBox_SelectedValueChanged(object sender, EventArgs e)
        {

            selectedStatus = (Testing_final.TestStatus)testStatusComboBox.SelectedItem;
        }


        /// <summary>
        /// Perform action based on selected values for Test Status and Test Name from drop down box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filterButton_Click(object sender, EventArgs e)
        {
            
            // If user filtercriteria is only to show results for selected Test name.
            if (selectedValue != string.Empty && selectedStatus == TestStatus.Unkown)
            {
                
                PoppulateDataGridWithIssues((IEnumerable<Failure>)DatabaseMethods.GetFailures(selectedValue));

            }

            // If filter criteria is show results for selected Test name and Test status.
            else if (selectedValue != string.Empty && selectedStatus != TestStatus.Unkown)
            {
                
                PoppulateDataGridWithIssues((IEnumerable<Failure>)DatabaseMethods.FilterFailuresStatus(selectedValue, selectedStatus));
                
            }
            
            // Tool gives an error message if user selects Unkown as Test status and no Test name as filter criteria 
            else if (string.IsNullOrEmpty(selectedValue) && selectedStatus == TestStatus.Unkown)
            {
                MessageBox.Show("Invalid filter criteria, Test Status cannot be Unknow. Please Try Again! ");
            }
            
            // If user filtercriteria is only to show results for selected Test status.
            else
            {
                PoppulateDataGridWithIssues((IEnumerable<Failure>)DatabaseMethods.FilterFailuresNameStatus(selectedStatus));
            }

            
        }

        
        
        /// <summary>
        /// Reading test case attributes of the clicked test case. Then pass it to form 2 class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            Form2 secondWin = new Form2(issuesList[e.RowIndex].Diagtrace, issuesList[e.RowIndex].Procstatus,
                issuesList[e.RowIndex].Request, issuesList[e.RowIndex].Response, issuesList[e.RowIndex].Auswertung,
                issuesList[e.RowIndex].Comment, issuesList[e.RowIndex].Uuid, issuesList[e.RowIndex].Tcid,
                issuesList[e.RowIndex].Testname, issuesList[e.RowIndex].Ecu, issuesList[e.RowIndex].Reqid);

           secondWin.ShowDialog();

            issuesList[e.RowIndex].Procstatus= secondWin.RefreshStatus();
            issuesList[e.RowIndex].Lastedited = new DateTimeOffset(DateTime.Now);

            var source = new BindingSource();
            source.DataSource = issuesList;
            dataGridView1.DataSource = source;
            
            secondWin.Dispose();

            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
           
            

        }

        /// <summary>
        /// Clicking the Button for Import New Test Log File 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importButton_Click(object sender, EventArgs e)
        {
            List<string> tNamesList = new List<string>();


            // Test names from the DB are added into the Test Name drop down list.
            foreach (DatabaseMethods.Testnames testNamesList in DatabaseMethods.AllL1tests())
            {
                tNamesList.Add(testNamesList.Testname);
            }
           
            UserFormImportNewTC importNewTC = new UserFormImportNewTC(tNamesList);
            importNewTC.ShowDialog();

            if (importNewTC.DialogResult == DialogResult.OK)
            {
                string testName = importNewTC.testName;
                string clusterNo = importNewTC.clusterNo;

                // LogFile class contains methods where inital Test Log file is parsed into useful format,
                // SingleTestCase followed by FailedTestCase Lists are also created in here.
                Logs Reading_Logs = new Logs();
                Reading_Logs.ReadLogFile();
                Reading_Logs.SaveLogFile();
                MessageBox.Show("Short Log Parsed !");

                // Insert list of failures extracted from new imported test file into the databas table "Failure"
                SendFailuresToDB(Reading_Logs.GetFailedIssues(), Reading_Logs.GetTestCases(), testName, clusterNo);

                // Retreive all new inserted test cases and send to the Tool
                PoppulateDataGridWithIssues((IEnumerable<Failure>)DatabaseMethods.GetFailures(testName));
                importNewTC.Close();
                
            }
            
        }

        /// <summary>
        /// Parsing List of Issues made from Log files and passing as suitable format to DB failure list, for Inserting
        /// into Failure Table
        /// </summary>
        /// <param name="newIssuesList"></param>
        /// <param name="testName"></param>
        /// <param name="Clusterno"></param>
        public void SendFailuresToDB(List<FailedTestCase> newIssuesList, List<SingleTestCase> allTestCases, string testName, string clusterNo)
        {

            string sparePartNo = string.Empty;
            string hardwarePartNo = string.Empty;
            string softwarePartNo = string.Empty;
            string eCUHNo = string.Empty;
            string engineType = string.Empty;

            List<Failure> issueslist = new List<Failure>();

            foreach (FailedTestCase obj in newIssuesList)
            {
                issueslist.Add(new Failure(obj.ProcStatus, obj.NRC, testName, Convert.ToString(obj.Function), obj.TcId, obj.ReqId, obj.Request,
                        obj.Response, obj.DiagTrace, obj.Comment, obj.lastEditor, obj.Ticket, Convert.ToString(obj.Session), obj.Evaluation, obj.FailureType, obj.ECUNo));
            }

            // Sending List of Failures collected from Log File to Database table Failures. 
            DatabaseMethods.Insertbulkdataintofailure(issueslist);

            // Sending List of All Test cases from selected Log file to Database Table TestCaseLogs
            List<Testcaselog> allTCList = new List<Testcaselog>();

            foreach (SingleTestCase obj1 in allTestCases)
            {
                allTCList.Add(new Testcaselog(testName, obj1.TCId, obj1.ReqId, Convert.ToString(obj1.Function), Convert.ToString(obj1.Result), obj1.ECUNo));
            }
            
            // Hardware Details for a Test file is only saved once, using the last of each  
            sparePartNo = allTestCases.LastOrDefault().SparePartNo;
            hardwarePartNo = allTestCases.Last().HardwarePartNo;
            softwarePartNo = allTestCases.Last().SoftwareVersion;
            eCUHNo = allTestCases.Last().ECUHardwareNo;
            engineType = allTestCases.Last().EngineNo;

            DatabaseMethods.Insertbulkdataintotestcaselog(allTCList);

            /// Inserting new Test in the table L1Tests of DB
            DatabaseMethods.L1testsinsert(testName, engineType, sparePartNo, hardwarePartNo, eCUHNo, softwarePartNo, clusterNo);


        }

        /// <summary>
        /// This method retrieves list of test cases for selected Test Name and generate a summary report in tabular format
        /// for HTML file type. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void summaryReport_Button_Click(object sender, EventArgs e)
        {
            // to create Html Summary Report

            List<Testing_final.DatabaseMethods.Occurances1> allTestCases = new List<Testing_final.DatabaseMethods.Occurances1>();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = @"C:\Users\ulazzal\Desktop\MA\Logs\Logs to test for Tool";
            saveFileDialog1.Title = "Save text Files";
            saveFileDialog1.FileName = "";
            saveFileDialog1.CheckPathExists = true;

            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                allTestCases = Testing_final.DatabaseMethods.Gettestcaselogtableinfo(selectedValue).ToList();
               
                //  var Summary = allTestCases.Where(c => c.Reqid != null && c.Tcid != null);
                HtmlSummary summaryReport = new HtmlSummary(allTestCases, Path.GetDirectoryName(saveFileDialog1.FileName), selectedValue);
                summaryReport.GenerateHtmlSummaryReport();

                MessageBox.Show("The Summary Report is generated");

               
            }
        }

        /// <summary>
        /// Only a file is parsed without saving into Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void parseTestFileButton_Click(object sender, EventArgs e)
        {

            Logs parsingTestFile = new Logs();

            parsingTestFile.ReadLogFile();
            parsingTestFile.SaveLogFile();

            MessageBox.Show("File Parsed!");
        }

    }
}

