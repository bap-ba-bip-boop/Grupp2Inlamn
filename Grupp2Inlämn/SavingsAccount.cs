using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp2Inlämn
{
    class SavingsAccount
    {
        private decimal Amount;
        private decimal Interest;
        private string AccountType;
        private int AccountNr;

        private static int AccountPool = 1001;
        public bool Deposit(decimal depositAmount)
        {
            bool correctAmount = false;
            if (depositAmount > 0)
            {
                this.Amount += depositAmount;
                correctAmount = true;
            }
            return correctAmount;
        }
        public bool Withdraw(decimal withdrawAmount)
        {
            bool correctAmount = false;
            if (withdrawAmount > 0 && withdrawAmount <= this.Amount)
            {
                this.Amount -= (decimal)withdrawAmount;
                correctAmount = true;
            }
            return correctAmount;
        }
        public int GetAccountID() // Returnar AccountNr till användaren(i detta fall BankLogic)
        {
            return this.AccountNr;
        }
        public decimal GetInterest() // Returnar räntan till användaren(till BankLogic). ränta i kr
        {
            return this.Amount * this.Interest / ((decimal)100.0);
        }
        public string GetInfo() // Returnerar parametrarna i följande ordning (kontonummer, saldo, kontotyp, räntesats).
        {
            return "Account ID: " + this.AccountNr + ", Amount: " + this.Amount + " kr, Account Type: " + this.AccountType + ", Interest Rate: " + this.Interest + " %";
        }
        public string GetInfoWithInterest() // Returnerar parametrarna i följande ordning (kontonummer, saldo, kontotyp, räntesats).
        {
            return "Account ID: " + this.AccountNr + ", Amount: " + this.Amount + " kr, Account Type: "
                + this.AccountType + ", Interest Rate: " + this.GetInterest() + " kr";
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