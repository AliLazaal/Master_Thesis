using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Evaluation_Tool_for_ENNA_;


namespace Evaluation_Tool_for_ENNA_.GUI_Forms
{
    public partial class UserFormImportNewTC : Form
    {
        private List<string> gTNameList;

        public UserFormImportNewTC(List<string> tNameList)
        {
            this.gTNameList = tNameList;
            InitializeComponent();
            testName = string.Empty;
            clusterNo = string.Empty;

        }


        public string testName;
        public string clusterNo;
        public string selectedCluster;

        /// <summary>
        /// This method is called when user clicks on the Save button on Evaluation Window.
        /// Uniqueness of the entered test name is also checked in this method 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != null && clusternoComboBox.SelectedItem != null)
                {
                    /// Compare written Test Name with previous Test names in DB to make sure Test Name to be unique.

                    if (gTNameList.Contains(textBox1.Text, StringComparer.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("This Test name is already used before. Please enter a unique Test Name!", "Error");
                        DialogResult = DialogResult.Retry;
                    }

                    else
                    {
                        this.testName = textBox1.Text;
                        this.clusterNo = selectedCluster;

                        DialogResult = DialogResult.OK;
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot Proceed, Both Fields are compulsory");
            }

        }

        private void clusternoComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedCluster = clusternoComboBox.SelectedItem.ToString();

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

