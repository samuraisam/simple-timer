using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Timer
{
    /// <summary>
    /// Adjusts the transparancy of ParentTimer
    /// </summary>
    public partial class Transparency : TimerChild
    {
        /// <summary>
        /// Creates a new Transparency form and sets it's value to that of
        /// ParetTimer
        /// </summary>
        public Transparency(Timer timer)
            : base(timer)
        {
            InitializeComponent();

            this.trackBar1.Value = (int)(timer.Opacity * 100.00);
        }

        /// <summary>
        /// Sets the Opacity of ParentTimer
        /// </summary>
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.ParentTimer.Opacity = ((double)this.trackBar1.Value) * 0.01;
        }

        /// <summary>
        /// Closes this window.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}