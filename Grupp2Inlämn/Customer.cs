using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp2Inlämn
{
    class Customer
    {
        private string Name;
        private long Personnummer;
        private List<SavingsAccount> ListOfAccounts;

        public bool ChangeName(string newName)
        {
            /* 
            1. Tar emot en variabel 'newName'
            2. ifall 'newName' är tomt kommer namnet inte att ändras. Funktionen returnerar false
            3. ifall 'newName' har något i den kommer namnet som finns i 'Name' att ändras. Funktionen returnerar true
            */
            bool stringIsEmpty = false;
            if (newName == "")
            {
                stringIsEmpty = true;
            }
            else
            {
                this.Name = newName;
            }
            return !stringIsEmpty;
        }
        public string GetInfo()
        {
            /*
            1. Returnerar kundens namn och personnummer som finns i 'Personnummer och Name'
            */
            return "Personnummer: " + this.Personnummer + ", Namn: " + this.Name + "\n";
        }

        public List<string> RemoveAllAccounts()
        {
            /*
            1. lägger till kundens personuppgifter längst upp i listan 'infoAboutAccounts'
            2. går igenom alla kundens bankkonton
            3. för varje bankkonto lägger funktionen till kontoinfo för alla konton som stängs i listan 'infoAboutAccounts'
            4. när alla kontons information har samlats i listan tar man bort alla konton med 'List<T>.clear'
            5. returnera 'infoAboutAccounts'
            */
            List<string> infoAboutAccounts = new List<string>();

            infoAboutAccounts.Add("Personnummer: " + this.Personnummer + ", Namn: " + this.Name);

            foreach (SavingsAccount account in this.ListOfAccounts)
            {
                infoAboutAccounts.Add(account.GetInfoWithInterest());
            }
            this.ListOfAccounts.Clear();

            return infoAboutAccounts;
        }

        public List<string> GetInfoOnAllAccounts()
        {
            /*
            1. lägger till kundens personuppgifter längst upp i listan 'returnInformation'
            2. går igenom alla kundens bankkonton
            3. för varje bankkonto lägger funktionen till kontoinfo för alla konton i listan 'returnInformation'
            4. när alla kontons information har samlats i listan returneras 'returnInformation'
            */
            List<string> returnInformation = new List<string>();
            returnInformation.Add("Personnummer: " + this.Personnummer + ", Namn: " + this.Name);

            foreach (SavingsAccount account in this.ListOfAccounts)
            {
                returnInformation.Add(account.GetInfo());
            }

            return returnInformation;
        }

        public int AddAccount()
        {
            /*
            1. Skapar ett nytt konto i variabeln 'newAccount'
            2. Lägger till 'newAccount' i 'ListOfAccounts'
            3. returnerar id till 'newAccount'
            */
            SavingsAccount newAccount = new SavingsAccount();
            this.ListOfAccounts.Add(newAccount);
            return newAccount.GetAccountID();
        }
        public long GetPersonnummer()
        {
            //returnerar kundens personnummer
            return this.Personnummer;
        }

        public Customer(string name, long personnummer)
        {
            this.Name = name;
            this.Personnummer = personnummer;
            this.ListOfAccounts = new List<SavingsAccount>();

        }
        public string GetAccount(int accountID)
        {
            /*
            1. Går igenom varje account i 'ListOfAccounts'
            2. Letar efter ett konto med matchande AccountID till parametern 'accountID'
            3. ifall ett konto med matchande account id hittas hämtar man info från kontot med SavingsAccount.GetInfo
            4. om matchande konto inte hittas returneras null
            5. om matchande konto hittas returneras dess information
            */
            string accountInfo = null;

            foreach (var account in this.ListOfAccounts)
            {
                if (accountID == account.GetAccountID())
                {
                    accountInfo = account.GetInfo();
                    break;
                }
            }
            return accountInfo;
        }

        public bool FindAccountToDeposit(int accountID, decimal amount)
        {
            /*
            1. Går igenom varje account i 'ListOfAccounts'
            2. Letar efter ett konto med matchande AccountID till parametern 'accountID'
            3. ifall ett konto med matchande account id hittas anropar man SavingsAccount.Deposit för att sätta in pengar
            4. om matchande konto inte hittas returneras false
            5. om matchande konto hittas returneras boolean värdet från SavingsAccount.Deposit
            */
            bool accountFound = false;
            foreach (var account in ListOfAccounts)
            {
                if (accountID == account.GetAccountID())
                {
                    accountFound = account.Deposit(amount);
                }
            }
            return accountFound;
        }
        public bool FindAccountToWithdraw(int accountID, decimal amount)
        {
            /*
            1. Går igenom varje account i 'ListOfAccounts'
            2. Letar efter ett konto med matchande AccountID till parametern 'accountID'
            3. ifall ett konto med matchande account id hittas anropar man SavingsAccount.Withdraw för att ta ut pengar
            4. om matchande konto inte hittas returneras false
            5. om matchande konto hittas returneras boolean värdet från SavingsAccount.Withdraw
            */
            bool accountFound = false;
            foreach (var account in ListOfAccounts)
            {
                if (accountID == account.GetAccountID())
                {
                    accountFound = account.Withdraw(amount);
                }
            }
            return accountFound;
        }
        public string CloseAccount(int accountID)
        {
            /*
            1. Går igenom varje account i 'ListOfAccounts'
            2. Letar efter ett konto med matchande AccountID till parametern 'accountID'
            3. ifall ett konto med matchande account id hittas hämtar man dess information med SavingsAccount.GetInfoWithInterest som sparas i 'accountInfo'.
            3,5. kontot tas sedan bort
            4. om matchande konto inte hittas returneras null
            5. om matchande konto hittas returneras info i 'accountInfo'
            */
            string accountInfo = null;

            foreach (SavingsAccount account in this.ListOfAccounts)
            {
                if (accountID == account.GetAccountID())
                {
                    accountInfo = account.GetInfoWithInterest();
                    this.ListOfAccounts.Remove(account);
                    break;
                }
            }
            return accountInfo;
        }
    }
}