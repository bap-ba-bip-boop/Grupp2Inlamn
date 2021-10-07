using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp2Inlämn
{
    class Customer
    {
        private string Name;
        private long Personnummer;
        private List<SavingsAccount> listOfAccounts;

        public bool ChangeName(string newName)
        {
            //håller koll så att inga tomma strings assignas till Name
            bool stringIsEmpty = false;
            if(newName == "")
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

        public List <string> removeAllAccounts()
        {
            //1.samlar all info alla accounts
            List <string> infoAboutAccounts = new List<string>();

            infoAboutAccounts.Add("Personal ID: " + this.Personnummer + ", Full Name: " + this.Name);

            foreach (SavingsAccount account in this.listOfAccounts)
            {
                infoAboutAccounts.Add(account.getInfoWithInterest());
            }
            this.listOfAccounts.Clear();

            return infoAboutAccounts;
        }

        public List <string> GetInfoOnAllAccounts()
        {
            //returnerar Customers info i fomr av pNummer och för- och efternamn
            //följt avv alla dennes bankkonton
            List <string> returnInformation = new List<string>();
            returnInformation.Add("Personal ID: " + this.Personnummer + ", Full Name: " + this.Name);

            foreach (SavingsAccount account in this.listOfAccounts)
            {
                returnInformation.Add(account.getInfo());
            }

            return returnInformation;
        }

        public int addAccount() 
        {
            //Lägger till ett nytt konto i listOfAccounts or returnerar det nya kontots AccountID
            SavingsAccount newAccount = new SavingsAccount();
            this.listOfAccounts.Add(newAccount);
            return newAccount.getAccountID();
        }
        public string removeAccount(int accountID)
        {
            //1. finna ett account med rätt ID, om det finns. Annars returnerar vi null 
            //2. ifall vi finner ett account med rätt id, tar vi bort det och returnerar vi a 

            string infoAboutAccount = null;

            foreach (SavingsAccount account in this.listOfAccounts)
            {
                if(account.getAccountID() == accountID)
                {
                    infoAboutAccount = account.getInfo();
                    this.listOfAccounts.Remove(account);
                    break;
                }
            }
            return infoAboutAccount;
        }
        //public Customer()
        //{ 
        //    this.Name = "John Doe";
        //    this.Personnummer = 1234567890;
        //    this.listOfAccounts = new List<SavingsAccount>();

        //}
        public long getPersonnummer() 
        {
            return this.Personnummer;
        }

        public Customer(string name, long personnummer)
        {
            this.Name = name;
            this.Personnummer = personnummer;
            this.listOfAccounts = new List<SavingsAccount>();

        }
        public string getAccount(int accountID)
        {
            string accountInfo = null;

            foreach (var account in this.listOfAccounts)
            {
                if(accountID == account.getAccountID())
                {
                    accountInfo = account.getInfo();
                    break;
                }
            }
            return accountInfo;
        }
    }
 }
