﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp2Inlämn
{
    class SavingsAccount
    {
        private double Saldo;
        private double Interest;
        private string AccountType;
        private int Kontonummer;

        public void deposit(double depositAmount) 
        {
            Saldo += depositAmount;
        }
        public void withdraw(double withdrawlAmount) 
        {
            Saldo -= withdrawlAmount;
        }
        public void getAccountNum() { }
        public void getInterest() { }
        public void getInfo() { }

    }
}
