namespace Evaluation_Tool_for_ENNA_.GUI_Forms
{
    partial class UserFormImportNewTC
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.abortButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.clusternoComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Test Name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(185, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cluster:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Please Enter Test Name and Cluster Number:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(101, 268);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // abortButton
            // 
            this.abortButton.Location = new System.Drawing.Point(299, 267);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(75, 23);
            this.abortButton.TabIndex = 6;
            this.abortButton.Text = "Cancel";
            this.abortButton.UseVisualStyleBackColor = true;
            this.abortButton.Click += new System.EventHandler(this.abortButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "E.g. PI13S03_20220124";
            // 
            // clusternoComboBox
            // 
            this.clusternoComboBox.FormattingEnabled = true;
            this.clusternoComboBox.Items.AddRange(new object[] {
            "Cluster 41",
            "Cluster 42",
            "Cluster 43",
            "Cluster 44",
            "Cluster 45",
            "Cluster 46",
            "Cluster 47",
            "Cluster 48",
            "Cluster 49",
            "Cluster 4A",
            "Cluster 4B",
            "Cluster 4C",
            "Cluster 4D",
            "Cluster 4E",
            "Cluster 4F"});
            this.clusternoComboBox.Location = new System.Drawing.Point(185, 160);
            this.clusternoComboBox.Name = "clusternoComboBox";
            this.clusternoComboBox.Size = new System.Drawing.Size(121, 21);
            this.clusternoComboBox.TabIndex = 8;
            this.clusternoComboBox.SelectedValueChanged += new System.EventHandler(this.clusternoComboBox_SelectedValueChanged);
            // 
            // UserFormImportNewTC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 456);
            this.Controls.Add(this.clusternoComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.abortButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "UserFormImportNewTC";
            this.Text = "User Input Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button abortButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox clusternoComboBox;
    }
}