namespace Evaluation_Tool_for_ENNA_
{
    public partial class Form2
    {
        public Form2(object sender)
        {

            InitializeComponent();


        }

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
            this.diagTraceTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.commentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.requestTextBox = new System.Windows.Forms.TextBox();
            this.responseTextBox = new System.Windows.Forms.TextBox();
            this.evalTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.abortButton = new System.Windows.Forms.Button();
            this.engineTypeTextBox = new System.Windows.Forms.TextBox();
            this.ECUTextBox = new System.Windows.Forms.TextBox();
            this.engineTypeLabel = new System.Windows.Forms.Label();
            this.ECULabel = new System.Windows.Forms.Label();
            this.softwareVersiontextBox = new System.Windows.Forms.TextBox();
            this.hardwareVersiontextBox = new System.Windows.Forms.TextBox();
            this.hardwareNoTextBox = new System.Windows.Forms.TextBox();
            this.softwareVrLabel = new System.Windows.Forms.Label();
            this.hardwareVrLabel = new System.Windows.Forms.Label();
            this.hardwareNoLabel = new System.Windows.Forms.Label();
            this.PastOccrurDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.PastOccrurDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // diagTraceTextBox1
            // 
            this.diagTraceTextBox1.Location = new System.Drawing.Point(39, 48);
            this.diagTraceTextBox1.Name = "diagTraceTextBox1";
            this.diagTraceTextBox1.Size = new System.Drawing.Size(1112, 228);
            this.diagTraceTextBox1.TabIndex = 0;
            this.diagTraceTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Diagnostic Trace";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 490);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status ";
            // 
            // statusComboBox
            // 
            this.statusComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Location = new System.Drawing.Point(82, 487);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(164, 21);
            this.statusComboBox.TabIndex = 4;
            this.statusComboBox.SelectedValueChanged += new System.EventHandler(this.statusComboBox_SelectedValueChanged);
            // 
            // commentRichTextBox
            // 
            this.commentRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commentRichTextBox.Location = new System.Drawing.Point(39, 654);
            this.commentRichTextBox.Name = "commentRichTextBox";
            this.commentRichTextBox.Size = new System.Drawing.Size(686, 96);
            this.commentRichTextBox.TabIndex = 5;
            this.commentRichTextBox.Text = "";
            this.commentRichTextBox.TextChanged += new System.EventHandler(this.commentRichTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 635);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Comments";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 521);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Failure Details";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 553);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Request";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 577);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Response";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 602);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Evaluation";
            // 
            // requestTextBox
            // 
            this.requestTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.requestTextBox.Location = new System.Drawing.Point(114, 550);
            this.requestTextBox.Name = "requestTextBox";
            this.requestTextBox.Size = new System.Drawing.Size(611, 20);
            this.requestTextBox.TabIndex = 11;
            // 
            // responseTextBox
            // 
            this.responseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.responseTextBox.Location = new System.Drawing.Point(114, 574);
            this.responseTextBox.Name = "responseTextBox";
            this.responseTextBox.Size = new System.Drawing.Size(611, 20);
            this.responseTextBox.TabIndex = 12;
            // 
            // evalTextBox
            // 
            this.evalTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.evalTextBox.Location = new System.Drawing.Point(114, 599);
            this.evalTextBox.Name = "evalTextBox";
            this.evalTextBox.Size = new System.Drawing.Size(611, 20);
            this.evalTextBox.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Past Occurrences";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(742, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Train Details";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveButton.Location = new System.Drawing.Point(1319, 774);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // abortButton
            // 
            this.abortButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.abortButton.Location = new System.Drawing.Point(39, 774);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(75, 23);
            this.abortButton.TabIndex = 17;
            this.abortButton.Text = "Abort";
            this.abortButton.UseVisualStyleBackColor = true;
            this.abortButton.Click += new System.EventHandler(this.abortButton_Click);
            // 
            // engineTypeTextBox
            // 
            this.engineTypeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.engineTypeTextBox.Location = new System.Drawing.Point(832, 421);
            this.engineTypeTextBox.Name = "engineTypeTextBox";
            this.engineTypeTextBox.Size = new System.Drawing.Size(319, 20);
            this.engineTypeTextBox.TabIndex = 22;
            // 
            // ECUTextBox
            // 
            this.ECUTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ECUTextBox.Location = new System.Drawing.Point(832, 397);
            this.ECUTextBox.Name = "ECUTextBox";
            this.ECUTextBox.Size = new System.Drawing.Size(319, 20);
            this.ECUTextBox.TabIndex = 21;
            // 
            // engineTypeLabel
            // 
            this.engineTypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.engineTypeLabel.AutoSize = true;
            this.engineTypeLabel.Location = new System.Drawing.Point(761, 424);
            this.engineTypeLabel.Name = "engineTypeLabel";
            this.engineTypeLabel.Size = new System.Drawing.Size(70, 13);
            this.engineTypeLabel.TabIndex = 19;
            this.engineTypeLabel.Text = "Engine Type:";
            // 
            // ECULabel
            // 
            this.ECULabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ECULabel.AutoSize = true;
            this.ECULabel.Location = new System.Drawing.Point(781, 400);
            this.ECULabel.Name = "ECULabel";
            this.ECULabel.Size = new System.Drawing.Size(49, 13);
            this.ECULabel.TabIndex = 18;
            this.ECULabel.Text = "ECU No:";
            // 
            // softwareVersiontextBox
            // 
            this.softwareVersiontextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.softwareVersiontextBox.Location = new System.Drawing.Point(832, 373);
            this.softwareVersiontextBox.Name = "softwareVersiontextBox";
            this.softwareVersiontextBox.Size = new System.Drawing.Size(319, 20);
            this.softwareVersiontextBox.TabIndex = 29;
            // 
            // hardwareVersiontextBox
            // 
            this.hardwareVersiontextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hardwareVersiontextBox.Location = new System.Drawing.Point(832, 348);
            this.hardwareVersiontextBox.Name = "hardwareVersiontextBox";
            this.hardwareVersiontextBox.Size = new System.Drawing.Size(319, 20);
            this.hardwareVersiontextBox.TabIndex = 28;
            // 
            // hardwareNoTextBox
            // 
            this.hardwareNoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hardwareNoTextBox.Location = new System.Drawing.Point(832, 324);
            this.hardwareNoTextBox.Name = "hardwareNoTextBox";
            this.hardwareNoTextBox.Size = new System.Drawing.Size(319, 20);
            this.hardwareNoTextBox.TabIndex = 27;
            // 
            // softwareVrLabel
            // 
            this.softwareVrLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.softwareVrLabel.AutoSize = true;
            this.softwareVrLabel.Location = new System.Drawing.Point(744, 376);
            this.softwareVrLabel.Name = "softwareVrLabel";
            this.softwareVrLabel.Size = new System.Drawing.Size(90, 13);
            this.softwareVrLabel.TabIndex = 26;
            this.softwareVrLabel.Text = "Software Version:";
            // 
            // hardwareVrLabel
            // 
            this.hardwareVrLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hardwareVrLabel.AutoSize = true;
            this.hardwareVrLabel.Location = new System.Drawing.Point(740, 351);
            this.hardwareVrLabel.Name = "hardwareVrLabel";
            this.hardwareVrLabel.Size = new System.Drawing.Size(94, 13);
            this.hardwareVrLabel.TabIndex = 25;
            this.hardwareVrLabel.Text = "Hardware Version:";
            // 
            // hardwareNoLabel
            // 
            this.hardwareNoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hardwareNoLabel.AutoSize = true;
            this.hardwareNoLabel.Location = new System.Drawing.Point(761, 327);
            this.hardwareNoLabel.Name = "hardwareNoLabel";
            this.hardwareNoLabel.Size = new System.Drawing.Size(73, 13);
            this.hardwareNoLabel.TabIndex = 24;
            this.hardwareNoLabel.Text = "Hardware No:";
            // 
            // PastOccrurDataGridView
            // 
            this.PastOccrurDataGridView.AllowUserToAddRows = false;
            this.PastOccrurDataGridView.AllowUserToDeleteRows = false;
            this.PastOccrurDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PastOccrurDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PastOccrurDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.PastOccrurDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PastOccrurDataGridView.Location = new System.Drawing.Point(39, 313);
            this.PastOccrurDataGridView.MultiSelect = false;
            this.PastOccrurDataGridView.Name = "PastOccrurDataGridView";
            this.PastOccrurDataGridView.ReadOnly = true;
            this.PastOccrurDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PastOccrurDataGridView.Size = new System.Drawing.Size(362, 150);
            this.PastOccrurDataGridView.TabIndex = 30;
            this.PastOccrurDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PastOccrurDataGridView_CellContentDoubleClick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 809);
            this.Controls.Add(this.PastOccrurDataGridView);
            this.Controls.Add(this.softwareVersiontextBox);
            this.Controls.Add(this.hardwareVersiontextBox);
            this.Controls.Add(this.hardwareNoTextBox);
            this.Controls.Add(this.softwareVrLabel);
            this.Controls.Add(this.hardwareVrLabel);
            this.Controls.Add(this.hardwareNoLabel);
            this.Controls.Add(this.engineTypeTextBox);
            this.Controls.Add(this.ECUTextBox);
            this.Controls.Add(this.engineTypeLabel);
            this.Controls.Add(this.ECULabel);
            this.Controls.Add(this.abortButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.evalTextBox);
            this.Controls.Add(this.responseTextBox);
            this.Controls.Add(this.requestTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.commentRichTextBox);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.diagTraceTextBox1);
            this.Name = "Form2";
            this.Text = "Evaluation Window";
            ((System.ComponentModel.ISupportInitialize)(this.PastOccrurDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox diagTraceTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.RichTextBox commentRichTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox requestTextBox;
        private System.Windows.Forms.TextBox responseTextBox;
        private System.Windows.Forms.TextBox evalTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button abortButton;
        private System.Windows.Forms.TextBox engineTypeTextBox;
        private System.Windows.Forms.TextBox ECUTextBox;
        private System.Windows.Forms.Label engineTypeLabel;
        private System.Windows.Forms.Label ECULabel;
        private System.Windows.Forms.TextBox softwareVersiontextBox;
        private System.Windows.Forms.TextBox hardwareVersiontextBox;
        private System.Windows.Forms.TextBox hardwareNoTextBox;
        private System.Windows.Forms.Label softwareVrLabel;
        private System.Windows.Forms.Label hardwareVrLabel;
        private System.Windows.Forms.Label hardwareNoLabel;
        private System.Windows.Forms.DataGridView PastOccrurDataGridView;
    }
}