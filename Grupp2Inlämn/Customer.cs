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
            return "Personnummer: " + this.Personnummer + ", Namn: " + this.Name + "\n";
        }

        public List<string> RemoveAllAccounts()
        {
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
            SavingsAccount newAccount = new SavingsAccount();
            this.ListOfAccounts.Add(newAccount);
            return newAccount.GetAccountID();
        }
        public long GetPersonnummer()
        {
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