using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Timer
{
    public partial class ChangeTime : TimerChild
    {
        public ChangeTime(Timer timer)
            :base(timer)
        {
            InitializeComponent();
        }
    }
}