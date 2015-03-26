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
    
    public partial class TimeConstraintsForm : Form
    {
        private TimeConstraints tc;
        public TimeConstraintsForm()
        {
            InitializeComponent();

            getData.Click += GetData_Click;
        }

        void GetData_Click(object sender, EventArgs e)
        {

            if (tc != null)
            {
                textBox6.Text = tc.GetNumberOfDays().ToString();
                textBox7.Text = tc.GetStartTime().ToString();
                textBox8.Text = tc.GetLengthOfExams().ToString();
                textBox9.Text = tc.GetTimeBetweenExams().ToString();
                textBox10.Text = tc.GetLunchPeriod().ToString();
            }
        }
      
        /*
         * Method: GetTimeConstraints
         * Parameters: N/A
         * Output: A TimeConstraints object
         * Created By: Scott Smoke
         * Date: 3/25/2015
         * Modified By: Scott Smoke
         * This will return the time constraints that have been entered.
         * If no data was entered then it will construct an object with all zzeroes.
         */ 
        public TimeConstraints GetTimeConstraints()
        {
            return tc;
        }

        /*
         * Method: button_2Click (update TimeConstraints)
         * Paramters: object Sender, EventArgs e
         * Output: N/A
         * Created By: Scott Smoke
         * Date: 3/25/2015
         * Modified By: Scott Smoke
         * When this button is clicked the data that is in the form
         * get saved into the TimeConstraints variable.
         * If no data is entered then the TimeConstraints variable
         * data is all set to zero
         * 
         */ 
        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") &&
                (textBox3.Text != "") && (textBox4.Text != "") &&
                (textBox5.Text != ""))
            {
                TimeConstraints t = new TimeConstraints(Convert.ToInt32(textBox1.Text),
                Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text),
                Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
                 tc = t;
            }
            else
            {
                TimeConstraints t = new TimeConstraints(0, 0, 0, 0, 0);
                 tc = t;
            }
        }

    }
}
