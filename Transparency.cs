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

        public Transparency()
        {
            InitializeComponent();
        }

        public void ShowCustomDialog(Timer timer)
        {
            this.ParentTimer = timer;
            this.Opacity = timer.Opacity;
            this.trackBar1.Value = Convert.ToInt32(timer.Opacity * 100);
            this.Show();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.ParentTimer.Opacity = ((double)this.trackBar1.Value) * 0.01;
            this.Opacity = this.ParentTimer.Opacity;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}