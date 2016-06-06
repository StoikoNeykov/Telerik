namespace DefineClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GSM
    {
        // info: http://www.gsmarena.com/apple_iphone_6s_plus-7243.php
        private static GSM iPhone6Splus = new GSM("Iphone6Splus", "Apple",
            new Battery("2750mAh", BateryType.Li_Ion, 384, 24),
            new Display(5.5, 16000000));

        private string model;

        private string manifacturer;

        private double? price;

        private string owner;

        private Battery battery;

        private Display display;

        private List<Call> callHistory;

        public GSM(string model, string manifacturer)
        {
            this.Model = model;
            this.Manifacturer = manifacturer;
            this.callHistory = new List<Call>();
        }

        public GSM(string model, string manifacturer, Battery battery)
            : this(model, manifacturer)
        {
            this.Battery = battery;
        }

        public GSM(string model, string manifacturer, Display display)
            : this(model, manifacturer)
        {
            this.Display = display;
        }

        public GSM(string model, string manifacturer, string owner)
            : this(model, manifacturer)
        {
            this.Owner = owner;
        }

        // price require owner ! 
        public GSM(string model, string manifacturer, string owner, double price)
            : this(model, manifacturer, owner)
        {
            this.Price = price;
        }

        public GSM(string model, string manifacturer, Battery battery, Display display)
            : this(model, manifacturer, battery)
        {
            this.Display = display;
        }

        public GSM(string model, string manifacturer, string owner, double price, Battery battery, Display display)
            : this(model, manifacturer, owner, price)
        {
            this.Battery = battery;
            this.Display = display;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                this.model = value;
            }
        }

        public string Manifacturer
        {
            get
            {
                return this.manifacturer;
            }
            private set
            {
                this.manifacturer = value;
            }
        }

        public double Price
        {
            get
            {
                return (double)this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative number");
                }
                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
            private set
            {
                this.callHistory = value;
            }
        }

        public static GSM IPhone6Splus
        {
            get
            {
                return iPhone6Splus;
            }
        }

        public string Repair()
        {
            return "The device cannot be repaired. Just buy new.";
        }

        public override string ToString()
        {
            return String.Format("Model: {0}{1}Manifacturer: {2}{3}{4}{5}{6}{7}",
                this.model,
                Environment.NewLine,
                this.manifacturer,
                Environment.NewLine,
                this.price == null ? string.Empty : String.Format("Price: {0}{1}", this.price.ToString(), Environment.NewLine),
                this.owner == null ? string.Empty : String.Format("Owner: {0}{1}", this.owner.ToString(), Environment.NewLine),
                this.battery == null ? string.Empty : String.Format("Battery: {0} {1}{2}", Environment.NewLine, this.battery.ToString(), Environment.NewLine),
                this.display == null ? string.Empty : String.Format("Display: {0} {1}{2}", Environment.NewLine, this.display.ToString(), Environment.NewLine)
                ).Trim();
        }

        public void AddCall(Call curentCall)
        {
            this.callHistory.Add(curentCall);
        }

        public bool RemoveCall(Call curentCall)
        {
            foreach (Call call in callHistory)
            {
                if (curentCall.Equals(call))
                {
                    callHistory.Remove(call);
                    return true;
                }
            }

            return false;
        }

        public void ClearHistory()
        {
            this.callHistory.Clear();
        }

        public List<Call> CheckCalls()
        {
            // return diferent list with diferent objects 
            var result = this.callHistory
                .ConvertAll(x => new Call(x.DateTime, x.Contact, (int)x.Duration.TotalSeconds))
                .ToList();


            // return diferent list but with same objects
            // var result = this.callHistory      
            //    .Select(x => x)
            //    .ToList();


            // return same list
            // var result = callHistory;            
            return result;
        }

        public double CallsPrice(double pricePerMinute)
        {
            var total = this.CallHistory
                .Aggregate(TimeSpan.Zero, (sum, curentCall) => sum + curentCall.Duration)
                .TotalSeconds;

            return (total * pricePerMinute) / 60;
        }

        public void PrintCalls()
        {
            Console.WriteLine();
            Console.WriteLine("-------------List of calls-------------");
            Console.WriteLine();
            if (CallHistory.Count > 0)
            {
                foreach (Call call in CallHistory)
                {
                    Console.WriteLine(call.ToString());
                }
            }
            else
            {
                Console.WriteLine("No calls available!");
            }

            Console.WriteLine();
            Console.WriteLine("--------------End Of List--------------");
            Console.WriteLine();
        }

    }
}
