using System;
using System.Collections.Generic;
using System.IO;

namespace Grupp2Inlämn
{
	class Program
	{
		private BankLogic bL;
		public Program()
		{
			bL = new BankLogic();
		}
		public static void MockData(BankLogic bL)
        {
            string txtFile = @"customers.txt";
			List<string> rawData = new List<string>(File.ReadAllLines(txtFile));

			rawData.RemoveAll(s => s == "");
            foreach (string row in rawData)
            {
				string name = row.Substring(row.LastIndexOf(":")+2);
				int a = row.IndexOf(":")+1;
				int b = row.IndexOf(",");
				int lenght = b - a;
				string personID = row.Substring(a,lenght);
				bL.AddCustomer(name, long.Parse(personID));
            }
		}
		public long UserAccount()
		{
			Console.WriteLine("Skriv in personnummer för att logga in.");
			Console.WriteLine("Personnummer: ");
			long personnummer = long.Parse(Console.ReadLine());
			List<string> customers = bL.GetCustomer(personnummer);

			if(customers != null)
            {
                Console.WriteLine("Personnummret matchar! Välkommern till Kund Menyn");
            }
            else
            {
                Console.WriteLine("Det finns ingen kund med det angivna personnummret.");
				personnummer = -1;
            }
			return personnummer;
		}

		public void AddAccount(long personnummer)
        {
			int newAccountID = bL.AddSavingsAccount(personnummer);
            Console.WriteLine("Ditt nya konto har ID: {0}", newAccountID);
		}
		public void CloseAccount(long personnummer)
		{
			Console.WriteLine("Ange det kontonummer som ska avslutas");
            Console.Write("Kontonummer: ");
			int kontonummer = int.Parse(Console.ReadLine());

			string closeAccountResult = bL.CloseAccount(personnummer, kontonummer);

            Console.WriteLine(closeAccountResult != null ? "Det avslutade kontot: " + closeAccountResult : "Kontonumret som skrevs in är ej korrekt");
        }
		public void RemoveCustomer()
		{
			Console.WriteLine("Ange personnummer på kunden som ska tas bort");
			Console.Write("Personnummer: ");
			long personnummer = long.Parse(Console.ReadLine());
			List<string> removedCustomerInfo = bL.RemoveCustomer(personnummer);

			if (removedCustomerInfo != null)
			{
				Console.WriteLine("Info om kund som tagits bort:");
				removedCustomerInfo.ForEach(Console.WriteLine);
			}
			else
			{
				Console.WriteLine("Det finns ingen kund med det personnumret");
			}
		}
		public void PrintAllCustomers()
        {
			List<string> customers = bL.GetCustomers();
			foreach (var cust in customers)
			{
				Console.WriteLine(cust);
			}
        }
		public void CustomerAccounts(long personnummer)
		{
			List<string> allAccounts = bL.GetCustomer(personnummer);
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
			long personnummer = long.Parse(Console.ReadLine());
			bL.AddCustomer(name, personnummer);
		}

		public void ChangeName(long personnummer)
		{
			Console.WriteLine("Ange det nya namnet och personnummer till kunden");
			Console.Write("Nytt namn: ");
			string name = Console.ReadLine();
			bool succesfulNameChange = bL.ChangeCustomerName(name, personnummer); ;
			if (succesfulNameChange == true)
			{
				Console.WriteLine("Namnet ändrades");
			}
			else
			{
				Console.WriteLine("Det finns ingen kund med det personnumret");
			}
		}

		public void GetAccount(long personnummer)
		{
			Console.WriteLine("Ange det kontonumret ni vill komma åt.");
			Console.Write("Kontonummer: ");
			int kontonummer = int.Parse(Console.ReadLine());

			string accountInfo = bL.GetAccount(personnummer, kontonummer);

			Console.WriteLine(accountInfo != null ? accountInfo : "Kontonumret som skrevs in är ej korrekt");
		}

		public void Deposit(long personnummer)
		{
			Console.WriteLine("Ange det kontonumret ni vill sätta in pengar på.");
			Console.Write("Kontonummer: ");
			int kontoNummer = int.Parse(Console.ReadLine());

			Console.WriteLine("Vilket belopp vill ni sätta in?");
			Console.Write("Belopp i kr: ");
			int antalPengar = int.Parse(Console.ReadLine());

			bool successfulTransaction = bL.Deposit(kontoNummer, personnummer, antalPengar);

			Console.WriteLine(successfulTransaction ? "Transaktionen lyckades" : "Transaktionen misslyckades");
		}

		public void Withdraw(long personnummer) 
		{
			Console.WriteLine("Ange kontonummer:");
			int accountId = int.Parse(Console.ReadLine());
			Console.WriteLine("Skriv in önskat belopp:");
			decimal amount = decimal.Parse(Console.ReadLine());
			bool amountOk = bL.Withdraw(accountId, personnummer, amount);
			
			if (amountOk == true)
			{
				Console.WriteLine($"Uttag: {amount} kr från konto {accountId} ");
			}
			else
			{
				Console.WriteLine("Belopp fel eller kontonummer ej hittat");
			}
		}
		public void PrintToTextFile()
        {
			bL.PrintToTextFile();
            Console.WriteLine("All kundinfo har exporterats till 'customers.txt'");
        }

		void KundMeny(long pNum)
		{
			int menuChoice = 0;
			while (menuChoice != 8)
			{
				Console.WriteLine("Kundmeny");
				Console.WriteLine("Välj ett alternativ:");
				Console.WriteLine("1. Ändra kundens namn");
				Console.WriteLine("2. Skapa sparkonto");
				Console.WriteLine("3. Avsluta konto");
				Console.WriteLine("4. Hämta info om ett konto");
				Console.WriteLine("5. Hämta info om alla konton");
				Console.WriteLine("6. Sätt in pengar");
				Console.WriteLine("7. Ta ut pengar");
				Console.WriteLine("8. EXIT");

				try
				{
					menuChoice = int.Parse(Console.ReadLine());
				}
				catch (Exception){ }

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
						CustomerAccounts(pNum);
						break;
					case 6:
						Deposit(pNum);
						break;
					case 7:
						Withdraw(pNum);
						break;
					case 8:
						break;
					default:
						Console.WriteLine("Felaktigt alternativ!");
						break;
				}
			}
		}
		void BankMeny()
		{
			int menuChoice = 0;
			while (menuChoice != 6)
			{
				Console.WriteLine("Bankmeny");
				Console.WriteLine("Välj ett alternativ:");
				Console.WriteLine("1. Välj kund");
				Console.WriteLine("2. Lägg till kund");
				Console.WriteLine("3. Ta bort kund");
				Console.WriteLine("4. Skriv ut kundlista");
                Console.WriteLine("5. Exportera till textfil");
				Console.WriteLine("6. EXIT");
                try
                {
					menuChoice = int.Parse(Console.ReadLine());
                }
                catch (Exception) { }

				switch (menuChoice)
				{
					case 1:
						long pNr = UserAccount();
                        if (pNr != -1)
                        {
							KundMeny(pNr);
						}
						break;
					case 2:
						AddCustomer();
						break;
					case 3:
						RemoveCustomer();
						break;
					case 4:
						PrintAllCustomers(); 
						break;
					case 5:
						PrintToTextFile();
						break;
					case 6:
						break;
					default:
						Console.WriteLine("Felaktigt alternativ!");
						break;
				}
			}
		}
			
		public static void Main(string[] args)
		{
			Program p = new Program();
			MockData(p.bL);
            p.BankMeny();
		}
	}
}


