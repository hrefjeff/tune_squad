namespace LIFES.UserInterfaces
{
    partial class EnrollmentForm
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
            this.fallButton = new System.Windows.Forms.RadioButton();
            this.springButton = new System.Windows.Forms.RadioButton();
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fallButton
            // 
            this.fallButton.AutoSize = true;
            this.fallButton.Location = new System.Drawing.Point(14, 27);
            this.fallButton.Name = "fallButton";
            this.fallButton.Size = new System.Drawing.Size(41, 17);
            this.fallButton.TabIndex = 0;
            this.fallButton.TabStop = true;
            this.fallButton.Text = "Fall";
            this.fallButton.UseVisualStyleBackColor = true;
            this.fallButton.CheckedChanged += new System.EventHandler(this.FallButtonCheckedChanged);
            // 
            // springButton
            // 
            this.springButton.AutoSize = true;
            this.springButton.Location = new System.Drawing.Point(14, 60);
            this.springButton.Name = "springButton";
            this.springButton.Size = new System.Drawing.Size(55, 17);
            this.springButton.TabIndex = 1;
            this.springButton.TabStop = true;
            this.springButton.Text = "Spring";
            this.springButton.UseVisualStyleBackColor = true;
            this.springButton.CheckedChanged += new System.EventHandler(this.SpringButtonCheckedChanged);
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(14, 100);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(75, 23);
            this.chooseFileButton.TabIndex = 2;
            this.chooseFileButton.Text = "Choose File";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.ChooseFileButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.chooseFileButton);
            this.panel1.Controls.Add(this.springButton);
            this.panel1.Controls.Add(this.fallButton);
            this.panel1.Location = new System.Drawing.Point(52, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 150);
            this.panel1.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.comboBox1.Location = new System.Drawing.Point(112, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "Select Year";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
            // 
            // EnrollmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(22)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(359, 211);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(375, 250);
            this.MinimumSize = new System.Drawing.Size(375, 250);
            this.Name = "EnrollmentForm";
            this.Text = "Total Enrollment";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton fallButton;
        private System.Windows.Forms.RadioButton springButton;
        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}