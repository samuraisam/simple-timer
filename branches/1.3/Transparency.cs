using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Timer
{
    public partial class Transparency : Form
    {
        private Timer ParentTimer;

        public Transparency(Timer timer)
        {
            this.ParentTimer = timer;
            this.Opacity = timer.Opacity;
            InitializeComponent();

            this.trackBar1.Value = (int)(timer.Opacity * 100.00);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.ParentTimer.Opacity = ((double)this.trackBar1.Value) * 0.01;
            this.Opacity = this.ParentTimer.Opacity;
        }
    }
}