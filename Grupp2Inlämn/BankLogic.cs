using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Grupp2Inlämn
{
    class BankLogic
    {
        private List<Customer> Customers;
               
        public List<string> GetCustomers() 
        {
			/*
			1. Skapa en list of string, "infoList"
			2. gå igenom customer listan
			3. för varje customer lägger vi in personuppgifter(namn + personnummer) i infoList
			 */
			List<string> infoList = new List<string>();
			foreach (var cust in this.Customers)
			{
                infoList.Add(cust.GetInfo());
			}
			return infoList;
        }

		public bool AddCustomer(string namn, long personnummer) 
		{
			/*
			1. Kolla om personnummer redan finns genom att loopa genom listan Customers
			2. Kolla personnummer på varje kund. 
			3. Om personnummer redan finns returneras false
			4. Om personnummer ej finns, skapa ny kund med det personnummret. Returnera True
			*/
			bool existingCustomer = false;

			foreach (var customer in this.Customers)
			{
				if (personnummer == customer.GetPersonnummer())
				{
					existingCustomer = true;
					break;
				}
			}
			if (existingCustomer == false)
			{
				this.Customers.Add(new Customer(namn, personnummer));
			}
			return !existingCustomer;
		}

		public BankLogic()
		{
			this.Customers = new List<Customer>();
		}
	
		public List<string> GetCustomer(long personnummmer) 
		{
			/*
			1. sök igenom this.customer listan efter matchande personnummer. 
			2. om vi finner ett matchande personnummer hos en customer lägger vi in all information i en lista. Returnera listan
			3. om vi inte finner ett matchande personnummer returneras null
			*/
			List<string> customerInfo = null;
			foreach (Customer cust in this.Customers)
            {
                if (personnummmer == cust.GetPersonnummer())
                {
					customerInfo = cust.GetInfoOnAllAccounts();
					break;
                }
            }
			return customerInfo;
		}

		public bool ChangeCustomerName(string changeName, long personnummer) 
		{
			/*
			1. sök igenom listan customers efter ett matchande personnummer tillhörande personen vars namn användaren vill ändra
			2. ifall man finner et matchande personnummer skickar man vidare det nya namnet till Customer.ChangeName
			3. Returnerar ifall man finner personen eller inte
			*/
			bool personIsFound = false;
			foreach (Customer cust in this.Customers) 
			{
				if (personnummer == cust.GetPersonnummer()) 
				{
					personIsFound = true; 
					cust.ChangeName(changeName);
				}
			}
			return personIsFound;
		}

		public List<string> RemoveCustomer(long personnummer) 
		{
			/*
			1. Kolla om personnummer finns i customerlistan
			2. Om kund inte finns returneras null
			3. Om kund finns, kalla på removeAllAccount(), Ta bort customerobjektet 
			4. return <List> all info om kund, konton, saldo + intjänad ränta.
			*/
			List<string> removedCustomerInfo = null;
			
				foreach (Customer cust in this.Customers)
				{
					if (personnummer == cust.GetPersonnummer())
					{
					removedCustomerInfo = cust.RemoveAllAccounts();
					this.Customers.Remove(cust);
					break;
					}
				}
			return removedCustomerInfo;
		}

		public int AddSavingsAccount(long personnummer)
        {
			/*
			1. Kollar igenom listan med Customers.
			2. Ifall vi finner en customer med samma personnummer ska vi lägga till sparkontot
			3. Annars om vi inte finner en customer med samma personnummer ska vi inte lägga till sparkontot
 
			*/
			int accountID = -1;

            foreach (Customer cust in this.Customers)
            {
				if(personnummer == cust.GetPersonnummer())
                {
					accountID = cust.AddAccount();
					break;
				}
            }
			return accountID;
        }

		public string GetAccount(long personnummer, int accountIDToFind)
		{
			/*
			1. Hitta rätt customer i customerList
			2. ifall en customer med matchande personnummer hittas kalla på Customer.Getaccount
			3. ifall ett konto hittas returneras dess info, annars returneras null
			4. om en customer inte hittas returneras null
			 */
			string accountInfo = null;

			foreach (Customer cust in this.Customers)
			{
				if (personnummer == cust.GetPersonnummer())
				{
					accountInfo = cust.GetAccount(accountIDToFind);
					break;
				}
			}
			return accountInfo;
		}

		public bool Deposit(int accountId, long personnummer, decimal amount)
		{
			/*
			1. Söker fram rätt kund baserat på pNr
			2. Sök fram rätt konto till kund baserat på accountId i Customer.FindAccountToDeposit
			3. returnerar false ifall funktionen inte finner en kund med matchande personnummer
			4. returnerar false ifall det är fel data längre ner i funktionshierarkin
			5. returnerar true om transaktionen är lyckad
			 */
			bool customerFound = false;
			foreach (var custom in Customers)
			{
				if (personnummer == custom.GetPersonnummer())
				{
					customerFound = custom.FindAccountToDeposit(accountId, amount);
				}
			}
			return customerFound;
		}

		public bool Withdraw(int accountId, long personnummer, decimal amount) 
		{
			/*
			1. Söker fram rätt kund baserat på pNr
			2. Sök fram rätt konto till kund baserat på accountId i Customer.FindAccountToWithdraw
			3. returnerar false ifall funktionen inte finner en kund med matchande personnummer
			4. returnerar false ifall det är fel data längre ner i funktionshierarkin
			5. returnerar true om transaktionen är lyckad
			 */
			bool customerFound = false;
			foreach (var custom in Customers)
			{
				if (personnummer == custom.GetPersonnummer())
				{
					customerFound = custom.FindAccountToWithdraw(accountId, amount);
				}
			}
			return customerFound;
		}
		
		public string CloseAccount(long personnummer, int accountID)
		{
			/*
			1. finner en kund med matchande personnummer till personnummret i parametrarna
			2. om vi inte finner en kund med matchande personnummer, returneras null
			3. annars om vi finner en kund med matchende personnummer, söker vi igenom dennes account efter matchande accountID i Customer.GetPersonnummer
			4. om vi inte finner ett account med matchende accountID, returneras null
			5. annars om vi finner ett account med matchende accountID, returnerar vi dess uppgifter i form av en sträng och tar bort kontot

			*/
			string accountInfo = null;

            foreach (Customer cust in this.Customers)
            {
				if(personnummer == cust.GetPersonnummer())
                {
					accountInfo = cust.CloseAccount(accountID);
					break;
                }
            }
			return accountInfo;
		}
		
		public void PrintToTextFile()
        {
			//1. Skriver ut all info i this.Customers till en textfil vars adress finns i variabeln 'path'
			string path = @"customers.txt";

			File.WriteAllLines(path, this.Customers.Select(customer => customer.GetInfo()));
		}
	}
}
