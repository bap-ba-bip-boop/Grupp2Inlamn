using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp2Inlämn
{
    class BankLogic
    {
        private List<Customer> Customers;
       
        /*
         Returnerar en List<string> som innehåller en presentation av bankens alla kunder (personnummer
och namn).
        */
        public List<string> GetCustomers() 
        {
            //1. Skapa en list of string, "infoList"
            //2. foreach genom customer listan
            //3. för varje customer lägger vi in personuppgifter i infoList
            
            List<string> infoList = new List<string>();
			foreach (var cust in this.Customers)
			{
                infoList.Add(cust.GetInfo());
			}

            return infoList;

        }

		//	Skapar upp en ny kund med namnet name samt personnumer pNr, kunden skapas endast om det
		//inte finns någon kund med personnummer pNr.Returnerar true om kund skapades annars
		//returneras false.
		public bool AddCustomer(string namn, long personnummer) 
		{
			// 1. Kolla om personnummer redan finns genom att loopa genom <Customers>
			// 2. Kolla personnummer på varje kund. 
			// 3. Om personnummer redan finns returneras false
			// 4. Om pnr ej finns, skapa kund. Returnera True

			bool existingCustomer = false;

			foreach (var customer in this.Customers)
			{
				if (personnummer == customer.getPersonnummer())
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
		/*Returnerar en List<string> som innehåller informationen om kunden inklusive dennes konton.
Första platsen i listan är förslagsvis reserverad för kundens namn och personnummer sedan följer
informationen om kundens konton.*/
		
		public List<string> GetCustomer(long Personnummmer) 
		{
			//Steg 1 söka igenom this.customer listan efter matchande personnummer. 
			//Steg 2 lägger in all information i en lista.
			//Steg 3 returnera listan.
			List<string> customerInfo = new List<string>();
			foreach (Customer cust in this.Customers)
            {
                if (Personnummmer == cust.getPersonnummer())
                {
					customerInfo = cust.GetInfoOnAllAccounts();
					break;
                }
            }
			return customerInfo;
		}

		/*Byter namn på kund med personnummer pNr till name, returnerar true om namnet ändrades annars
returnerar false (om kunden inte fanns).*/
		public bool ChangeCustomerName(string changeName, long Personnummer) 
		{
			bool PersonisFound = false; //Ändra stor bokstav i variabelnamn
			foreach (Customer cust in this.Customers) 
			{
				if (Personnummer == cust.getPersonnummer()) 
				{
					PersonisFound = true; //Ändra stor bokstav i variabelnamn
					cust.ChangeName(changeName);
				}
			}
			return PersonisFound; //Ändra stor bokstav i variabelnamn
		}

		/*Tar bort kund med personnummer pNr ur banken, alla kundens eventuella konton tas också bort
		och resultatet returneras. Listan som returneras ska innehålla information om alla konton som togs
		bort, saldot som kunden får tillbaka samt vad räntan blev.*/
		public List<string> RemoveCustomer(long personnummer) 
		{
			// 1. Kolla om personnr finns i customerlistan
			// 2. Om kund inte finns; break;
			// 3. Om kund finns, kalla på removeAllAccount() 
			// 4. Ta bort customerobjektet
			// 5. return <List> all info om kund, konton, saldo + intjänad ränta.

			List<string> removedCustomerInfo = new List<string>();
			
				foreach (Customer cust in this.Customers)
				{
					if (personnummer == cust.getPersonnummer())
					{
					removedCustomerInfo = cust.removeAllAccounts();
					this.Customers.Remove(cust);
					break;
				}
				}
			return removedCustomerInfo;
		}

		/*Skapar ett konto till kund med personnummer pNr, returnerar kontonumret som det skapade kontot
		fick alternativt returneras –1 om inget konto skapades.*/
		public int AddSavingsAccount(long personNummer)
        {
			//1. Kollar igenopm listan med Customers.
			//2. Ifall vi finner en customer med samma personnummer ska vi inte lägga till sparkontot
			//3. Annars om vi inte finner en customer med samma personnummer ska vi lägga till sparkontot
			int accountID =  -1;

            foreach (Customer cust in this.Customers)
            {
				if(personNummer == cust.getPersonnummer())
                {
					accountID = cust.addAccount();
					break;
				}
            }

			return accountID;
        }

        /*Returnerar en String som innehåller presentation av kontot med kontonummer accountId som tillhör
		kunden pNr (kontonummer, saldo, kontotyp, räntesats).*/
        public string GetAccount(long personnummer, int accountIDToFind)
        {
			//1. Hitta rätt customer i customerList
			//2. Hitta customers accounts i listOfAccounts
			//3. Om vi hittar rätt pers/account returnera string med accountInfo
			string accountInfo = null;

			foreach (Customer cust in this.Customers)
            {
				if (personnummer == cust.getPersonnummer())
                {
					accountInfo = cust.getAccount(accountIDToFind);
					break;
                }
			}
			return accountInfo;
		}

		/*Gör en insättning på konto med kontonummer accountId som tillhör kunden pNr, returnerar true om
        det gick bra annars false..*/
		// Steg 1: Söker fram rätt kund baserat på pNr
		//Steg 2: Sök fram rätt konto till kund baserat på accountId.
		// Steg 3: Skapar en kontroll som säger ifrån om summan =0 eller <0
		// Steg 4: Använd deposit metoden i SavingsAccount för att sätta in en specifik summa i kontot
		public bool Deposit(int accountId,long personnummer, decimal amount) 
		{
			bool customerFound = false; 
            foreach (var custom in Customers)
            {
				if(personnummer == custom.getPersonnummer())
                {
					customerFound = custom.findAccountToDeposit(accountId, amount);
                }
            }
			return customerFound;
		}



		/*Gör ett uttag på konto med kontonummer accountId som tillhör kunden pNr, returnerar true om det
		gick bra annars false*/
		// Steg 1: Söker fram rätt kund baserat på pNr.
		//Steg 2: Sök fram rätt konto till kund baserat på accountId.
		// Steg 3: Skapar en kontroll som säger ifrån om summan = 0 eller < 0.
		// Steg 4: Använd Withdraw metoden i SavingsAccount för att ta ut en specifik summa i kontot.
		public bool Withdraw(int accountId, long personnummer, decimal amount) 
		{
			bool customerFound = false;
			foreach (var custom in Customers)
			{
				if (personnummer == custom.getPersonnummer())
				{
					customerFound = custom.findAccountToWithdraw(accountId, amount);
				}
			}
			return customerFound;
		}
		/*Stänger ett konto med kontonummer accountId som tillhör kunden pNr, presentation av kontots
saldo samt ränta på pengarna ska genereras.*/
		public string CloseAccount(long personNummer, int accountID)
		{
			// 1. finner en kund med matchande personnummer till personnummret i parametrarna
			// 2. om vi inte finner en kund med matchande personnummer, returneras null
			// 3. annars om vi finner en kund med matchende personnummer, söker vi igenom dennas account efter matchende accountID
			// 4. om vi inte finned ett account med matchende accountID, returneras null
			// 5. annars om vi finner ett account med matchende accountID, returnerar vi dess uppgifter i form av en sträng
			// 6. och tar bort kontot
			string accountInfo = null;

            foreach (Customer cust in this.Customers)
            {
				if(personNummer == cust.getPersonnummer())
                {
					accountInfo = cust.closeAccount(accountID);
					break;
                }
            }

			return accountInfo;
		}

	}
}
