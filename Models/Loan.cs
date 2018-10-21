using System.Collections.Generic;

namespace bank_application.Models
{
    // Loan account is derived from Account base class
    public class Loan : Account
    {
        // Constructor calls parent class constructor
        public Loan(string ownerName) : base(ownerName){}
        
    }
}