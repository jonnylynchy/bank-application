using System.Collections.Generic;
// Using static here to statically import utils
using static bank_application.utils.Utils;

namespace bank_application.Models
{
    // Savings account is derived from Account base class
    public class Savings : Account
    {
        // Savings account rate
        private const double SAVINGS_INTEREST_RATE = 0.04;

        // Constructor calls parent class constructor
        public Savings(string ownerName) : base(ownerName){}
        
        // Getter only gets the interest rate
        public double interestRate { 
            get {
                return SAVINGS_INTEREST_RATE;
            }
        }

        // This method overrides the virtual method in Account.cs
        override public void deposit(double amount)  {
            // Create deposit transaction
            Transaction trans = new Transaction(
                AccountId,
                amount,
                TransactionType.DEPOSIT
            );

            // Add deposit transaction
            Transactions.Add(trans);

            // Calculate interest payment
            double interestEarned = amount * SAVINGS_INTEREST_RATE;

            // Create interest payment transaction
            Transaction interstTrans = new Transaction(
                AccountId,
                interestEarned,
                TransactionType.INTEREST_EARNED
            );

            // Add interest transaction
            Transactions.Add(interstTrans);
        }
    }
}