using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp2Inlämn
{
    class SavingsAccount
    {
        //instansvariabel
        private double Amount;
        private double Interest;
        private string AccountType;
        private int AccountNr;

        //klassvariabel
        private static int AccountPool = 1001;

        public void deposit(double depositAmount) 
        {
            //kod deposit
            this.Amount += depositAmount;
            Console.WriteLine("You deposited {0}kr", depositAmount);
            Console.WriteLine("Your current saldo is now {0}kr", this.Amount);
        }
        public void withdrawl(double withdrawlAmount) 
        {
            //kod för withdrawl
            this.Amount -= withdrawlAmount;
            Console.WriteLine("You withdrew {0}kr", withdrawlAmount);
            Console.WriteLine("Your current saldo is now {0}kr", this.Amount);
        }
        public int getAccountID()
        {
            //returnar AccountNr till användaren(i detta fall BankLogic)
            return this.AccountNr;
        }
        public double getInterest() 
        {
            //returnar räntan till användaren(till BankLogic). ränta i kr
            return this.Amount*this.Interest/100.0;
        }
        public string getInfo()
        {
            //returnerar parametrarna i följande ordning
            //(kontonummer, saldo, kontotyp, räntesats).
            return "Account ID: " + this.AccountNr + ", Amount: " + this.Amount + ", Account Type: " + this.AccountType + ", Interest Rate: " + this.Interest + " %";
        }

        public SavingsAccount()
        {
            this.AccountNr = AccountPool++; ;
            this.Amount = 1000.0;
            this.AccountType = "Sparkonto";
            this.Interest = 1.0;
        }
    }
}
