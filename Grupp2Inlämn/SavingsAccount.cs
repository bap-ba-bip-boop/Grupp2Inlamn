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
            //kod för deposit
            this.Saldo += depositAmount;
        }
        public void withdraw(double withdrawAmount) 
        {
            //kod för withdrawl
            this.Saldo -= withdrawAmount;
        }
        public void getAccountNum() { }
        public void getInterest() { }
        public void getInfo() { }

    }
}
