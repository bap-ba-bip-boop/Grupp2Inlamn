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
        public int GetAccountID()
        {
            return this.AccountNr;
        }
        public decimal GetInterest()
        {
            return this.Amount * this.Interest / ((decimal)100.0);
        }
        public string GetInfo()
        {
            return "Kontonummer: " + this.AccountNr + ", Summa: " + this.Amount + " kr, Kontotyp: " + this.AccountType + ", Sparränta: " + this.Interest + " %";
        }
        public string GetInfoWithInterest()
        {
            return "Kontonummer: " + this.AccountNr + ", Summa: " + this.Amount + " kr, Kontotyp: "
                + this.AccountType + ", Sparränta: " + this.GetInterest() + " kr";
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