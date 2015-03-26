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
    public partial class EnrollmentForm : Form
    {
        public EnrollmentForm()
        {
            InitializeComponent();
        }

        /*
         * Method:Button1_click
         * Pasrameters: object sender, EventArgs e
         * Ouytput: N/A
         * Created By: Scott Smoke
         * Date: 3/26/2015
         * Modified By: Scott Smoke
         * This will pop up an open file dialog when clicked.
         * This will allow the user to select a total enrollments file.
         */ 
        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Comma Seperated Values |*.csv";
            openFile.Title = "Open Total Enrollments File";
            openFile.ShowDialog();
            Globals.totalEnrollemntsFileName = openFile.FileName;
        }
        /* 
         * Method: FallButtonCheckedChanged
         * Parameters: object sender, EventArgs e
         * Output: N/A
         * Created By: Scott Smoke
         * Date: 3/26/2015
         * Modified By: Scott Smoke
         * When this radio button is clicked it will set the global
         * semester to fall.
         * 
         */
        private void FallButtonCheckedChanged(object sender, EventArgs e)
        {
            if (fallButton.Checked)
            {
                Globals.semester = "fall";
            }
        }
        /* 
         * Method: SpringButtonCheckedChanged
         * Parameters: object sender, EventArgs e
         * Output: N/A
         * Created By: Scott Smoke
         * Date: 3/26/2015
         * Modified By: Scott Smoke
         * When this radio button is clicked it will set the global
         * semester to spring.
         * 
         */
        private void SpringButtonCheckedChanged(object sender, EventArgs e)
        {
            if(springButton.Checked)
            {
                Globals.semester = "spring";

            }

        }
    }
}
