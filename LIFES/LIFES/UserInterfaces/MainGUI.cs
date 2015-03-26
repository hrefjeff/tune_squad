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
            scheduleButton.Click += Schedule_Click;
            rescheduleButton.Click += Reschedule_Click;
            timeConstraintsButton.Click += TimeConstraintsButton_Click;
            enrollmentButton.Click += EnrollmentButton_Click;
        }

        void EnrollmentButton_Click(object sender, EventArgs e)
        {
            EnrollmentForm enrollmentGUI = new EnrollmentForm();
            enrollmentGUI.ShowDialog();

            textTest.Text = "Clicked Total Enrollment Button";
        }
            /*
         * Method: TimeConstraintsButton
         * Parameters: object sender, EventArgs e
         * Output: N/A
         * Created By: Riley Smith
         * Date: 3/24/2015
         * Modified By: Riley Smith
         */
        void TimeConstraintsButton_Click(object sender, EventArgs e)
        {
            TimeConstraintsForm timeConstraintsGUI = new TimeConstraintsForm();
            timeConstraintsGUI.ShowDialog();
            TimeConstraintsForm timeConstraints = new TimeConstraintsForm();
            timeConstraints.ShowDialog();
            TimeConstraints tc = timeConstraints.GetTimeConstraints();
            //Testing
            if (tc != null)
            {
                textTest.Text = tc.GetNumberOfDays().ToString();
            }
            else
            {
                textTest.Text = "Error getting data";
            }
          
        }

        void Reschedule_Click(object sender, EventArgs e)
        {
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

