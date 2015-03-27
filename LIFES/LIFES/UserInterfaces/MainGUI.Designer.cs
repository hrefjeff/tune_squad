namespace LIFES.UserInterfaces
{
    partial class MainGUI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleExamDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullExamWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTotalEnrollmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleButton = new System.Windows.Forms.Button();
            this.rescheduleButton = new System.Windows.Forms.Button();
            this.timeConstraintsButton = new System.Windows.Forms.Button();
            this.enrollmentButton = new System.Windows.Forms.Button();
            this.examTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textTest = new System.Windows.Forms.TextBox();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.examTable)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(22)))), ((int)(((byte)(107)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.loginToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(839, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.printToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(159)))), ((int)(((byte)(17)))));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(159)))), ((int)(((byte)(17)))));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(159)))), ((int)(((byte)(17)))));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(159)))), ((int)(((byte)(17)))));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(159)))), ((int)(((byte)(17)))));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(159)))), ((int)(((byte)(17)))));
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItemClick);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(159)))), ((int)(((byte)(17)))));
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singleExamDayToolStripMenuItem,
            this.fullExamWeekToolStripMenuItem,
            this.viewTotalEnrollmentsToolStripMenuItem});
            this.viewToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(159)))), ((int)(((byte)(17)))));
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(51, 21);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // singleExamDayToolStripMenuItem
            // 
            this.singleExamDayToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleExamDayToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(159)))), ((int)(((byte)(17)))));
            this.singleExamDayToolStripMenuItem.Name = "singleExamDayToolStripMenuItem";
            this.singleExamDayToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.singleExamDayToolStripMenuItem.Text = "Single Exam Day";
            // 
            // fullExamWeekToolStripMenuItem
            // 
            this.fullExamWeekToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullExamWeekToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(159)))), ((int)(((byte)(17)))));
            this.fullExamWeekToolStripMenuItem.Name = "fullExamWeekToolStripMenuItem";
            this.fullExamWeekToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.fullExamWeekToolStripMenuItem.Text = "Full Exam Week";
            // 
            // viewTotalEnrollmentsToolStripMenuItem
            // 
            this.viewTotalEnrollmentsToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewTotalEnrollmentsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(159)))), ((int)(((byte)(17)))));
            this.viewTotalEnrollmentsToolStripMenuItem.Name = "viewTotalEnrollmentsToolStripMenuItem";
            this.viewTotalEnrollmentsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.viewTotalEnrollmentsToolStripMenuItem.Text = "View Total Enrollments";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(159)))), ((int)(((byte)(17)))));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(48, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // scheduleButton
            // 
            this.scheduleButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleButton.Location = new System.Drawing.Point(668, 446);
            this.scheduleButton.Margin = new System.Windows.Forms.Padding(4);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(88, 26);
            this.scheduleButton.TabIndex = 2;
            this.scheduleButton.Text = "Schedule";
            this.scheduleButton.UseVisualStyleBackColor = true;
            // 
            // rescheduleButton
            // 
            this.rescheduleButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rescheduleButton.Location = new System.Drawing.Point(536, 446);
            this.rescheduleButton.Margin = new System.Windows.Forms.Padding(4);
            this.rescheduleButton.Name = "rescheduleButton";
            this.rescheduleButton.Size = new System.Drawing.Size(88, 26);
            this.rescheduleButton.TabIndex = 3;
            this.rescheduleButton.Text = "Reschedule";
            this.rescheduleButton.UseVisualStyleBackColor = true;
            // 
            // timeConstraintsButton
            // 
            this.timeConstraintsButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeConstraintsButton.Location = new System.Drawing.Point(88, 84);
            this.timeConstraintsButton.Margin = new System.Windows.Forms.Padding(4);
            this.timeConstraintsButton.Name = "timeConstraintsButton";
            this.timeConstraintsButton.Size = new System.Drawing.Size(125, 26);
            this.timeConstraintsButton.TabIndex = 4;
            this.timeConstraintsButton.Text = "Time Constraints";
            this.timeConstraintsButton.UseVisualStyleBackColor = true;
            // 
            // enrollmentButton
            // 
            this.enrollmentButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enrollmentButton.Location = new System.Drawing.Point(242, 84);
            this.enrollmentButton.Margin = new System.Windows.Forms.Padding(4);
            this.enrollmentButton.Name = "enrollmentButton";
            this.enrollmentButton.Size = new System.Drawing.Size(126, 26);
            this.enrollmentButton.TabIndex = 5;
            this.enrollmentButton.Text = "Total Enrollment";
            this.enrollmentButton.UseVisualStyleBackColor = true;
            // 
            // examTable
            // 
            this.examTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.examTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.examTable.Location = new System.Drawing.Point(88, 161);
            this.examTable.Margin = new System.Windows.Forms.Padding(4);
            this.examTable.Name = "examTable";
            this.examTable.Size = new System.Drawing.Size(668, 234);
            this.examTable.TabIndex = 6;
            this.examTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Class Time";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Exam Time";
            this.Column2.Name = "Column2";
            // 
            // textTest
            // 
            this.textTest.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTest.Location = new System.Drawing.Point(104, 449);
            this.textTest.Margin = new System.Windows.Forms.Padding(4);
            this.textTest.Name = "textTest";
            this.textTest.Size = new System.Drawing.Size(231, 25);
            this.textTest.TabIndex = 7;
            this.textTest.Text = "Text Area for Testing ";
            this.textTest.TextChanged += new System.EventHandler(this.textTest_TextChanged);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(159)))), ((int)(((byte)(17)))));
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(53, 21);
            this.loginToolStripMenuItem.Text = "Login";
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(96)))), ((int)(((byte)(98)))));
            this.ClientSize = new System.Drawing.Size(839, 544);
            this.Controls.Add(this.textTest);
            this.Controls.Add(this.examTable);
            this.Controls.Add(this.enrollmentButton);
            this.Controls.Add(this.timeConstraintsButton);
            this.Controls.Add(this.rescheduleButton);
            this.Controls.Add(this.scheduleButton);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainGUI";
            this.Text = "LIons Final Exam Scheduler";
            this.Load += new System.EventHandler(this.MainGUI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.examTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button scheduleButton;
        private System.Windows.Forms.Button rescheduleButton;
        private System.Windows.Forms.Button timeConstraintsButton;
        private System.Windows.Forms.Button enrollmentButton;
        private System.Windows.Forms.DataGridView examTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox textTest;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singleExamDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullExamWeekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewTotalEnrollmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
    }
}