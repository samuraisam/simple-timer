using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Timer
{

    /// <summary>
    /// Implementation of TimerObject that provides a very simple lap timer.
    /// </summary>
    [Serializable()]
    public class LapTimer : TimerObject
    {
        public LapTimer(Timer timer)
            : base(timer)
        {
        }

        public LapTimer(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override string timerMain_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = this.Elapsed;
            return String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        }
    }
}
