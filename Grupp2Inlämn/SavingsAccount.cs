using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp2Inlämn
{
    class SavingsAccount
    {
        private double Saldo;
        private double Interest;
        private string AccountType;
        private int Kontonummer;

        public void deposit(double depositAmount) 
        {
            //kod deposit
            this.Saldo += depositAmount;
            Console.WriteLine("You deposited {0}$", depositAmount);
            Console.WriteLine("Your current saldo is now {0}$", Saldo);
        }
        public void withdrawl(double withdrawlAmount) 
        {
            //kod withdrawl
            this.Saldo -= withdrawlAmount;
            Console.WriteLine("You withdrew {0}$", withdrawlAmount);
            Console.WriteLine("Your current saldo is now {0}$", Saldo);
        }
        public void getAccountNum() { }
        public void getInterest() { }
        public void getInfo() { }

    }
}
