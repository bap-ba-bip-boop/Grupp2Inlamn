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

            //Console.WriteLine("Presentera person 1");
            //List<string> customerInfo = bl.GetCustomer(536528884646);
            //customerInfo.ForEach(Console.WriteLine);
            //
            //Console.Read();
            //
            //Console.WriteLine("Presentera person 2");
            //customerInfo = bl.GetCustomer(554448884646);
            //customerInfo.ForEach(Console.WriteLine);

            bl.printToTextFile();
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