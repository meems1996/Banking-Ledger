using System;
using System.Collections.Generic;

namespace BankLedger
{    
    class  StartApplication{
        static string ChooseUsername, ChoosePassword, RetypePassword, UserLoggedIn = null; // logged out if UserLoggedIn == null
        static bool LoggedOut = true; 
        static UserProfile NewUserObject;
        static double UserBalance;
        private static Dictionary<string, string> _user = new Dictionary<string, string>();
        private static Dictionary<string, int> _userBalance = new Dictionary<string, int>();
        private static Dictionary<string, int> _transactionHistory = new Dictionary<string, int>();

        public static void start() {
            if (LoggedOut == true) {
                DisplayOptions();
                AskForOption();
            }
        }
        public static void DisplayOptions() {
            Welcome.Title();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Welcome.center("1. Sign up       2. Log In");
            Console.ResetColor();
            Console.Write("$ ");
        }
        public static void AskForOption() {
            String userInput = Console.ReadLine();
            if (userInput == "1") {
                SignUp();
            } else if (userInput == "2") {
                foreach (var pair in _user) {
                 Console.WriteLine(pair);
                }
                 LogIn();
            } else {
                Console.Clear();
                Console.WriteLine("Unsupported action");
                start();
            }
        }

        public static void SignUp() {
            // String[] createUserProfile = new String[2]; 
            Console.WriteLine("\nSign Up By Choosing a Username and a Password.");
            Console.Write("\nChoose Username: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            ChooseUsername = Console.ReadLine();
            Console.ResetColor();

            Console.Write("Choose Password: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            ChoosePassword = Console.ReadLine();
            Console.ResetColor();
            Console.Write("Retype Password: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            RetypePassword = Console.ReadLine();
            Console.ResetColor();

            // // If the passwords match and the username fits, hash the password and save them into a map
            if (ChoosePassword == RetypePassword) {
                Console.Clear();

                foreach(var pair in _user) {
                    if (ChooseUsername == pair.Key) {
                        Console.WriteLine("Username taken");
                        SignUp();
                    } 
                }
                _user.Add(ChooseUsername, ChoosePassword);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSign up successful! You can log in now, " + ChooseUsername + "!  " + @"\(^-^)/");
                Console.ResetColor();
                start();

            } else if (ChoosePassword != RetypePassword) {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nPasswords don't match!    " + "(ಥ﹏ಥ)");
                Console.ResetColor();
                SignUp();
            }
        }
        public static void LogIn() {
            Console.WriteLine("\nLog in to your account by typing in your username and password.");
            Console.WriteLine("\nUsername:");
            Console.ForegroundColor = ConsoleColor.Red;
            String username = Console.ReadLine();
            Console.ResetColor();
            Console.WriteLine("\nPassword:");
            Console.ForegroundColor = ConsoleColor.Red;
            String password = Console.ReadLine();
            Console.ResetColor();

            if (_user.Count == 0) {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong credentials or user does not exist!" + "(ಥ﹏ಥ)");
                Console.ResetColor();

            }
            // iterate over the hashmap of users 
            foreach (var pair in _user) {
                if (username == pair.Key) {
                    LoggedOut = false;
                    NewUserObject = new UserProfile(0); // may need only balance
                   UserBalance = NewUserObject.Balance;
                    var transactionNum = _transactionHistory.Count + 1;
                    UserLoggedIn = pair.Key;

                    if (UserLoggedIn == "mimi") {
                       UserBalance = UserProfile.recordDeposit(UserBalance, 50);
                    }
                    Console.Clear();
                    Welcome.welcomeUser(UserLoggedIn);
                    Console.Write("\n$ ");
                    userProfile();
                }
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nWrong credentials  " + "(ಥ﹏ಥ)");
            Console.ResetColor();
        }
        public static void userProfile() {
            var userInput = Console.ReadLine();
                if (userInput == "logout") {
                    Console.Clear();
                    LoggedOut = true;
                    start();
                }
                if (userInput == "1") {
                    Console.WriteLine("\nUser Balance: " + UserBalance+ "\n");
                    Console.Write("\n$ ");
                    userProfile();
                }
                if (userInput == "2") {
                    Console.WriteLine("\nDeposit!");
                    Console.Write("\n$ ");
                    userProfile();
                }
                if (userInput == "3") {
                    Console.WriteLine("\nWithdrawal!");
                    Console.Write("\n$ ");
                    userProfile();
                }     
        }
    }
}
