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
    /// Shows a window with information about Timer
    /// </summary>
    public partial class About : TimerChild
    {
        /// <summary>
        /// Constructs a new About form
        /// </summary>
        public About(Timer timer)
            :base(timer)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the about window.
        /// </summary>
        private void closeAboutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}