using System;
using System.Collections.Generic;
// Using static here to statically import utils
using static bank_application.utils.Utils;

namespace bank_application.Models
{
    // Base Class for Account
    public abstract class Account
    {

        // Using Guid here for unique account id
        public Guid AccountId { get; }
        // Owner of Account
        public string Owner { get; }
        // Date this account was created
        public DateTime CreatedAt { get; }
        // This is a list of all transactions in the account
        public List<Transaction> Transactions = new List<Transaction>();
        
        // Constructor
        public Account(string ownerName) {
            AccountId = Guid.NewGuid();
            Owner = ownerName;
            CreatedAt = DateTime.Now;
        }

        // Get Balance from Transactions
        public double getBalance() {
            double balance = 0.00;
            Transactions.ForEach(trans => {
                switch(trans.Type) {
                    case TransactionType.INTEREST_EARNED:
                    case TransactionType.DEPOSIT:
                        // add to balance
                        balance += trans.Amount;
                        break;
                    case TransactionType.WITHDRAW:
                        balance -= trans.Amount;
                        break;
                }
            });
            return balance;
        }

        // Deposit amount from user
        // Virtual function overridden in savings to add interest
        virtual public void deposit(double amount)  {
            // Create new transaction
            Transaction trans = new Transaction(
                AccountId, 
                amount, 
                TransactionType.DEPOSIT
            );
            // Add transaction to list of transactions
            Transactions.Add(trans);
        }

        // Withdraw
        public void withDraw(double amount) {
            // Create new transaction
            Transaction trans = new Transaction(
                AccountId,
                amount,
                TransactionType.WITHDRAW);
            // Add transaction to list of transactions            
            Transactions.Add(trans);
        }
    }
}