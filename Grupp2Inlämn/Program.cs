﻿using System;
using System.Collections.Generic;

namespace Grupp2Inlämn
{
	class Program
	{
		BankLogic bl;
		public Program()
		{
			bl = new BankLogic();
		}
		public void AddAccount(long personnummer)
        {
			int newAccountID = bl.AddSavingsAccount(personnummer);
            Console.WriteLine("Ditt nya konto har ID: {0}", newAccountID);
		}
		public void RemoveCustomer()
        {
			Console.WriteLine("Ange personnummer på kunden som ska tas bort.");
			Console.Write("Personnummer: ");
			long personNummer = int.Parse(Console.ReadLine());
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
		public void AddCustomer()
		{
			Console.WriteLine("Ange namn och personnummer.");
			Console.Write("Namn: ");
			string name = Console.ReadLine();
			Console.Write("Personnummer: ");
			long personNummer = int.Parse(Console.ReadLine());
			bl.AddCustomer(name, personNummer);

		}
		void kundMeny(long personnummer)
		{

			int menuChoice = 0;
			while (menuChoice != 7)
			{
				Console.WriteLine("Kund Meny");
				Console.WriteLine("Choose an operation:");
				Console.WriteLine("1. Do thing A");
				Console.WriteLine("2. Do thing B");
				Console.WriteLine("3. Skapa nytt sparkonto");
				Console.WriteLine("4. Do thing D");
				Console.WriteLine("5. Do thing E");
				Console.WriteLine("6. Do thing F");
				Console.WriteLine("7. EXIT");

				switch (menuChoice)
				{
					case 1:
						Console.WriteLine("Does thing A");
						break;
					case 2:
						//kundMeny();
						break;
					case 3:
						Console.WriteLine("Does thing C");
						break;
					case 4:
						Console.WriteLine("Does thing D");
						break;
					case 5:
						Console.WriteLine("Does thing E");
						break;
					case 6:
						Console.WriteLine("Does thing F");
						break;
					case 7:
						break;
					default:
						Console.WriteLine("Invalid entry!");
						break;
				}
			}
		}
		void bankMeny()
		{
			int menuChoice = 0;
			while (menuChoice != 7)
			{
				Console.WriteLine("Bank Meny");
				Console.WriteLine("Choose an operation:");
				Console.WriteLine("1. Välj konto:");
				Console.WriteLine("2. Lägg Till Kund");
				Console.WriteLine("3. Ta bort kund");
				Console.WriteLine("4. Do thing D");
				Console.WriteLine("5. Do thing E");
				Console.WriteLine("6. Do thing F");
				Console.WriteLine("7. EXIT");

				menuChoice = int.Parse(Console.ReadLine());

				switch (menuChoice)
				{
					case 1:
						kundMeny();
						break;
					case 2:
						AddCustomer();
						break;
					case 3:
						Console.WriteLine("Does thing C");
						break;
					case 4:
						Console.WriteLine("Does thing D");
						break;
					case 5:
						Console.WriteLine("Does thing E");
						break;
					case 6:
						Console.WriteLine("Does thing F");
						break;
					case 7:
						break;
					default:
						Console.WriteLine("Invalid entry!");
						break;
				}
			}
		}
			
		public static void Main(string[] args)
		{
			Program p = new Program();
			p.AddCustomer();
			p.AddCustomer();
			Console.WriteLine("Alla Kunder i banken:");
			p.bl.GetCustomers().ForEach(Console.WriteLine);
			
			p.AddAccount(123);
			p.bl.GetCustomer(123).ForEach(Console.WriteLine); 

		}
	}
}   

