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

        public string removeAllAccounts()
        {
            //1.samlar all info alla accounts
            string infoAboutAccounts = null;

            infoAboutAccounts = "Personal ID: " + this.Personnummer + ", Full Name: " + this.Name + "\n";

            foreach (SavingsAccount account in this.listOfAccounts)
            {
                infoAboutAccounts += account.getInfo() + "\n";
            }
            this.listOfAccounts.Clear();

            return infoAboutAccounts;
        }

        public string GetInfoOnAllAccounts()
        {
            //returnerar Customers info i fomr av pNummer och för- och efternamn
            //följt avv alla dennes bankkonton
            string returnInformation = "";
            returnInformation = "Personal ID: " + this.Personnummer + ", Full Name: " + this.Name + "\n";

            foreach (SavingsAccount account in this.listOfAccounts)
            {
                returnInformation += account.getInfo() + "\n";
            }

            return returnInformation;
        }

        public void addAccount() 
        {
            this.listOfAccounts.Add(new SavingsAccount());
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
        public Customer()
        { 
            this.Name = "John Doe";
            this.Personnummer = 1234567890;
            this.listOfAccounts = new List<SavingsAccount>();
        }
    }
 }
