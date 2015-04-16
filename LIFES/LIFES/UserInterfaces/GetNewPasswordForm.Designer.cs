namespace LIFES.UserInterfaces
{
    partial class GetNewPasswordForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.confirmLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.confirmTextBox = new System.Windows.Forms.TextBox();
            this.setPasswordButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.setPasswordButton);
            this.panel1.Controls.Add(this.confirmTextBox);
            this.panel1.Controls.Add(this.passwordTextBox);
            this.panel1.Controls.Add(this.confirmLabel);
            this.panel1.Controls.Add(this.passwordLabel);
            this.panel1.Location = new System.Drawing.Point(40, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 160);
            this.panel1.TabIndex = 0;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(22, 27);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(78, 13);
            this.passwordLabel.TabIndex = 0;
            this.passwordLabel.Text = "New Password";
            // 
            // confirmLabel
            // 
            this.confirmLabel.AutoSize = true;
            this.confirmLabel.Location = new System.Drawing.Point(22, 78);
            this.confirmLabel.Name = "confirmLabel";
            this.confirmLabel.Size = new System.Drawing.Size(91, 13);
            this.confirmLabel.TabIndex = 1;
            this.confirmLabel.Text = "Confirm Password";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(141, 20);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(140, 20);
            this.passwordTextBox.TabIndex = 2;
            // 
            // confirmTextBox
            // 
            this.confirmTextBox.Location = new System.Drawing.Point(141, 71);
            this.confirmTextBox.Name = "confirmTextBox";
            this.confirmTextBox.Size = new System.Drawing.Size(140, 20);
            this.confirmTextBox.TabIndex = 3;
            // 
            // setPasswordButton
            // 
            this.setPasswordButton.Location = new System.Drawing.Point(178, 113);
            this.setPasswordButton.Name = "setPasswordButton";
            this.setPasswordButton.Size = new System.Drawing.Size(103, 23);
            this.setPasswordButton.TabIndex = 4;
            this.setPasswordButton.Text = "Set Password";
            this.setPasswordButton.UseVisualStyleBackColor = true;
            this.setPasswordButton.Click += new System.EventHandler(this.SetPasswordButton_Click);
            // 
            // GetNewPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(22)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(404, 241);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(420, 280);
            this.MinimumSize = new System.Drawing.Size(420, 280);
            this.Name = "GetNewPasswordForm";
            this.Text = "Set Password";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox confirmTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label confirmLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button setPasswordButton;
    }
}