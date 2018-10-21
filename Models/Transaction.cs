using System;
// Using static here to statically import utils
using static bank_application.utils.Utils;

namespace bank_application.Models
{
    // Transaction to hold information about a deposit or a withdraw.
    public class Transaction
    {
        // Transaction is tied to a particular account
        public Guid AccountId { get; }
        // Amount for transaction
        public double Amount { get; }
        // Date/Time of transaction
        public DateTime CreatedAt { get; }

        // Type is deposit, interest earned, or withdraw
        public TransactionType Type { get; }

        // Public Constructor
        // Takes in and sets AccountId, Amount, and Type
        public Transaction (Guid accountId, double amount, TransactionType type) {
            AccountId = accountId;
            Amount = amount;
            Type = type;
            CreatedAt = DateTime.Now;
        }
    }
}