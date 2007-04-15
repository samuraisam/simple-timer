using System;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace Timer
{
    /// <summary>
    /// Implementation of TimerObject that counts down from a given hour/minute/second
    /// </summary>
    class CountdownTimer : TimerObject
    {
        private TimeSpan countdownFrom;
        private bool playedAlert;

        public CountdownTimer(Timer timer, int hours, int minutes, int seconds)
            : base(timer)
        {
            this.playedAlert = false;
            this.countdownFrom = new TimeSpan(hours, minutes, seconds);
            this.ParentTimer.timerMain.Tick += new EventHandler(this.CalculateTimeLeft);
        }

        public override string timerMain_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = this.Elapsed - this.countdownFrom;
            string neg = "-";
            if (ts >= (new TimeSpan(0, 0, 0)))
                neg = "+";
            return String.Format("{0}{1:00}:{2:00}:{3:00}.{4:00}",
                neg, Math.Abs(ts.Hours), Math.Abs(ts.Minutes),
                Math.Abs(ts.Seconds), Math.Abs(ts.Milliseconds) / 10);
        }

        private void CalculateTimeLeft(object sender, EventArgs e)
        {
            TimeSpan timeLeft = (this.Elapsed - this.countdownFrom);
            if (timeLeft >= (new TimeSpan(0, 0, 0)) &&  // negative TimeSpan
                !this.playedAlert)
            {
                SystemSounds.Exclamation.Play();
                this.playedAlert = true;
            }
        }
    }
}
