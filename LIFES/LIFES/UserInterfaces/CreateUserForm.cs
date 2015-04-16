﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using LIFES.Authentication;
using System.Text.RegularExpressions;

namespace LIFES.UserInterfaces
{
    /*
     * Class Name: CreateUserForm.cs
     * 
     * Author: Riley Smith
     * Date: 4/1/2015
     * Modified by: Riley Smith
     * 
     * Description: This is the driver class for the Create User Window.
     * 
     *   Initially generated by Visual Studio GUI builder.
     */
    public partial class CreateUserForm : Form
    {

        //Constants Used for transition animations
        const int AW_SLIDE = 0X40000;
        const int AW_CENTER = 0x00000010;
        const int AW_HOR_POSITIVE = 0X1;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_VER_POSITIVE = 0x00000004;
        const int AW_BLEND = 0X80000;

        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);

        private UserList users;

        public CreateUserForm()
        {
            InitializeComponent();
            users = new UserList();
        }

        /*
         * Method: OnLoad
         * Parameters: EventArgs e
         * Output: N/A
         * Created By: Riley Smith
         * Date: 3/30/2015
         * Modified By: Riley Smith
         * 
         * Override the function that loads the Form.
         * Animates the window as it opens.
         */
        protected override void OnLoad(EventArgs e)
        {
            AnimateWindow(this.Handle, 200, AW_SLIDE | AW_VER_POSITIVE);
        }

        private void CreateUserBttn_Click(object sender, EventArgs e)
        {
            //regular expression for username 
            Regex emailEx = new Regex("^[a-zA-Z0-9]{1,32}@una.edu$");
            if(userNameTextBox.Text != "" && passwordTextBox.Text != "" && confirmTextBox.Text != "")
            {
                if (passwordTextBox.Text == confirmTextBox.Text)
                {
                    users.AddUser(userNameTextBox.Text, passwordTextBox.Text, true);
                    MessageBox.Show(userNameTextBox.Text + " added", "User Added");
                }
            }
        }
    }
}
