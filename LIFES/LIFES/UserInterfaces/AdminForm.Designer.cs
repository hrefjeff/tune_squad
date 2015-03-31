namespace LIFES.UserInterfaces
{
    partial class AdminForm
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
            this.createUserButton = new System.Windows.Forms.Button();
            this.deleteUserButton = new System.Windows.Forms.Button();
            this.resetPasswordButton = new System.Windows.Forms.Button();
            this.finalizeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createUserButton
            // 
            this.createUserButton.Location = new System.Drawing.Point(66, 74);
            this.createUserButton.Name = "createUserButton";
            this.createUserButton.Size = new System.Drawing.Size(117, 23);
            this.createUserButton.TabIndex = 0;
            this.createUserButton.Text = "Create User";
            this.createUserButton.UseVisualStyleBackColor = true;
            // 
            // deleteUserButton
            // 
            this.deleteUserButton.Location = new System.Drawing.Point(234, 74);
            this.deleteUserButton.Name = "deleteUserButton";
            this.deleteUserButton.Size = new System.Drawing.Size(117, 23);
            this.deleteUserButton.TabIndex = 1;
            this.deleteUserButton.Text = "Delete User";
            this.deleteUserButton.UseVisualStyleBackColor = true;
            // 
            // resetPasswordButton
            // 
            this.resetPasswordButton.Location = new System.Drawing.Point(66, 150);
            this.resetPasswordButton.Name = "resetPasswordButton";
            this.resetPasswordButton.Size = new System.Drawing.Size(117, 23);
            this.resetPasswordButton.TabIndex = 2;
            this.resetPasswordButton.Text = "Reset Password";
            this.resetPasswordButton.UseVisualStyleBackColor = true;
            // 
            // finalizeButton
            // 
            this.finalizeButton.Location = new System.Drawing.Point(234, 150);
            this.finalizeButton.Name = "finalizeButton";
            this.finalizeButton.Size = new System.Drawing.Size(117, 23);
            this.finalizeButton.TabIndex = 3;
            this.finalizeButton.Text = "Finalize Exam Schedule";
            this.finalizeButton.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 268);
            this.Controls.Add(this.finalizeButton);
            this.Controls.Add(this.resetPasswordButton);
            this.Controls.Add(this.deleteUserButton);
            this.Controls.Add(this.createUserButton);
            this.Name = "AdminForm";
            this.Text = "Administrator Controls";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createUserButton;
        private System.Windows.Forms.Button deleteUserButton;
        private System.Windows.Forms.Button resetPasswordButton;
        private System.Windows.Forms.Button finalizeButton;
    }
}