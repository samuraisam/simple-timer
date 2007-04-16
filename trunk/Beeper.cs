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
            this.lastPlayed = DateTime.Now;
            
            this.ParentTimer.timerMain.Tick += new EventHandler(this.timerMain_Tick);
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            if (this.ParentTimer.timerObject.IsRunning)
            {
                TimeSpan ts = this.ParentTimer.timerObject.Elapsed;
                bool canPlay = (DateTime.Now - this.lastPlayed).Minutes >= this.interval; // only play once every interval
                if (ts.Minutes % this.interval == 0 && canPlay && ts.Minutes != 0)
                    this.Alert();
            }
        }

        private void Alert()
        {
            SystemSounds.Exclamation.Play();
            this.lastPlayed = DateTime.Now;
        }
    }
}
