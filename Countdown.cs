using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Timer
{
    public partial class Countdown : Form
    {
        private Timer ParentTimer;

        public Countdown(Timer timer)
        {
            this.ParentTimer = timer;
            this.Opacity = timer.Opacity;
            this.TopMost = timer.TopMost;
            InitializeComponent();
        }
    }
}