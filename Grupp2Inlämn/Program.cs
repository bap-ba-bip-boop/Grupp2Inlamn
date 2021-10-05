using System;

namespace Grupp2Inlämn
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c = new Customer();
            Customer d = new Customer();

            Console.WriteLine(c.ChangeName("Jane Doe"));
            c.addAccount();//1001
            c.addAccount();//1002
            Console.WriteLine(c.GetInfoOnAllAccounts());

            d.addAccount();//1001? 1003
            d.addAccount();//1002? 1004
            d.addAccount();//1003? 1005
            Console.WriteLine(d.GetInfoOnAllAccounts());

            Console.WriteLine(d.GetInfo());
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