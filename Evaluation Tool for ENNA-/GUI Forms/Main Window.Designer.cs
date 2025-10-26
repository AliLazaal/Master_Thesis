

namespace Evaluation_Tool_for_ENNA_
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Import = new System.Windows.Forms.Button();
            this.filterButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.testNameComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.testStatusComboBox = new System.Windows.Forms.ComboBox();
            this.summaryReport_Button = new System.Windows.Forms.Button();
            this.ParseTestFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(109, 110);
            this.label1.MaximumSize = new System.Drawing.Size(200, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 200);
            this.label1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 110);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(891, 752);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            
            // 
            // Import
            // 
            this.Import.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Import.Location = new System.Drawing.Point(949, 110);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(128, 23);
            this.Import.TabIndex = 3;
            this.Import.Text = "Import New Test File";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.importButton_Click);
            // 
            // filterButton
            // 
            this.filterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.filterButton.Location = new System.Drawing.Point(949, 302);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 23);
            this.filterButton.TabIndex = 4;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(949, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filter:";
            // 
            // testNameComboBox
            // 
            this.testNameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.testNameComboBox.FormattingEnabled = true;
            this.testNameComboBox.Location = new System.Drawing.Point(949, 199);
            this.testNameComboBox.Name = "testNameComboBox";
            this.testNameComboBox.Size = new System.Drawing.Size(121, 21);
            this.testNameComboBox.TabIndex = 6;
            this.testNameComboBox.SelectedValueChanged += new System.EventHandler(this.testNameComboBox_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(949, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Test Name:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(946, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Test Status:";
            // 
            // testStatusComboBox
            // 
            this.testStatusComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.testStatusComboBox.FormattingEnabled = true;
            this.testStatusComboBox.Location = new System.Drawing.Point(949, 261);
            this.testStatusComboBox.Name = "testStatusComboBox";
            this.testStatusComboBox.Size = new System.Drawing.Size(121, 21);
            this.testStatusComboBox.TabIndex = 10;
            this.testStatusComboBox.SelectedValueChanged += new System.EventHandler(this.testStatusComboBox_SelectedValueChanged);
            // 
            // summaryReport_Button
            // 
            this.summaryReport_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.summaryReport_Button.Location = new System.Drawing.Point(949, 442);
            this.summaryReport_Button.Name = "summaryReport_Button";
            this.summaryReport_Button.Size = new System.Drawing.Size(125, 23);
            this.summaryReport_Button.TabIndex = 11;
            this.summaryReport_Button.Text = "Summary Report";
            this.summaryReport_Button.UseVisualStyleBackColor = true;
            this.summaryReport_Button.Click += new System.EventHandler(this.summaryReport_Button_Click);
            // 
            // ParseTestFile
            // 
            this.ParseTestFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ParseTestFile.Location = new System.Drawing.Point(949, 595);
            this.ParseTestFile.Name = "ParseTestFile";
            this.ParseTestFile.Size = new System.Drawing.Size(121, 23);
            this.ParseTestFile.TabIndex = 12;
            this.ParseTestFile.Text = "Parse Test File";
            this.ParseTestFile.UseVisualStyleBackColor = true;
            this.ParseTestFile.Click += new System.EventHandler(this.parseTestFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 874);
            this.Controls.Add(this.ParseTestFile);
            this.Controls.Add(this.summaryReport_Button);
            this.Controls.Add(this.testStatusComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.testNameComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.Import);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Main Window";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox testNameComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox testStatusComboBox;
        private System.Windows.Forms.Button summaryReport_Button;
        private System.Windows.Forms.Button ParseTestFile;
    }
}