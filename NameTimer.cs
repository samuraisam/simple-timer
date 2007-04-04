using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Timer
{
    public partial class NameTimer : Form
    {
        public NameTimer()
        {
            InitializeComponent();
        }

        public string GetNameValue()
        {
            return this.nameField.Text;
        }

        private void NameTimer_Load(object sender, EventArgs e)
        {
            this.nameField.Focus();
        }
    }
}