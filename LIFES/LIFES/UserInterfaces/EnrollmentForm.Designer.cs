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
            this.SuspendLayout();
            // 
            // fallButton
            // 
            this.fallButton.AutoSize = true;
            this.fallButton.Location = new System.Drawing.Point(30, 37);
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
            this.springButton.Location = new System.Drawing.Point(95, 37);
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
            this.chooseFileButton.Location = new System.Drawing.Point(30, 101);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(75, 23);
            this.chooseFileButton.TabIndex = 2;
            this.chooseFileButton.Text = "Choose File";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.ChooseFileButton_Click);
            // 
            // EnrollmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 166);
            this.Controls.Add(this.chooseFileButton);
            this.Controls.Add(this.springButton);
            this.Controls.Add(this.fallButton);
            this.Name = "EnrollmentForm";
            this.Text = "Total Enrollment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton fallButton;
        private System.Windows.Forms.RadioButton springButton;
        private System.Windows.Forms.Button chooseFileButton;
    }
}