using System;
using System.Collections.Generic;

// A class that creates the User Profile object for each new user
// they need to have a Balance, which is added to or taken from
namespace BankLedger
{
    public class UserProfile
    {
        public double Balance;
        public UserProfile(double balance)
        {
            Balance = balance;
        }
    }
}