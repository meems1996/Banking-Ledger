using System;
using System.Net;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;

namespace BankLedger
{
    class  StartApplication{
        public void DisplayOptions() {
            Console.WriteLine("\nWelcome to Bank Ledger. Choose to sign up or login by typing 1 or 2.");
            Console.WriteLine("To logout just type logout.");

            String options = ("\n1. Sign Up     2. Login");

            Console.WriteLine(options);
        }

        public void AskForOption() {
            String userInput = Console.ReadLine();

            if (userInput == "1") {
                SignUp();
            } else if (userInput == "2") {
                LogIn();
            }
        }
        public void SignUp() {
            Console.WriteLine("\nChoose Username:");
            String chooseUsername = Console.ReadLine();
            Console.WriteLine("Choose Password");
            String choosePassword = Console.ReadLine();
            Console.WriteLine("Retype Password");
            String retypePassword = Console.ReadLine();
        }
        public void LogIn() {
            Console.WriteLine("\nUsername:");
            String username = Console.ReadLine();
            Console.WriteLine("\nPassword:");
            String password = Console.ReadLine();

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StartApplication start = new StartApplication();
            start.DisplayOptions();
            start.AskForOption();

        }
    }

}
