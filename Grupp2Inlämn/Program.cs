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

            bl.AddSavingsAccount(536528884646);
            int accountIDCheck = bl.AddSavingsAccount(436528884646);
            bl.AddSavingsAccount(554448884646);
            bl.AddSavingsAccount(554448884646);

            Console.WriteLine($"The id Returned is: {accountIDCheck}");

            if (wasSuccessful == true)
			{
				Console.WriteLine("Sjukt bra jobbat!");
			}

            List<string> customerInfo = bl.GetCustomer(554448884646);
			foreach (var entry in customerInfo)
			{
				Console.WriteLine(entry);
			}
            string accountInfo = bl.GetAccount(536528884646, 1001);
            Console.WriteLine("Här kommer pippilångstrump!");

            if(accountInfo == null)
            {
                Console.WriteLine("Account info not found! Wrong parameters entered.");
            }
            else
            {
                Console.WriteLine(accountInfo);
            }
            bl.Deposit(1001, 536528884646, (decimal)1337.00);
            accountInfo = bl.GetAccount(536528884646, 1001);
            Console.WriteLine("Här kommer pippilångstrump!");

            if (accountInfo == null)
            {
                Console.WriteLine("Account info not found! Wrong parameters entered.");
            }
            else
            {
                Console.WriteLine(accountInfo);
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


//         List<string> accountinfo = bl.GetCustomer(536528884646);
//         Console.WriteLine("Anna Bok");
//         foreach (var account in accountinfo)
//         {
//             Console.WriteLine(account);
//         }
//         bl.ChangeCustomerName("Kristoffer", 536528884646);
//         accountinfo = bl.GetCustomer(536528884646);
//         Console.WriteLine("Micke");
//         foreach (var account in accountinfo)
//         {
//             Console.WriteLine(account);
//         }
//         Console.WriteLine("Anna Bok");
//         List<string> removedCustomer = bl.RemoveCustomer(554448884646);
//foreach (var cust in removedCustomer)
//{
//	Console.WriteLine(cust);
//}
//         accountinfo = bl.GetCustomers();

//         foreach (var account in accountinfo)
//         {
//             Console.WriteLine(account);
//         }