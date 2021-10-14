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
            /*
            1. Tar emot ett antal pengar i parametern 'depositAmount'
            2. Ifall antalet pengar är större än 0 lägger vi till det antalet pengar i den totala summan i 'Amount' och returnerar true
            3. Ifall antalet pengar är mindre eller lika med 0 så lägger metoden inte till pengarna och returnerar false
            */
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
            /*
            1. Tar emot ett antal pengar i parametern 'withdrawAmount'
            2. Ifall antalet pengar är större än 0 och mindre än den totala summan i 'Amount' tar man bort antalet pengar från 'Amount' och returnerar true
            3. Ifall antalet pengar är mindre eller lika med 0 eller är större än den totala summan i 'Amount' så tar metoden inte bort pengarna och returnerar false
            */
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
            //returnerar kontots unika ID som finns i 'AccountNr'
            return this.AccountNr;
        }
        public decimal GetInterest()
        {
            // returnerar ränta i kronor på summan pengar i 'Amount' med formeln (Amount*Interest/100)
            return this.Amount * this.Interest / ((decimal)100.0);
        }
        public string GetInfo()
        {
            // returnerar information om kontot(kontonummer, summa(i kr), Kontotypen och räntan(i %))
            return "Kontonummer: " + this.AccountNr + ", Summa: " + this.Amount + " kr, Kontotyp: " + this.AccountType + ", Sparränta: " + this.Interest + " %";
        }
        public string GetInfoWithInterest()
        {
            // returnerar information om kontot(kontonummer, summa(i kr), Kontotypen och räntan(i kr))
            return "Kontonummer: " + this.AccountNr + ", Summa: " + this.Amount + " kr, Kontotyp: "
                + this.AccountType + ", Sparränta: " + this.GetInterest() + " kr";
        }
        public SavingsAccount()
        {
            this.AccountNr = AccountPool++;
            this.Amount = (decimal)1000.0;
            this.AccountType = "Sparkonto";
            this.Interest = (decimal)1.0;
        }
    }
}