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
			/*
			1. Läser in alla rader från adressen som finns i variabeln 'txtFile' och sparar de raderna i 'rawData' 
			2. tar bort alla blanka rader från rawData
			3. för varje rad plockar metoden ut personnummer och namn ifron varje rad och skapar en kund med den info
			4. Metoden har läst in alla kunder
			*/
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
			/*
			1. Ber andvändaren att skriva in ett personnummer som ska tillhöra en Customer klass
			2. metoden antar att användarens input är korrekt och använder BankLogic.GetCustomer för att se om kunden finns i våran BankLogic variabel 'bL'
			3. ifall BankLogic.GetCustomer returnerar null betyder det att BankLogic.GetCustomer inte funnit en kund med det personnummret, då kan vi lägga till den kunden
			4. ifall BankLogic.GetCustomer returnerar en sträng med info betyder det att det finns en kund med det personnummret. Då lägger vi inte till en ny kund med personnummret som användaren skrev
			*/
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
			/*
			1. Lägger till ett nytt konto till en kund med personnummret som skickas in i parametern 'personnummer'
			2. Skriver ut accountId:t som returneras av BankLogic.AddSavingsAccount
			*/
			int newAccountID = bL.AddSavingsAccount(personnummer);
            Console.WriteLine("Ditt nya konto har ID: {0}", newAccountID);
		}
		public void CloseAccount(long personnummer)
		{
			/*
			1. Ber kunden att skriva ett id till sparkontot som de vill ta bort
			2. antar att kunden skrivit in ett nummer och anropar BankLogic.CloseAccount med det nummret som argument
			3. ifall BankLogic.CloseAccount returnerar null betyder det att kontot inte stängts, detta meddelas då till användaren
			4. ifall BankLogic.CloseAccount returnerar en sträng betyder det att kontot stängts och då meddelas det till användaren
			*/
			Console.WriteLine("Ange det kontonummer som ska avslutas");
            Console.Write("Kontonummer: ");
			int kontonummer = int.Parse(Console.ReadLine());

			string closeAccountResult = bL.CloseAccount(personnummer, kontonummer);

            Console.WriteLine(closeAccountResult != null ? "Det avslutade kontot: " + closeAccountResult : "Kontonumret som skrevs in är ej korrekt");
        }
		public void RemoveCustomer()
		{
			/*
			1. Ber kunden att skriva ett personnummer till sparkontot som de vill ta bort
			2. antar att kunden skriver in ett nummer och anropar BankLogic.RemoveCustomer med det nummret som argument
			3. ifall listan som BankLogic.RemoveCustomer returnerar är tom betyder det att ingen kund tagits bort. Då meddelas användaren om detta
			4. ifall listan som BankLogic.RemoveCustomer returnerar inte är tom betyder det att kunden tagits bort. Då skrivs infon i listan ut till användaren
			*/
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
			//1. Hämtar information om alla kunder (customer objekt) från BankLogic.GetCustomers
			//2. skriver ut listan
			List<string> customers = bL.GetCustomers();
			foreach (var cust in customers)
			{
				Console.WriteLine(cust);
			}
        }
		public void CustomerAccounts(long personnummer)
		{
			//1. Hämtar information om en kund och alla dess konton från BankLogic.GetCustomer
			//2. skriver ut listan
			List<string> allAccounts = bL.GetCustomer(personnummer);
            foreach (var accounts in allAccounts)
            {
				Console.WriteLine(accounts);
            }
		}

		public void AddCustomer()
		{
			/*
			1. Ber användaren att skriva ett namn till kunden och personnummer till den nya kunden
			2. antar att den data som användaren skickar in är korrekt och Anropar BankLogic.AddCustomer 
			*/
			Console.WriteLine("Ange namn och personnummer.");
			Console.Write("Namn: ");
			string name = Console.ReadLine();
			Console.Write("Personnummer: ");
			long personnummer = long.Parse(Console.ReadLine());
			bL.AddCustomer(name, personnummer);
		}

		public void ChangeName(long personnummer)
		{
			/*
			1. Ber användaren att skriva in ett nytt namn till kontot
			2. Anropar BankLogic.ChangeCustomerName med användarens nya namn 
			3. ifall BankLogic.ChangeCustomerName returnerar true betyder det att namnändringen lyckades och meddelar detta till användaren
			4. ifall BankLogic.ChangeCustomerName returnerar false betyder det att namnändringen misslyckades och meddelar detta till användaren
			*/
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
			/*
			1. Ber användaren att skriva in ett kontonummer till det kontot hen vill hämta
			2. antar att användaren skriver ett nummer och skickar kontonummret till BankLogic.GetAccount
			3. Ifall BankLogic.GetAccount returnerar null betyder det att BankLogic.GetAccount misslyckades att hämta informationen. Kunden meddelas om detta
			4. Ifall BankLogic.GetAccount returnerar en string betyder det att BankLogic.GetAccount lyckats. Då skriver den ut info om kontot
			*/
			Console.WriteLine("Ange det kontonumret ni vill komma åt.");
			Console.Write("Kontonummer: ");
			int kontonummer = int.Parse(Console.ReadLine());

			string accountInfo = bL.GetAccount(personnummer, kontonummer);

			Console.WriteLine(accountInfo != null ? accountInfo : "Kontonumret som skrevs in är ej korrekt");
		}

		public void Deposit(long personnummer)
		{
			/*
			1. Ber användaren att skriva in kontonumret som de vill lägga in pengar på samt summan pengar
			2. antar att kunden skrivit in nummer och kallar BankLogic.Deposit med användarens argument
			3. Ifall BankLogic.Deposit returnerar true betyder det att transaktionen lyckades och kunden meddelas om detta
			4. Ifall BankLogic.Deposit returnerar false betyder det att transaktionen misslyckades och kunden meddelas om detta
			*/
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
			/*
			1. Ber användaren att skriva in kontonumret som de vill lägga in pengar på samt summan pengar
			2. antar att kunden skrivit in nummer och kallar BankLogic.Deposit med användarens argument
			3. Ifall BankLogic.Deposit returnerar true betyder det att transaktionen lyckades och kunden meddelas om detta
			4. Ifall BankLogic.Deposit returnerar false betyder det att transaktionen misslyckades och kunden meddelas om detta
			*/
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
			/*
			1. kallar BankLogic.PrintToTextFile och meddelar användaren am att kundinfon skrivits till en textfil
			*/
			bL.PrintToTextFile();
            Console.WriteLine("All kundinfo har exporterats till 'customers.txt'");
        }

		void KundMeny(long pNum)
		{
			/*
			'sub-meny' till bankmenyn som hanterar 'kundens funktioner' d.v.s. de funktioner du som en kund hos en bank ska ha tillgång till
			ber användaren att skriva in ett nummer för att komma åt metoderna i switch case blocket
			*/
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
			/*
			Den meny som hanterar 'Bankens funktioner' d.v.s de metoder som banken och dess personal har tillgång till
			användaren skriver in ett val i menyn för att komma åt ett av programets metoder. hoppar ur loopen om menuChoice är 6 
			*/
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
			MockData(p.bL);//läser
            p.BankMeny();
		}
	}
}


