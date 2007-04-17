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
    /// Shows a window that is meant to be modal and gets an un-checked value from
    /// the user.
    /// </summary>
    public partial class NameTimer : TimerChild
    {
        /// <summary>
        /// Makes a new NameTimer form.
        /// </summary>
        public NameTimer(Timer timer)
            : base(timer)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Returns whatever the user supplied or is supplying.
        /// </summary>
        /// <returns>nameField text</returns>
        public string GetNameValue()
        {
            return this.nameField.Text;
        }

        /// <summary>
        /// Brings NameTimer to focus.
        /// </summary>
        private void NameTimer_Load(object sender, EventArgs e)
        {
            this.nameField.Focus();
        }
    }
}