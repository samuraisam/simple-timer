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

        // re-declare reset, start and stop so we can override them in child classes
        // as far as C# is considered... this is wicked bad
        public virtual new void Reset() { base.Reset(); }
        public virtual new void Start() { base.Start(); }
        public virtual new void Stop() { base.Stop(); }
    }
}