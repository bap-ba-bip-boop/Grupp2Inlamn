using System;
using System.Collections.Generic;

namespace Grupp2Inlämn
{
    class Program
    {
        static void Main(string[] args)
        {

            BankLogic bl = new BankLogic();
            bool wasSuccessful = bl.AddCustomer("Fredrik", 554448884646);
            bl.AddCustomer("Pierre", 536528884646);
            bl.AddCustomer("Fredrik", 554448884646);
            if (wasSuccessful == true)
			{
				Console.WriteLine("Sjukt bra jobbat!");
			}

            List<string> customerInfo = bl.GetCustomers();
			foreach (var entry in customerInfo)
			{
				Console.WriteLine(entry);
			}
            List<string> accountinfo = bl.GetCustomer(536528884646);
            Console.WriteLine("Anna Bok");
            foreach (var account in accountinfo)
            {
                Console.WriteLine(account);
            }
            bl.ChangeCustomerName("Kristoffer", 536528884646);
            accountinfo = bl.GetCustomer(536528884646);
            Console.WriteLine("Micke");
            foreach (var account in accountinfo)
            {
                Console.WriteLine(account);
            }
        }
    }
}
//SavingsAccount sa = new SavingsAccount();
//
////Console.WriteLine(sa.getInfo());
//sa.deposit(3000.0);
////Console.WriteLine(sa.getInfo());
//sa.withdrawl(500.0);
////Console.WriteLine(sa.getInfo());
//
//Console.WriteLine($"Account ID: {sa.getAccountNum()}");
//Console.WriteLine($"Interest: {sa.getInterest()}");

//string info = d.removeAccount(1003);
//if (info != null)
//{
//    Console.WriteLine("Account was successfully deleated");
//    Console.WriteLine(info);
//}
//else
//{
//    Console.WriteLine("The account was not removed. No such ID exists");
//}
//Console.WriteLine(d.GetInfo());