namespace ExtensionMethodsDelegatesLambdaLINQ.Timer
{
    using System;

    /// <summary>
    /// Testing events - subscriber
    /// </summary>
    public class Subscriber
    {
        public int Counter { get; private set; }

        public int MaxCounter { get; set; }

        public Subscriber()
        {
            this.Counter = 0;
        }

        public Subscriber(int maxCounter)
            : this()
        {
            this.MaxCounter = maxCounter;
        }

        public void Listen(Timer timer)
        {
            timer.Task += OnTask;
        }

        public void StopListen(Timer timer)
        {
            timer.Task -= OnTask;
            Console.WriteLine($"{this.MaxCounter} seconds passed! Listeing stopped!");
            Console.WriteLine("If that was last listener you can stop program with Ctrl+C");
        }

        public void OnTask(object sender, TimerEventArgs ev)
        {
            this.Counter++;
            Console.WriteLine($"Just another second passed! Total count:{this.Counter}");
            Console.WriteLine("Time is {0:hh.mm.ss}", ev.Time);
            Console.WriteLine();
            if (this.Counter == MaxCounter)
            {
                StopListen((Timer)sender);
            }
        }
    }
}
