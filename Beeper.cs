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

        /// <summary>
        /// Start a new beeper object.
        /// </summary>
        /// <param name="timer">The timer to attach this beeper to.</param>
        /// <param name="_interval">How often, in minutes, to beep.</param>
        public Beeper(Timer timer, int _interval)
        {
            this.ParentTimer = timer;
            this.interval = _interval;
            this.lastPlayed = DateTime.Now;
            
            this.ParentTimer.timerMain.Tick += new EventHandler(this.timerMain_Tick);
        }

        /// <summary>
        /// Beep if it's time.
        /// </summary>
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

        /// <summary>
        /// Play an alert for the user.
        /// </summary>
        private void Alert()
        {
            SystemSounds.Exclamation.Play();
            this.lastPlayed = DateTime.Now;
        }

        /// <summary>
        /// Because of garbage collection, some times we need to tell to explicitly
        /// tell beepers to stop sending an alert. This provides that functionatlity.
        /// </summary>
        public void StopAlerting()
        {
            this.ParentTimer.timerMain.Tick -= new EventHandler(this.timerMain_Tick);
        }
    }
}
