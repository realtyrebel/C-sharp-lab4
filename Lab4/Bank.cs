using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Lab4
{
    class Bank
    {
        //ensures random number generation
        static readonly Random getrandom = new Random();

        static void Main(string[] args)//void does not return a value
        {
            //initialize variables
            bool continueInput = true;
            double initialDeposit;
            double monthlyDeposit;
            string input;

            //blank list
            List<SavingsAccount> listAccounts = new List<SavingsAccount>();//should this be an array? >>> nope, just list of class objects

            //create new account(s)
            do
            {
                //set initial values
                initialDeposit = 0;
                monthlyDeposit = 0;

                Console.Write("Please enter new customer name: ");
                string inputName = Console.ReadLine();
                string customerName = new CultureInfo("en-US").TextInfo.ToTitleCase(inputName);

                if (!string.IsNullOrEmpty(customerName))//if not null, create new account
                {
                    //Console.WriteLine(customerName);

                    //Initial Deposit Amount (min. $1,000.00)
                    Console.Write("Please enter {0}'s initial deposit amount (or Enter for min. $1,000.00): $", customerName);
                    input = Console.ReadLine();
                    if (input != "")
                    {
                        initialDeposit = Convert.ToDouble(input);
                        if(initialDeposit < 1000)
                        {
                            Console.WriteLine(">>> ERROR: initial deposit must be at least $1,000.");
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        initialDeposit = 1000.0;
                    }
                    //Console.WriteLine("Initial Deposit of ${0} is variable type: {1}",initialDeposit, initialDeposit.GetType());

                    //Monthly Deposit Amount
                    //minimum of $50.00 set as 
                    Console.Write("Please enter {0}'s monthly deposit amount (or Enter for min. $50.00): $", customerName);
                    input = Console.ReadLine();
                    if (input != "")
                    {
                        monthlyDeposit = Convert.ToDouble(input);
                        if(monthlyDeposit < 50)
                        {
                            Console.WriteLine(">>> ERROR: monthly deposits must be at least $50.");
                            Console.WriteLine("");
                        }

                    }
                    else
                    {
                        monthlyDeposit = 50.0;
                    }
                    //Console.WriteLine("Monthly Deposit of ${0} is variable type: {1}", monthlyDeposit, monthlyDeposit.GetType());

                    if(initialDeposit >= 1000.0 && monthlyDeposit >= 50)
                    {
                        //get random number between 0 and 9999
                        int randomNumber = GetRandomNumber(0000, 9999);

                        //create new SavingsAccount
                        SavingsAccount newAccount = new SavingsAccount(customerName, initialDeposit, monthlyDeposit, randomNumber);//how do I create a unique variable name? >>> don't need one

                        //add to list of accounts
                        listAccounts.Add(newAccount);//how do I create a list of all accounts created?
                    }
                    else
                    {
                        Console.WriteLine(">>> ERROR: New account for customer {0} was not created.", customerName);
                        Console.WriteLine("");
                    }
                }
                else
                {
                    //set continueInput to false to exit loop
                    continueInput = false;
                }
                Console.WriteLine("");
            } while (continueInput);

            //Function to get random number
            int GetRandomNumber(int min, int max)
            {
                //ensures random number generation
                //readonly Random getrandom = new Random(); //why can I not do readonly ???
                //Random getrandom = new Random();

                lock (getrandom) // synchronize
                {
                    return getrandom.Next(min, max);
                }
            }

            //display each account details
            if (listAccounts.Count() > 0)
            {
                int listLength = listAccounts.Count();

                foreach (SavingsAccount account in listAccounts)
                {
                    //create loop for 6 months
                    for (int i = 1; i < 7; i++)
                    {
                        //Console.WriteLine("Month {0} starting balance is {1}.", i, account.Balance);

                        //deduct monthly fee
                        account.DeductMonthlyFee(account.Balance);
                        //Console.WriteLine("After deducting monthly fee the remaining balance is {0}", account.Balance);
                        
                        //add monthly interest
                        account.AddMonthlyInterest(account.Balance);
                        //Console.WriteLine("After adding monthly interest the balance is {0}", account.Balance);

                        //add monthly deposit
                        account.AddMonthlyDeposit(account.Balance);
                        //Console.WriteLine("After adding the monthly deposit the balance is now {0}", account.Balance);

                        //Console.WriteLine("");
                    }

                    //Console.WriteLine("Account Number: " + account.AccountNumber);
                    //Console.WriteLine("Account Owner: " + account.Owner);
                    //Console.WriteLine("Monthly Deposit: " + account.MonthlyDeposit);
                    //Console.WriteLine("Current Balance: " + account.Balance);

                    Console.WriteLine("After 6 months, {0} (Account# {1}) has a balance of {2}", account.Owner, account.AccountNumber, account.Balance.ToString("C", CultureInfo.CurrentCulture));
                }
            }
        }
    }
}
