using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp2Inlämn
{
    class SavingsAccount
    {
        private double Amount;
        private double Interest;
        private string AccountType;
        private int AccountNr;

        public void deposit() { }//Pierre o niklas
        public void withdraw() { }//Pierre o niklas
        public int getAccountNum()
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
            return this.AccountNr + ", " + this.Amount + ", " + this.AccountType + ", " + this.Interest;
        }

        public SavingsAccount()
        {
            this.AccountNr = 1001;
            this.Amount = 1000.0;
            this.AccountType = "Sparkonto";
            this.Interest = 1.0;
        }
    }
}
