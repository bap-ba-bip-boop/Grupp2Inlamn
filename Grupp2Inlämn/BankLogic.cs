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
            List<string> infoList = new List<string>();
			foreach (var cust in this.Customers)
			{
                infoList.Add(cust.GetInfo());
			}
			return infoList;
        }

		public bool AddCustomer(string namn, long personnummer) 
		{
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
			int accountID =  -1;

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
			string path = @"customers.txt";

			File.WriteAllLines(path, this.Customers.Select(customer => customer.GetInfo()));
		}
	}
}
