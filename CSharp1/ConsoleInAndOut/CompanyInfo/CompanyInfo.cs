using System;

    class CompanyInfo
    {
        static void Main()
        {
        string companyName = Console.ReadLine();
        string companyAddress = Console.ReadLine();
        string companyPhone = Console.ReadLine();
        string companyFax = Console.ReadLine();
        string companySite = Console.ReadLine();
        string managerFirstName = Console.ReadLine();
        string managerLasstName = Console.ReadLine();
        string managerAge = Console.ReadLine();
        string managerPhone = Console.ReadLine();
        if (companyFax.CompareTo(string.Empty)==0)
        {
            companyFax = "(no fax)";
        }
        Console.WriteLine(companyName);
        Console.WriteLine("Address: {0}", companyAddress);
        Console.WriteLine("Tel. {0}",companyPhone);
        Console.WriteLine("Fax: {0}",companyFax);
        Console.WriteLine("Web site: {0}",companySite);
        Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3})", managerFirstName, managerLasstName, managerAge, managerPhone);
        }
    }
