using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Evaluation_Tool_for_ENNA_;
using DataModels;
using Testing_final;
using Evaluation_Tool_for_ENNA_.Helper;
using Evaluation_Tool_for_ENNA_.GUI_Forms;



namespace Evaluation_Tool_for_ENNA_
{
    public partial class Form2 : Form
    {
        public List<Testing_final.DatabaseMethods.Occurances> pastOccurrencesList;
        public IEnumerable<L1test> l1HardwareDetailslist;
        string Result = string.Empty;
        string gTestName;
        string gECU;
        string gTCID;
        string gReqID;

        private readonly Color selectionForegroundColor = Color.Red;
        private readonly Color selectionBackgroundColor = Color.Yellow;


        public Form2()
        {


        }

        private int Uuid = 0;
        private string Comment = "";
        private Testing_final.TestStatus selectedStatus;


        /// <summary>
        /// Constructor method passing test attributes of the selected issue as argument. 
        /// </summary>
        /// <param DiagTrace="issueText"></param>
        /// <param TestStatus="testStatus"></param>
        /// <param RequestMessage="request"></param>
        /// <param ResponseMessage="response"></param>
        /// <param EvaluationMessage="evaluation"></param>
        /// <param Comment="comment"></param>
        /// <param name="uuid"></param>
        /// <param TestCaseId="testCaseId"></param>
        /// <param TestName="testName"></param>
        /// <param ECUNo="ECUNo"></param>
        /// <param ReqID="reqID"></param>
        internal Form2(string issueText, Testing_final.TestStatus testStatus,
                        string request, string response, string evaluation, string comment, int uuid, string testCaseId,
                        string testName, string ECUNo, string reqID)

        {
            InitializeComponent();
            statusComboBox.DataSource = Enum.GetValues(typeof(Testing_final.TestStatus));
            Uuid = uuid;

            /// Setting up Diag Trace Text Box 
            diagTraceTextBox1.Text = issueText;
            Result = issueText;
            ActiveControl = diagTraceTextBox1;
            SetHighlights();

            /// Current Status in Drop Down Box
            statusComboBox.SelectedItem = testStatus;

            /// Current Comment in Comment Box
            commentRichTextBox.Text = comment;
            Comment = comment;

            /// Failure Details Text Box
            requestTextBox.Text = request;
            responseTextBox.Text = response;
            evalTextBox.Text = evaluation;

            gTestName = testName;
            gECU = ECUNo;
            gTCID = testCaseId;
            gReqID = reqID;
             
            PoppulatePastOccDataGrid((IEnumerable<Testing_final.DatabaseMethods.Occurances>)DatabaseMethods.MatchOccurances(testCaseId, evaluation));

            PoppulateHardwareDetails();

        }

        /// <summary>
        /// Past occurrences for the selected issue are retrieved for database method MatchOccurances and 
        /// passed as argument into this method. This method fills in the DataGridView with similar occurrences
        /// </summary>
        /// <param name="pOList"></param>
        private void PoppulatePastOccDataGrid(IEnumerable<Testing_final.DatabaseMethods.Occurances> pOList)
        {
            pastOccurrencesList = pOList.ToList();

            var source = new BindingSource();
            source.DataSource = pastOccurrencesList;
            PastOccrurDataGridView.DataSource = source;

            PastOccrurDataGridView.Columns["DiagTrace"].Visible = false;
            PastOccrurDataGridView.Columns["HardwareNo"].Visible = false;
            PastOccrurDataGridView.Columns["HardwareVersionNo"].Visible = false;
            PastOccrurDataGridView.Columns["SoftwareVersionNo"].Visible = false;
            PastOccrurDataGridView.Columns["SystemType"].Visible = false;
            
        }

        private void PastOccrurDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            diagTraceTextBox1.Clear();
            hardwareNoTextBox.Clear();
            hardwareVersiontextBox.Clear();
            softwareVersiontextBox.Clear();
            ECUTextBox.Clear();
            engineTypeTextBox.Clear();
            commentRichTextBox.Clear();
          


            diagTraceTextBox1.Text = pastOccurrencesList[e.RowIndex].DiagTrace;
            SetHighlights();

            this.hardwareNoTextBox.Text = pastOccurrencesList[e.RowIndex].HardwareNo;
            this.hardwareVersiontextBox.Text = pastOccurrencesList[e.RowIndex].HardwareVersionNo;
            this.softwareVersiontextBox.Text = pastOccurrencesList[e.RowIndex].SoftwareVersionNo;
            this.ECUTextBox.Text = pastOccurrencesList[e.RowIndex].ECUNo;
            this.engineTypeTextBox.Text = pastOccurrencesList[e.RowIndex].SystemType;
            this.commentRichTextBox.Text = pastOccurrencesList[e.RowIndex].Comment;
            this.statusComboBox.SelectedItem = pastOccurrencesList[e.RowIndex].Status;


        }
        /// <summary>
        /// This method retrieves and fills in the text boxes with relevant Hardware and Software details for selected Test Issue
        /// </summary>
        private void PoppulateHardwareDetails()
        {   
            foreach (L1test l1Test in DatabaseMethods.GetL1testtableinfo(gTestName))
            {
                this.hardwareNoTextBox.Text = l1Test.Hwteilnummer;
                this.hardwareVersiontextBox.Text = l1Test.Hwversion;
                this.softwareVersiontextBox.Text = l1Test.Swteilnummer;
                this.ECUTextBox.Text = gECU;
                this.engineTypeTextBox.Text = l1Test.Systemtype;
            }
         
        }

        /// <summary>
        /// This method highlights the last line with Valuation : Fail using RehExp pattern
        /// </summary>
        private void SetHighlights()
        {
            diagTraceTextBox1.SelectAll();

            Match match = Regex.Match(diagTraceTextBox1.Text, Test_Case_Properties.issueInLogPattern, RegexOptions.RightToLeft);

            diagTraceTextBox1.Select(match.Groups["Issue"].Index, match.Groups["Issue"].Length);
            diagTraceTextBox1.SelectionColor = selectionForegroundColor;
            diagTraceTextBox1.SelectionBackColor = selectionBackgroundColor;

        }

        /// <summary>
        /// This method is called whenever user changes the text in Comment Text Box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commentRichTextBox_TextChanged(object sender, EventArgs e)
        {
            Comment = commentRichTextBox.Text;
        }

        /// <summary>
        /// This method is called whenever a value of the Test Status drop down box is changed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statusComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedStatus = (Testing_final.TestStatus)statusComboBox.SelectedItem;
        }

        /// <summary>
        /// This method updates the changes made to Test status and comments. This method also changes the test status in 
        /// Testcaselog Table based on the selected Test status.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {

            Testing_final.DatabaseMethods.Updatefailuretablestatus(Uuid, selectedStatus);
            Testing_final.DatabaseMethods.Updatefailuretablecomment(Uuid, Comment);

            switch (selectedStatus)
            {
                case (TestStatus.SkriptFehler):
                case (TestStatus.BehaviourAccepted):
                case (TestStatus.FolgeFehler):
                case (TestStatus.InReTestOkay):

                   
                    Testing_final.DatabaseMethods.Updatetestcasestatus(gTestName, gReqID, gTCID, Convert.ToString(Enums.TestcaseResults.Passed));
                   
                    break;

                case (TestStatus.AllTicketsClosed):
                case (TestStatus.TicketOpen):

                    Testing_final.DatabaseMethods.Updatetestcasestatus(gTestName, gReqID, gTCID, Convert.ToString(Enums.TestcaseResults.Failed));
                    break;

                case (TestStatus.InConsultation):
                case (TestStatus.New):
                case (TestStatus.ReTestRequired):
                case (TestStatus.UnderObservation):

                    Testing_final.DatabaseMethods.Updatetestcasestatus(gTestName, gReqID, gTCID, Convert.ToString(Enums.TestcaseResults.Open));
                    break;

            }

            this.Close();

        }
        /// <summary>
        /// This method returns new TestStatus after evaluation
        /// </summary>
        /// <returns></returns>
        public TestStatus RefreshStatus()
        {
            return selectedStatus;
        }
        
        private void abortButton_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you want to abort ?", "Yes or No ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }
            if (result == DialogResult.Yes)
            {
                this.Close();

            }
        }
    }
}
