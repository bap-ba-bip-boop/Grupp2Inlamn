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

		/*Tar bort kund med personnummer pNr ur banken, alla kundens eventuella konton tas också bort
och resultatet returneras. Listan som returneras ska innehålla information om alla konton som togs
bort, saldot som kunden får tillbaka samt vad räntan blev.*/
		//public bool ChangeCustomerName() { }

		//        /*Tar bort kund med personnummer pNr ur banken, alla kundens eventuella konton tas också bort
		//och resultatet returneras. Listan som returneras ska innehålla information om alla konton som togs
		//bort, saldot som kunden får tillbaka samt vad räntan blev.*/
		//        //public List<string> RemoveCustomer() { }

		//        /*Tar bort kund med personnummer pNr ur banken, alla kundens eventuella konton tas också bort
		//och resultatet returneras. Listan som returneras ska innehålla information om alla konton som togs
		//bort, saldot som kunden får tillbaka samt vad räntan blev.*/
		//        public int AddSavinsAccount() { }

		//        /*Returnerar en String som innehåller presentation av kontot med kontonummer accountId som tillhör
		//kunden pNr (kontonummer, saldo, kontotyp, räntesats).*/
		//        public string GetAccount() { }

		//        /*Gör en insättning på konto med kontonummer accountId som tillhör kunden pNr, returnerar true om
		//        det gick bra annars false..*/
		//        public bool Deposit() 
		//        {

		//        }
		//        /*Tar bort kund med personnummer pNr ur banken, alla kundens eventuella konton tas också bort
		//och resultatet returneras. Listan som returneras ska innehålla information om alla konton som togs
		//bort, saldot som kunden får tillbaka samt vad räntan blev.*/
		//        public bool Withdraw() { }
		//        /*Tar bort kund med personnummer pNr ur banken, alla kundens eventuella konton tas också bort
		//och resultatet returneras. Listan som returneras ska innehålla information om alla konton som togs
		//bort, saldot som kunden får tillbaka samt vad räntan blev.*/
		//        public CloseAccount() { }

	}
}
