using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIFES.UserInterfaces
{
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();
            Schedule.Click += Schedule_Click;
            Reschedule.Click += Reschedule_Click;
            timeConstraintsButton.Click += timeConstraintsButton_Click;
            enrollmentButton.Click += enrollmentButton_Click;
            helpToolStripMenuItem.Click += helpToolStripMenuItem_Click;
        }

        void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        void enrollmentButton_Click(object sender, EventArgs e)
        {
            EnrollmentForm enrollment = new EnrollmentForm();
            enrollment.ShowDialog();
            textTest.Text = "Clicked Total Enrollment Button";
        }

        void timeConstraintsButton_Click(object sender, EventArgs e)
        {
            TimeConstraintsForm timeConstraints = new TimeConstraintsForm();
            timeConstraints.ShowDialog();

            textTest.Text = "Clicked Time Constraints Button";
        }

        void Reschedule_Click(object sender, EventArgs e)
        {
            examTable.Rows[0].Cells[0].Value = "Rescheduled First Class Time";
            examTable.Rows[0].Cells[1].Value = "Rescheduled  First Exam Time";

            textTest.Text = "Clicked Reschedule Button";
        }

        void Schedule_Click(object sender, EventArgs e)
        {
            examTable.Rows[0].Cells[0].Value = "First Class Time";
            examTable.Rows[0].Cells[1].Value = "First Exam Time";
 
            textTest.Text = "Clicked Schedule Button";
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textTest_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

