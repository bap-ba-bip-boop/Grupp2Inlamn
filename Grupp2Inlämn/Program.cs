using System;
using System.Collections.Generic;
using System.IO;

namespace Grupp2Inlämn
{
	class Program
	{
		private BankLogic bl;
		public Program()
		{
			bl = new BankLogic();
		}
		public long UserAccount()
		{
			Console.WriteLine("Skriv in personnummer för att logga in.");
			Console.WriteLine("Personnummer: ");
			long personnummer = long.Parse(Console.ReadLine());
			List<string> customers = bl.GetCustomer(personnummer);

			if(customers != null) // Customers innehåller info, dvs att det finns en kund med det personnummret
            {
                Console.WriteLine("Personnummret matchar! Välkommern till Kund Menyn");
            }
            else // Customers innehåller inte någon info, dvs att det inte en matchande kund till personnummret
            {
                Console.WriteLine("Det finns ingen kund med det angivna personnummret.");
				personnummer = -1;
            }
			return personnummer;
		}

		public void AddAccount(long personnummer)
        {
			int newAccountID = bl.AddSavingsAccount(personnummer);
            Console.WriteLine("Ditt nya konto har ID: {0}", newAccountID);
		}
		public void CloseAccount(long personNummer)
		{
			Console.WriteLine("Ange det Kontonummer som ska avslutas");
            Console.Write("Kontonummer: ");
			int kontonummer = int.Parse(Console.ReadLine());

			string closeAccountResult = bl.CloseAccount(personNummer, kontonummer);

            Console.WriteLine(closeAccountResult != null ? "Det Avslutade Kontot: " + closeAccountResult : "Kontonummret som skrevs in är ej korrekt");
        }
		public void RemoveCustomer()
		{
			Console.WriteLine("Ange personnummer på kunden som ska tas bort.");
			Console.Write("Personnummer: ");
			long personNummer = long.Parse(Console.ReadLine());
			List<string> removedCustomerInfo = bl.RemoveCustomer(personNummer);

			if (removedCustomerInfo != null)// vi har funnit en kund med matchande personNummer
			{
				Console.WriteLine("Info om Kund Som tagits bort:.");
				removedCustomerInfo.ForEach(Console.WriteLine);
			}
			else//vi hittade inte en kund med matchande personnummer
			{
				Console.WriteLine("Det finns ingen kund med det personnummret");
			}
		}
		public void printAllCustomers()
        {

			List<string> customers = bl.GetCustomers();
			foreach (var cust in customers)
			{
				Console.WriteLine(cust);
			}
        }
		public void customerAccounts(long Personnummer)
		{
			List<string> allAccounts = bl.GetCustomer(Personnummer);
            foreach (var accounts in allAccounts)
            {
				Console.WriteLine(accounts);
            }

		}

		public void AddCustomer()
		{
			Console.WriteLine("Ange namn och personnummer.");
			Console.Write("Namn: ");
			string name = Console.ReadLine();
			Console.Write("Personnummer: ");
			long personNummer = long.Parse(Console.ReadLine());
			bl.AddCustomer(name, personNummer);

		}

		public void ChangeName(long personnummer)
		{
			Console.WriteLine("Ange det nya namnet och personnummer till kund");
			Console.Write("Nytt namn: ");
			string name = Console.ReadLine();
			bool succesfulNameChange = bl.ChangeCustomerName(name, personnummer); ;
			if (succesfulNameChange == true)// vi har funnit en kund med matchande personNummer
			{
				Console.WriteLine("Namnet ändrades");
			}
			else//vi hittade inte en kund med matchande personnummer
			{
				Console.WriteLine("Det finns ingen kund med det personnummret");
			}
		}

		public void GetAccount(long personNummer)
		{
			Console.WriteLine("Ange det kontonummret ni vill komma åt.");
			Console.Write("Kontonummer: ");
			int kontoNummer = int.Parse(Console.ReadLine());

			string accountInfo = bl.GetAccount(personNummer, kontoNummer);

			Console.WriteLine(accountInfo != null ? accountInfo : "Kontonummret som skrevs in är ej korrekt");
		}

		public void deposit(long personNummer)
		{
			Console.WriteLine("Ange det kontonummret ni vill lägga in pengar på.");
			Console.Write("Kontonummer: ");
			int kontoNummer = int.Parse(Console.ReadLine());

			Console.WriteLine("Hur mycket pengar vill ni lägga in?");
			Console.Write("Antal i kr: ");
			int antalPengar = int.Parse(Console.ReadLine());

			bool successfulTransaction = bl.Deposit(kontoNummer, personNummer, antalPengar);

			Console.WriteLine(
				successfulTransaction ? "Transaktionen lyckades" : "Transaktionen misslyckades"
				);
		}

		public void Withdraw(long personNummer) 
		{
			Console.WriteLine("Ange kontonummer:");
			int accountId = int.Parse(Console.ReadLine());
			Console.WriteLine("Skriv in önskat belopp");
			decimal amount = decimal.Parse(Console.ReadLine());
			bool amountOk = bl.Withdraw(accountId, personNummer, amount);
			
			if (amountOk == true)
			{
				Console.WriteLine($"Uttag: {amount} kr från konto {accountId} ");
			}
			else
			{
				Console.WriteLine("Belopp fel eller kontonummer ej hittat");
			}
		}

		void kundMeny(long pNum)
		{

			int menuChoice = 0;
			while (menuChoice != 8)
			{
				Console.WriteLine("Kund Meny");
				Console.WriteLine("Välj Ett Alternativ:");
				Console.WriteLine("1. Ändra Kundens Namn");
				Console.WriteLine("2. Skapa Sparkonto");
				Console.WriteLine("3. Avsluta Konto");
				Console.WriteLine("4. Hämta info om ett konto");
				Console.WriteLine("5. Hämta info om alla konton");
				Console.WriteLine("6. Sätt in pengar");
				Console.WriteLine("7. hämta pengar");
				Console.WriteLine("8. EXIT");

				menuChoice = int.Parse(Console.ReadLine());

				switch (menuChoice)
				{
					case 1:
						ChangeName(pNum);
						break;
					case 2:
						AddAccount(pNum);
						break;
					case 3:
						CloseAccount(pNum);
						break;
					case 4:
						GetAccount(pNum);
						break;
					case 5:
						customerAccounts(pNum);
						break;
					case 6:
						deposit(pNum);
						break;
					case 7:
						Withdraw(pNum);
						break;
					case 8:
						break;
					default:
						Console.WriteLine("Felaktigt Alternativ!");
						break;
				}
			}
		}
		void bankMeny()
		{
			int menuChoice = 0;
			while (menuChoice != 5)
			{
				Console.WriteLine("Bank Meny");
				Console.WriteLine("Välj Ett Alternativ:");
				Console.WriteLine("1. Välj konto:");
				Console.WriteLine("2. Lägg Till Kund");
				Console.WriteLine("3. Ta bort kund");
				Console.WriteLine("4. Skriv ut kundlista");
				Console.WriteLine("5. EXIT");

				menuChoice = int.Parse(Console.ReadLine());

				switch (menuChoice)
				{
					case 1:
						long pNr = UserAccount();
                        if (pNr != -1)
                        {
							kundMeny(pNr);
						}
						break;
					case 2:
						AddCustomer();
						break;
					case 3:
						RemoveCustomer();
						break;
					case 4:
						printAllCustomers();
						break;
					case 5:
						break;
					default:
						Console.WriteLine("Felaktigt Alternativ!");
						break;
				}
			}
		}
			
		public static void Main(string[] args)
		{
			Program p = new Program();
			p.bankMeny();

		}
	}
}

