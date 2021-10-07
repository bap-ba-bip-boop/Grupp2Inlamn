using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp2Inlämn
{
    class SavingsAccount
    {
        //instansvariabel
        private decimal Amount;
        private decimal Interest;
        private string AccountType;
        private int AccountNr;

        //klassvariabel
        private static int AccountPool = 1001;

        public bool deposit(decimal depositAmount) 
        {
            bool correctAmount = false;
            if(depositAmount > 0)
            {
                this.Amount += depositAmount;
                correctAmount = true;
            }
            return correctAmount; 
            //kod deposit
       /*     this.Amount += depositAmount;
            Console.WriteLine("You deposited {0}kr", depositAmount);
            Console.WriteLine("Your current saldo is now {0}kr", this.Amount);*/

        }
        public void withdrawl(double withdrawlAmount) 
        {
            //kod för withdrawl
           // this.Amount -= withdrawlAmount;
            Console.WriteLine("You withdrew {0}kr", withdrawlAmount);
            Console.WriteLine("Your current saldo is now {0}kr", this.Amount);
        }
        public int getAccountID()
        {
            //returnar AccountNr till användaren(i detta fall BankLogic)
            return this.AccountNr;
        }
        public decimal getInterest() 
        {
            //returnar räntan till användaren(till BankLogic). ränta i kr
            return this.Amount*this.Interest/((decimal)100.0);
        }
        public string getInfo()
        {
            //returnerar parametrarna i följande ordning
            //(kontonummer, saldo, kontotyp, räntesats).
            return "Account ID: " + this.AccountNr + ", Amount: " + this.Amount + " kr, Account Type: " + this.AccountType + ", Interest Rate: " + this.Interest + " %";
        }
        public string getInfoWithInterest()
        {
            //returnerar parametrarna i följande ordning
            //(kontonummer, saldo, kontotyp, räntesats).
            return "Account ID: " + this.AccountNr + ", Amount: " + this.Amount + " kr, Account Type: " 
                + this.AccountType + ", Interest Rate: " + this.getInterest() + " kr";
        }

        public SavingsAccount()
        {
            this.AccountNr = AccountPool++; ;
            this.Amount = (decimal)1000.0;
            this.AccountType = "Sparkonto";
            this.Interest = (decimal)1.0;
        }
    }
}
