using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class SavingsAccount
    {
        //initialize variables
        public int AccountNumber;
        //public int AccountNumber { get; }
        public string Owner;
        //public string Owner { get; }
        private double balance;//cannot access outside of class
        public double Balance
        {
            get { return balance; }
        }
        //public double Balance { get; private set; }//can only set in this class
        
        //amount customer will deposit every month
        public double MonthlyDeposit;
        //public double MonthlyDeposit { get; set; }

        /*
        private double balance;
        public double Balance 
        {
            get { return balance; }
            set { balance = Value;}
        }
        */


        //STATIC PROPERTIES
        static double MonthlyFee = 4.0;
        //public static double MonthlyFee { get; set; } = 4.0;
        static double MonthlyInterestRate = 0.0025;
        //public static double MonthlyInterestRate { get; set; } = 0.025/12;
        //static double MinimumInitialBalance = 1000.0;
        //public static double MinimumInitialBalance { get; set; } = 1000.0;
        //static double MinimumMonthlyDeposit = 50.0;
        //public static double MinimumMonthlyDeposit { get; set; } = 50.0;
        //CLASS CONSTRUCTOR
        //create new account
        //create 5 digit random account number "9XXXX"
        public SavingsAccount(string owner, double initialDeposit, double monthlyDeposit, int randomNumber)
        {
            this.AccountNumber = 90000 + randomNumber;
            this.Owner = owner;
            this.balance = initialDeposit;
            this.MonthlyDeposit = monthlyDeposit;
        }

        //Instance Method (i.e., behavior of object)
        public void Deposit(double amount)
        {
            this.balance += Math.Round(amount,2);
        }

        //Instance Method (i.e., behavior of object)
        public void Withdraw(double amount)
        {
            //check if there is money in the account
            if(balance >= amount)
            {
                this.balance -= Math.Round(amount,2);
            }
        }

        /*
        public void monthlyAccountUpdate(double currentBalance)
        {
            //double currentBalance = this.balance;
            //deduct monthly fee
            deductMonthlyFee(currentBalance);
            addMonthlyInterest(currentBalance);

        }
        */

        public void DeductMonthlyFee(double currentBalance)
        {
            currentBalance -= MonthlyFee;
            this.balance = Math.Round(currentBalance,2);
        }

        public void AddMonthlyInterest(double currentBalance)
        {
            currentBalance *= (1 + MonthlyInterestRate);
            this.balance = Math.Round(currentBalance,2);
        }

        public void AddMonthlyDeposit(double currentBalance)
        {
            currentBalance += this.MonthlyDeposit;
            this.balance = Math.Round(currentBalance,2);
        }
    }
}
