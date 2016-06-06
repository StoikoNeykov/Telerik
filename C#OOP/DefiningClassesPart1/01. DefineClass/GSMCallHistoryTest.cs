namespace DefineClass
{
    using System;
    using System.Linq;

    public class GSMCallHistoryTest
    {
        public static void Test()
        {
            var phone = new GSM("MyPhone", "Apple");

            phone.AddCall(new Call(DateTime.Now, "Pesho", 45));
            phone.AddCall(new Call(DateTime.Now, "Ivan", 18));
            phone.AddCall(new Call(DateTime.Now, "Gosho", 80));

            // phone.PrintCalls();
            Console.WriteLine(phone.CallsToString());

            Console.WriteLine("Total Price: {0:f2}", phone.CallsPrice(0.37));

            var longestCall = phone
                .CheckCalls()
                .OrderByDescending(x => x.Duration)
                .FirstOrDefault();

            if (phone.RemoveCall(longestCall))
            {
                Console.WriteLine("Longest call was removed");
            }
            else
            {
                // if cant remove longest call then probably list is empty 
                Console.WriteLine("Are you sure there are calls in phone call history?");
            }


            Console.WriteLine("Total Price: {0:f2}", phone.CallsPrice(0.37));

            phone.ClearHistory();

            //phone.PrintCalls();
            Console.WriteLine(phone.CallsToString());
        }
    }
}
