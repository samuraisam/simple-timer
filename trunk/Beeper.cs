using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Media;

namespace Timer
{
    class Beeper
    {
        private Timer ParentTimer;
        private int interval;
        private DateTime lastPlayed;

        public Beeper(Timer timer, int _interval)
        {
            this.ParentTimer = timer;
            this.interval = _interval;
            
            this.ParentTimer.timerMain.Tick += new EventHandler(this.timerMain_Tick);
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = this.ParentTimer.timerObject.Elapsed;
            bool canPlay = (DateTime.Now - this.lastPlayed).Seconds >= 1; // only play once every second
            if (ts.Minutes % this.interval == 0 && canPlay)
                this.Alert();
        }

        private void Alert()
        {
            SystemSounds.Exclamation.Play();
            this.lastPlayed = DateTime.Now;
        }
    }
}
