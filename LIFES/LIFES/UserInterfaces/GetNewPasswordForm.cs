using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LIFES.Authentication;

namespace LIFES.UserInterfaces
{
    public partial class GetNewPasswordForm : Form
    {
        private string username;

        public GetNewPasswordForm(string name)
        {
            InitializeComponent();

            username = name;
        }

        private void SetPasswordButton_Click(object sender, EventArgs e)
        {
            UserList userList = new UserList();

            if (passwordTextBox.Text != "" && confirmTextBox.Text != "")
            {
                if (passwordTextBox.Text == confirmTextBox.Text)
                {
                    userList.ChangePassword(username, passwordTextBox.Text);
                    //MessageBox.Show(passwordTextBox.Text);
                }
            }
        }
    }
}
