using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Timer
{
    public partial class Transparancy : Form
    {
        private Timer ParentTimer;

        public Transparancy()
        {
            InitializeComponent();
        }

        public DialogResult ShowCustomDialog(Timer timer)
        {
            this.ParentTimer = timer;
            this.Opacity = timer.Opacity;
            this.trackBar1.Value = Convert.ToInt32(timer.Opacity * 100);
            return this.ShowDialog();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.ParentTimer.Opacity = ((double)this.trackBar1.Value) * 0.01;
            this.Opacity = this.ParentTimer.Opacity;
        }
    }
}