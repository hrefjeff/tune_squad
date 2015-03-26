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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fallButton
            // 
            this.fallButton.AutoSize = true;
            this.fallButton.Location = new System.Drawing.Point(40, 46);
            this.fallButton.Margin = new System.Windows.Forms.Padding(4);
            this.fallButton.Name = "fallButton";
            this.fallButton.Size = new System.Drawing.Size(51, 21);
            this.fallButton.TabIndex = 0;
            this.fallButton.TabStop = true;
            this.fallButton.Text = "Fall";
            this.fallButton.UseVisualStyleBackColor = true;
            this.fallButton.CheckedChanged += new System.EventHandler(this.FallButtonCheckedChanged);
            // 
            // springButton
            // 
            this.springButton.AutoSize = true;
            this.springButton.Location = new System.Drawing.Point(127, 46);
            this.springButton.Margin = new System.Windows.Forms.Padding(4);
            this.springButton.Name = "springButton";
            this.springButton.Size = new System.Drawing.Size(70, 21);
            this.springButton.TabIndex = 1;
            this.springButton.TabStop = true;
            this.springButton.Text = "Spring";
            this.springButton.UseVisualStyleBackColor = true;
            this.springButton.CheckedChanged += new System.EventHandler(this.SpringButtonCheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 124);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Choose File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // EnrollmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 204);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.springButton);
            this.Controls.Add(this.fallButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EnrollmentForm";
            this.Text = "EnrollmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton fallButton;
        private System.Windows.Forms.RadioButton springButton;
        private System.Windows.Forms.Button button1;
    }
}