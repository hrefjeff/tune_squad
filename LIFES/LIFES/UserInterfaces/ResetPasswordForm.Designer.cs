﻿namespace LIFES.UserInterfaces
{
    partial class ResetPasswordForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.userNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resetPassButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNames});
            this.dataGridView1.Location = new System.Drawing.Point(69, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(282, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // userNames
            // 
            this.userNames.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.userNames.HeaderText = "User Name";
            this.userNames.Name = "userNames";
            // 
            // resetPassButton
            // 
            this.resetPassButton.Location = new System.Drawing.Point(250, 203);
            this.resetPassButton.Name = "resetPassButton";
            this.resetPassButton.Size = new System.Drawing.Size(101, 23);
            this.resetPassButton.TabIndex = 1;
            this.resetPassButton.Text = "Reset Password";
            this.resetPassButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.resetPassButton);
            this.panel1.Location = new System.Drawing.Point(63, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 243);
            this.panel1.TabIndex = 2;
            // 
            // ResetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(22)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(548, 338);
            this.Controls.Add(this.panel1);
            this.Name = "ResetPasswordForm";
            this.Text = "Reset Password";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNames;
        private System.Windows.Forms.Button resetPassButton;
        private System.Windows.Forms.Panel panel1;
    }
}