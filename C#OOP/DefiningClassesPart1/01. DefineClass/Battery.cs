namespace DefineClass
{
    using System;

    /// <summary>
    /// Mobile phone battery. Fields are nullable
    /// </summary>
    public class Battery
    {
        // not rly sure how to understand battery model - make it string but will put mAh inside for now
        private string model;

        private int? hoursIdle;

        private int? hoursTalk;

        private BateryType? bateryType;

        public Battery(BateryType batteryType)
        {
            this.BatteryType = batteryType;
        }

        public Battery(string model)
        {
            this.Model = model;
        }

        public Battery(string model, BateryType batteryType)
            : this(model)
        {
            this.BatteryType = batteryType;
        }

        public Battery(string model, BateryType batteryType, int hoursIdle, int hoursTalk)
            : this(model, batteryType)
        {
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
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

        public BateryType BatteryType
        {
            get
            {
                return (BateryType)this.bateryType;
            }

            set
            {
                this.bateryType = value;
            }
        }

        public int HoursIdle
        {
            get
            {
                return (int)this.hoursIdle;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("HoursIdle cannot be negative number, if battery is damaged or not working please you Repair()");
                }

                this.hoursIdle = value;
            }
        }

        public int HoursTalk
        {
            get
            {
                return (int)this.hoursTalk;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("HoursTalk cannot be negative number, if battery is damaged or not working please use Repair()");
                }

                this.hoursTalk = value;
            }
        }

        // this method is just a joke 
        public void Repair()
        {
            throw new InvalidOperationException("Please do not try to repair battery. It may contains acids or other biohazard materials");
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}",
                this.model == null ? string.Empty : string.Format("BatteryModel: {0}{1}", this.model.ToString(), Environment.NewLine),
                this.bateryType == null ? string.Empty : string.Format("BatteryType: {0}{1}", this.bateryType.ToString(), Environment.NewLine),
                this.hoursIdle == null ? string.Empty : string.Format("HoursIdle: {0}{1}", this.hoursIdle.ToString(), Environment.NewLine),
                this.hoursTalk == null ? string.Empty : string.Format("HoursTalk: {0}", this.hoursTalk.ToString())).Trim();
        }
    }
}