/**
    Program: Bank Accounting System
    Author: Jon Lynch
    Assignment: Week 08: Extend week 7 Homework
 */

using System;
using bank_application.Models;

// Using static here to statically import utils
using static bank_application.utils.Utils;

namespace bank_application
{
    // This is the main program which executes and creates a bank account.
    class Program
    {
        static void Main(string[] args)
        {
            // Account Type
            int accountType;

            // Account Owners Name
            string ownerName;

            // Main Account
            Account userAccount = null;

            // Initial Deposit
            double firstDeposit;

            // Welcome User
            Console.WriteLine("Welcome to the banking application.");
            
            // Get Owner's Name
            Console.WriteLine("Please enter the account owner's name: ");
            ownerName = Console.ReadLine();

            // Get Account Type
            Console.WriteLine("What kind of account would you like to create?");
            Console.WriteLine("Choose one (1-4):");
            Console.WriteLine("1) Checking");
            Console.WriteLine("2) Savings");
            Console.WriteLine("3) Loan");
            Console.WriteLine("4) Retirement");

            accountType = int.Parse(Console.ReadLine());

            switch(accountType) {
                // Checking Account
                case 1:
                    // Assign new checking account
                    userAccount = new Checking(ownerName);
                    Console.WriteLine("Please enter your initial deposit:");
                    // Get first deposit
                    firstDeposit = double.Parse(Console.ReadLine());
                    // Enter deposit
                    userAccount.deposit(firstDeposit);
                break;
                // Savings Account
                case 2:
                    // Assign new savings account
                    userAccount = new Savings(ownerName);
                    Console.WriteLine("Please enter your initial deposit:");
                    // Get first deposit
                    firstDeposit = double.Parse(Console.ReadLine());
                    // Enter deposit
                    userAccount.deposit(firstDeposit);
                break;
                // Loan
                case 3:
                    // Assign new loan account
                    userAccount = new Loan(ownerName);
                    Console.WriteLine("You have a good fine name {0}. You seem trustworthy.", userAccount.Owner);
                    Console.WriteLine("How much would you like to borrow?");
                    // Get loan amount
                    double loanAmount = double.Parse(Console.ReadLine());
                    Console.WriteLine("Sounds great. We'll go ahead and deposit that into your account");
                    // Enter deposit
                    userAccount.deposit(loanAmount);
                break;
                // Retirement
                case 4:
                    // Assign new retirement account
                    userAccount = new Retirement(ownerName);
                    // Get first deposit
                    firstDeposit = double.Parse(Console.ReadLine());
                    // Enter deposit
                    userAccount.deposit(firstDeposit);
                break;
                // Did not enter an integer 1-4
                default:
                    Console.WriteLine("Please enter a number between 1 and 4.");
                    // Exit app
                    Environment.Exit(1);
                break;
            }

            // User Loop
            while(true) {
                // Get Account Type
                Console.WriteLine("What would you like to do next?");
                Console.WriteLine("Choose one (1-4):");
                Console.WriteLine("1) Deposit Funds");
                Console.WriteLine("2) Withdraw Funds");
                Console.WriteLine("3) Check Your Balance");
                Console.WriteLine("4) List Transactions");
                Console.WriteLine("5) Exit");

                int userSelection = int.Parse(Console.ReadLine());
                switch(userSelection) {
                    // Deposit Funds
                    case 1:
                        Console.WriteLine("How much would you like to deposit?");
                        double depositAmount = double.Parse(Console.ReadLine());
                        userAccount.deposit(depositAmount);
                    break;
                    // Withdraw Funds
                    case 2:
                        Console.WriteLine("How much would you like to withdraw?");
                        double withdrawAmount = double.Parse(Console.ReadLine());
                        double currentBalance = userAccount.getBalance();
                        
                        if(withdrawAmount >= currentBalance) {
                            // If user account doesn't have enough funds to cover this transaction, respond with message.
                            Console.WriteLine("Insufficient Funds.");
                        } else {
                            // Otherwise, withdraw money and give to user.
                            userAccount.withDraw(withdrawAmount);
                            Console.WriteLine("Here's your money. Have a nice day.");
                        }
                    break;
                    // Check Balance
                    case 3:
                        Console.WriteLine("Your current account balance is ${0:0.00}", userAccount.getBalance());
                    break;
                    // List Transactions
                    case 4:
                        // I tried using a formatter number for the second parameter.
                        // Didn't quite get the result I would like, but it's better
                        // than no formmatting.
                        Console.WriteLine("Your account transactions");
                        Console.WriteLine("==========================================");
                        Console.WriteLine("{0,22}{1,15}", "Transaction Type", "Amount");
                        Console.WriteLine("==========================================");
                        
                        // For each type of transaction, log the type and amount
                        // for withdraws, add a "-" as a prefix
                        userAccount.Transactions.ForEach(txn => {
                            string  txnType,
                                    txnModifier = "";
                            if(txn.Type == TransactionType.DEPOSIT) {
                                txnType = "deposit";
                            } else if(txn.Type == TransactionType.INTEREST_EARNED) {
                                txnType = "interest earned";
                            } else {
                                txnModifier = "-";
                                txnType = "withdraw";
                            }
                            Console.WriteLine(
                                "{0,15}{1,15}${2:0.00}\n", 
                                txnType,
                                txnModifier,
                                txn.Amount
                            );
                        });
                    break;
                    // Exit Program
                    case 5:
                        Console.WriteLine("Goodbye.");
                        Environment.Exit(0);
                    break;
                    // Invalid Entry
                    default:
                        Console.WriteLine("Invalid Entry. Please try again.");
                    break;
                }
            }

        }
    }
}
