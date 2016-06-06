namespace DefineClass
{
    /// <summary>
    /// Special testing class -> finding QA in myself :D
    /// </summary>

    using System;
    public class GSMTest
    {
        public static void Test()
        {
            var phone1 = new GSM("MyModel", "MadeInTheGarage");
            var phone2 = GSM.IPhone6Splus;

            var bat = new Battery("5000mAh", BateryType.Li_Ion, 10, 10);
            var dis = new Display(5.5, 100);
            var phone3 = new GSM("MyAnotherModel", "Lenovo", "me", 50, bat, dis);

            var arr = new GSM[3] { phone1, phone2, phone3 };

            foreach (GSM phone in arr)
            {
                Console.WriteLine(phone.ToString());
                Console.WriteLine("----------------------------------------");
            }
        }

    }
}