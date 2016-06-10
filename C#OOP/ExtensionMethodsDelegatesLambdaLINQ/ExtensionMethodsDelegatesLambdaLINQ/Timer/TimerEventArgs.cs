namespace ExtensionMethodsDelegatesLambdaLINQ.Timer
{
    using System;
    /// <summary>
    /// Event Args
    /// </summary>
    public class TimerEventArgs : EventArgs
    {
        public TimerEventArgs()
        {
            this.Time = DateTime.Now;
        }

        public DateTime Time { get; private set; }
    }
}
