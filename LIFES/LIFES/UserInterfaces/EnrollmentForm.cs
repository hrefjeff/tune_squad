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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

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
    }
}
