using System.Collections.Generic;

namespace bank_application.Models
{
    // Checking account is derived from Account base class
    public class Checking : Account
    {
        // Constructor calls parent class constructor
        public Checking(string ownerName) : base(ownerName){}

    }
}