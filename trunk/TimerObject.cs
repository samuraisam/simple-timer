using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Timer
{
    public abstract class TimerObject : Stopwatch
    {
        protected Timer ParentTimer;

        abstract public string timerMain_Tick(object sender, EventArgs e);

        public TimerObject(Timer timer)
            : base()
        {
            this.ParentTimer = timer;
        }
    }
}