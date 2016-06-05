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

            var curentList = phone.CheckCalls();
            Console.WriteLine("--------Calls List--------");
            Console.WriteLine();
            foreach (Call call in curentList)
            {
                Console.WriteLine(call.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("--------End Of List--------");
            Console.WriteLine();
            Console.WriteLine("Total Price: {0:f2}", phone.CallsPrice(0.37));

            var longestCall = curentList.
                OrderByDescending(x => x.Duration)
                .FirstOrDefault();
            phone.RemoveCall(longestCall);

            Console.WriteLine("Longest call was removed");

            Console.WriteLine("Total Price: {0:f2}", phone.CallsPrice(0.37));

            phone.ClearHistory();
            curentList = phone.CheckCalls();
            Console.WriteLine();
            Console.WriteLine("--------Calls List--------");
            if (curentList.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("No calls available!");
                Console.WriteLine();
            }
            else
            {
                foreach (Call call in curentList)
                {
                    Console.WriteLine(call.ToString());
                }
            }
            Console.WriteLine("--------End Of List--------");
            Console.WriteLine();

        }
    }
}
