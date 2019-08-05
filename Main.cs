using System;

namespace BankLedger {

class Program
    {
        public static void Main(string[] args)
        {
            // Sets logout to boolean, will set to true when a logout functuon has been ran
            bool logout = false;
            // While a user is not logged out start a new application instance
            while (logout == false) {
                StartApplication.start();
            }
        }
    }
}