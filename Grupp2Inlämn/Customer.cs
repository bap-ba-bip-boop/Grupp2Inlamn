﻿using System;
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
            //håller koll så att inga tomma strings assignas till Name
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
            return "Personal ID: " + this.Personnummer + ", Full Name: " + this.Name + "\n";
        }

        public List<string> RemoveAllAccounts()
        {
            //1.samlar all info alla accounts
            List<string> infoAboutAccounts = new List<string>();

            infoAboutAccounts.Add("Personal ID: " + this.Personnummer + ", Full Name: " + this.Name);

            foreach (SavingsAccount account in this.ListOfAccounts)
            {
                infoAboutAccounts.Add(account.GetInfoWithInterest());
            }
            this.ListOfAccounts.Clear();

            return infoAboutAccounts;
        }

        public List<string> GetInfoOnAllAccounts()
        {
            //returnerar Customers info i fomr av pNummer och för- och efternamn
            //följt avv alla dennes bankkonton
            List<string> returnInformation = new List<string>();
            returnInformation.Add("Personal ID: " + this.Personnummer + ", Full Name: " + this.Name);

            foreach (SavingsAccount account in this.ListOfAccounts)
            {
                returnInformation.Add(account.GetInfo());
            }

            return returnInformation;
        }

        public int AddAccount()
        {
            //Lägger till ett nytt konto i listOfAccounts or returnerar det nya kontots AccountID
            SavingsAccount newAccount = new SavingsAccount();
            this.ListOfAccounts.Add(newAccount);
            return newAccount.GetAccountID();
        }
        //public string removeAccount(int accountID)
        //{
        //    //1. finna ett account med rätt ID, om det finns. Annars returnerar vi null 
        //    //2. ifall vi finner ett account med rätt id, tar vi bort det och returnerar vi a 
        //
        //    string infoAboutAccount = null;
        //
        //    foreach (SavingsAccount account in this.listOfAccounts)
        //    {
        //        if(account.getAccountID() == accountID)
        //        {
        //            infoAboutAccount = account.getInfo();
        //            this.listOfAccounts.Remove(account);
        //            break;
        //        }
        //    }
        //    return infoAboutAccount;
        //}
        //public Customer()
        //{ 
        //    this.Name = "John Doe";
        //    this.Personnummer = 1234567890;
        //    this.listOfAccounts = new List<SavingsAccount>();

        //}
        public long GetPersonnummer()
        {
            return this.Personnummer;
        }

        public Customer(string name, long personNummer)
        {
            this.Name = name;
            this.Personnummer = personNummer;
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
                    //account.deposit(Amount);
                    accountFound = account.deposit(amount);
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
                    accountFound = account.withdraw(amount);
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