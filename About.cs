using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Timer
{
    public partial class About : Form
    {
        private Timer ParentTimer;

        public About(Timer timer)
        {
            this.ParentTimer = timer;
            this.Opacity = timer.Opacity;
            this.TopMost = timer.TopMost;
            InitializeComponent();
        }
    }
}