using System.Collections.Generic;

namespace bank_application.Models
{
    // Retirement account is derived from Account base class
    public class Retirement : Account
    {
        // Constructor calls parent class constructor
        public Retirement(string ownerName) : base(ownerName){}
        
    }
}