using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Evaluation_Tool_for_ENNA_.Reporting; 


namespace Evaluation_Tool_for_ENNA_
{
    public class Logs
    {
        string FinalShortLog;

        private List<SingleTestCase> allTestCases = new List<SingleTestCase>();
        private List<FailedTestCase> failedTestIssues = new List<FailedTestCase>();
        string gSparePartNo = string.Empty;
        string gHardwarePartNo = string.Empty;
        string gSoftwarePartNo = string.Empty;
        string gECUHNo = string.Empty;
        string gEngineType = string.Empty;


        public List<SingleTestCase> GetTestCases()

        {
            return allTestCases;
        }

        public List<FailedTestCase> GetFailedIssues()
        {
            return failedTestIssues;
        }


        /// <summary>
        /// This method reads the Test result file, test cases in the test result file are split into strings of an array.
        /// These Test cases are processed further into single and failed test cases list. 
        /// </summary>
        public void ReadLogFile()
        {
            var filePathToSave = string.Empty;


            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Users\ulazzal\Desktop\MA\Logs\Logs to test for Tool";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.Multiselect = true;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                   
                    foreach (string file in openFileDialog.FileNames)
                    {
                        var fileContent = string.Empty;
                        var filePathToOpen = string.Empty;

                        string pattern = @"Start test case:";
                        Regex regex = new Regex(pattern);

                        using (StreamReader reader = new StreamReader(file))
                        {
                            fileContent = reader.ReadToEnd();

                            Match m = regex.Match(fileContent);
                            if (m.Success)
                            {
                                string[] testcases = Regex.Split(fileContent, pattern);

                                for (int ctr = 0; ctr < testcases.Length; ctr++)
                                {
                                    Test_Case_Properties TestCaseSpecification = new Test_Case_Properties();
                                    FinalShortLog += "\n *********** Test Case No. " + Convert.ToString(ctr) + "***********\n";

                                    SingleTestCase singleTestCase = new SingleTestCase();
                                    HardwareDetails hardwareDetails;

                                    TestCaseSpecification.TestCaseProperties(testcases[ctr], singleTestCase, out hardwareDetails);

                                    /// Adding Set up Configurations like Hardware and Software details
                                    /// of the Test to the SingleTestCase class
                                    if (hardwareDetails.SparePartNo != null)
                                    {
                                        gSparePartNo = hardwareDetails.SparePartNo;
                                    }
                                    if (hardwareDetails.HardwarePartNo != null)
                                    {
                                        gHardwarePartNo = hardwareDetails.HardwarePartNo;
                                    }
                                    if (hardwareDetails.SoftwareVersion != null)
                                    {
                                        gSoftwarePartNo = hardwareDetails.SoftwareVersion;
                                    }
                                    if (hardwareDetails.ECUHardwareNo != null)
                                    {
                                        gECUHNo = hardwareDetails.ECUHardwareNo;
                                    }
                                    if (hardwareDetails.EngineNo != null)
                                    {
                                        gEngineType = hardwareDetails.EngineNo;
                                    }
                                    singleTestCase.SparePartNo = gSparePartNo;
                                    singleTestCase.HardwarePartNo = gHardwarePartNo;
                                    singleTestCase.SoftwareVersion = gSoftwarePartNo;
                                    singleTestCase.ECUHardwareNo = gECUHNo;
                                    singleTestCase.EngineNo = gEngineType;

                                    // Adding Element of Single Test Case into my List of testCases

                                    if (singleTestCase.TCId != null)
                                    {
                                        allTestCases.Add(singleTestCase);
                                    }
                                    
                                    FinalShortLog += TestCaseSpecification.GetShortLog();

                                }

                                failedTestIssues = FailedTestCase.CreateIssues(allTestCases);
                            }
                        }
                    }

                    
                }

            }
        }

        /// <summary>
        /// Saves the parsed log file into a Text file called short log
        /// </summary>
        public void SaveLogFile ()
        { 
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = @"C:\Users\ulazzal\Desktop\MA\Logs\Logs to test for Tool";
            saveFileDialog1.Title = "Save text Files";
            saveFileDialog1.FileName = "";
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
               
                using (StreamWriter sw = File.CreateText(saveFileDialog1.FileName))
                {
                    sw.Write(FinalShortLog);
                }
               
                }
            

        }

    }
}

