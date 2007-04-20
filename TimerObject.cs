using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Timer
{
    /// <summary>
    /// A Serializable base class for objects that track time.
    /// </summary>
    [Serializable()]
    public abstract class TimerObject : Stopwatch, ISerializable
    {
        protected Timer ParentTimer;
        
        /// <summary>
        /// Used for starting a TimerObject with a pre-defined offset
        /// </summary>
        public TimeSpan Offset;

        /// <summary>
        /// Gets the total elapsed time measured by the current instance.
        /// </summary>
        public new virtual TimeSpan Elapsed
        {
            get
            {
                return base.Elapsed + this.Offset;
            }
        }

        /// <summary>
        /// Sets the ParentTimer (used for waking up from serialization)
        /// </summary>
        public Timer Timer
        {
            set
            {
                this.ParentTimer = value;
            }
        }

        /// <summary>
        /// Creates a new TimerObject object
        /// </summary>
        /// <param name="timer"></param>
        public TimerObject(Timer timer)
            : base()
        {
            this.ParentTimer = timer;
            this.Offset = new TimeSpan();
        }

        /// <summary>
        /// Wake a TimerObject up from sleep
        /// REMEMBER: Still need to set instance.Timer upon wakeup!
        /// </summary>
        public TimerObject(SerializationInfo info, StreamingContext context)
            : base()
        {
            this.Offset = (TimeSpan)info.GetValue("TimerOffset", typeof(TimeSpan));
        }

        /// <summary>
        /// Go to sleep
        /// </summary>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TimerOffset", this.Elapsed);
        }

        /// <summary>
        /// Ran every time timerMain ticks. Should return whatever the ParentTimer
        /// wants to display in it's main time display.
        /// </summary>
        /// <param name="sender">Probably a Timer</param>
        /// <param name="e">EventArgs from timerMain</param>
        /// <returns>String representing the current display.</returns>
        abstract public string timerMain_Tick(object sender, EventArgs e);

        // re-declare reset, start and stop so we can override them in child classes
        // as far as C# is considered... this is wicked bad
        public virtual new void Reset() { base.Reset(); this.Offset = new TimeSpan(); }
        public virtual new void Start() { base.Start(); }
        public virtual new void Stop() { base.Stop(); }
    }
}