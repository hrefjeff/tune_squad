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

namespace LIFES.UserInterfaces
{
    public partial class AdminForm : Form
    {
        //Constants Used for transition animations
        const int AW_SLIDE = 0X40000;
        const int AW_CENTER = 0x00000010;
        const int AW_HOR_POSITIVE = 0X1;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_BLEND = 0X80000;

        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);

        public AdminForm()
        {
            InitializeComponent();
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
            this.Size = this.Owner.Size;
            this.Location = this.Owner.Location;

            AnimateWindow(this.Handle, 200, AW_CENTER | AW_HOR_POSITIVE);
        }
    }
}
