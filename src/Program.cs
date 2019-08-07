using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BankLedger
{    
    class  StartApplication{
        // Initialized strings for username and passwords in SignUp(), and string that would hold the name of the logged in user 
        static string ChooseUsername, ChoosePassword, RetypePassword, UserLoggedIn = null; 
        // Boolean to inform if user is logged out, which is set to true in the beginning before any user is created or has logged in
        static bool LoggedOut = true; 
        // Initialize a UserProfile object which holds the Balance for each user
        static UserProfile NewUserObject;
        static double UserBalance;
        // Data Structures to hold the data for the users, their balance, and the history of their transactions.
        // The data is then joined together by a common ID which is the username of each user, since usernames are unique in this application
        private static Dictionary<string, string> _user = new Dictionary<string, string>();
        private static Dictionary<string, double> _userBalance = new Dictionary<string, double>();
        private static Dictionary<int, double> _innerTransactionHistory = new Dictionary<int, double>();
        private static Dictionary<string, Dictionary<int,double>> _transactionHistory = new Dictionary<string, Dictionary<int,double>>();
        // Start Application method, calls to display options for the user (sign up or login)
        public static void start() {
            if (LoggedOut == true) {
                Welcome.DisplayOptions();
                AskForOption();
            }
        }
        public static void AskForOption() {
            String userInputOptions = Console.ReadLine();

            // If statements for input 1 (sign up) and 2 (login) 
            if (userInputOptions == "1") {
                SignUp();
            } else if (userInputOptions == "2") {
                LogIn();
            } else {
                // if you press any other number then clears screen, adds the error message and makes you start over
                Console.Clear();
                Messages.ErrorMessage("Unsupported action  " + "(ಥ﹏ಥ)");
                start();
            }
        }
        public static void SignUp() {
            // User Sign Up Form 
            Console.Write("\nSign Up By Choosing a Username and a Password. \nChoose Username: ");
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

            // check if the two passwords (ChoosePassword and RetypePassword) match
            if (ChoosePassword == RetypePassword) {
                // iterate over _user map and if there is a user with the same username, print error
                // username should be unique
                foreach(var pair in _user) {
                    if (ChooseUsername == pair.Key) {
                        Messages.ErrorMessage("\nUsername taken");
                        SignUp();
                    } 
                }
                Console.Clear();
                // Create the 3 major tables needed for this assignment, each is defined by a Unique ID which is the username
                _user.Add(ChooseUsername, ChoosePassword);
                _userBalance.Add(ChooseUsername, 0);
                _innerTransactionHistory  = new Dictionary<int, double>(); 
                _transactionHistory.Add(ChooseUsername, _innerTransactionHistory);
                NewUserObject = new UserProfile(0); // may need only balance
                UserBalance = NewUserObject.Balance;
            
                // Success message when user signs up successfully, and then go back to the start
                Messages.SuccessMessage("\nSign up successful! You can log in now, " + ChooseUsername + "!  " + @"\(^-^)/");
                start();

                // else if the passwords don't match, let the user know and bring the sign up form again
            } else if (ChoosePassword != RetypePassword) {
                Messages.ErrorMessage("\nPasswords don't match!    " + "(ಥ﹏ಥ)");
                SignUp();
            }
        }
        public static void LogIn() {
            Console.WriteLine("\nLog in to your account by typing in your username and password.");
           // Ask for username
            Console.Write("\nUsername: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            String username = Console.ReadLine();
            Console.ResetColor();
            // Ask for password of the user 
            Console.Write("\nPassword: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            String password = Console.ReadLine();
            Console.ResetColor();

            // if there are no users, then provide an error message
            if (_user.Count == 0) {
                Console.Clear();
                Messages.ErrorMessage("User does not exist! " + "(ಥ﹏ಥ)");
            } 

            // Authenticate user by username and password
            if (_user.ContainsKey(username)) {
                if (_user[username] == password) {
                    LoggedOut = false;
                    var transactionNum = _transactionHistory.Count;
                    UserLoggedIn = username;
                    UserBalance = _userBalance[UserLoggedIn];
                    Console.Clear();
                    Welcome.welcomeUser(UserLoggedIn);
                    Messages.UserInputIndicator();
                    userProfile();
                }
            } else if (!(_user.ContainsKey(username))) {
                Messages.ErrorMessage("Wrong Credentials");
                LogIn();
            }
        }
        // The user profile option like check balance, record a deposit and withdrawal, and check transaction history  
        public static void userProfile() {
            string userInput = Console.ReadLine();
                // Logout  :)  
                if (userInput == "log") {
                    Console.Clear();
                    UserLoggedIn = null; // no logged in user 
                    LoggedOut = true; // user is logged out
                    start();
                }
                // Check user balance (How much money they have right now)
                if (userInput == "1") {
                    Console.WriteLine("\nUser Balance: " + _userBalance[UserLoggedIn] + "\n");
                    Messages.UserInputIndicator();
                    userProfile();
                }
                // Add money and add to transaction history
                if (userInput == "2") {
                    Console.Write("\nDeposit Money\nAmount: $");
                    var depositInput = Console.ReadLine();
                    if (!(Regex.IsMatch(depositInput, @"^\d+$"))) {
                        Messages.ErrorMessage("Must enter a number");
                        Messages.UserInputIndicator();
                        userProfile();
                    }
                    recordDeposit(Convert.ToDouble(depositInput));
                    _userBalance[UserLoggedIn] = UserBalance;
                    AddToTransactionHistory(UserLoggedIn, Convert.ToDouble(depositInput), 1);
                    Messages.UserInputIndicator();
                    userProfile();
                }
                // Withdraw money and add to transaction history
                if (userInput == "3") {
                    Console.Write("\nWithdraw Money\nAmount: $");
                    var withdrawalInput = Console.ReadLine();
                    if (!(Regex.IsMatch(withdrawalInput, @"^\d+$"))) {
                        Messages.ErrorMessage("Must enter a number");
                        Messages.UserInputIndicator();
                        userProfile();
                    }
                    recordWithdrawal(Convert.ToDouble(withdrawalInput));
                    _userBalance[UserLoggedIn] = UserBalance;

                    AddToTransactionHistory(UserLoggedIn, Convert.ToDouble(withdrawalInput), 0);
    
                    Messages.UserInputIndicator();
                    userProfile();
                } 
                if (userInput == "4") {
                    Console.WriteLine("Transaction History\nNegative values indicate withdrawal\nPositive values indicate deposits\n");
                    Messages.SuccessMessage("[ID, Amount]");

                    foreach (var outer in _transactionHistory) {
                        // Console.WriteLine(outer);
                        if (outer.Key.Contains(UserLoggedIn)) {
                            if (outer.Value.Count == 0) {
                                Console.WriteLine("-- User {0} does not have any transactions", outer.Key);
                            }

                            foreach (var inner in outer.Value) {
                                Console.WriteLine(inner);
                            }
                        }
                    }

                    Messages.UserInputIndicator();
                    userProfile();

                } else {
                    Messages.ErrorMessage("Not an option" + "(ಥ﹏ಥ)");
                    Messages.UserInputIndicator();
                    userProfile();
                }
        }
        // Add each transaction to transaction history Dictionary to keep track of each one 
        public static void AddToTransactionHistory(string user, double transactionAmount, int type) {
            int transactionId = 0;

            if (type == 0) {
                transactionAmount *= -1;
            }

            if (_transactionHistory.ContainsKey(user)) {
                var userTransactions = _transactionHistory[user];
                transactionId = userTransactions.Count + 1;
                userTransactions.Add(transactionId, transactionAmount);
                _transactionHistory[user] = userTransactions;
            }
        } 
        // Record a deposit method, takes in amount to be deposited as the parameter, returns the new balance
        public static double recordDeposit(double newDeposit) {
           // you can only add if new deposit is more than 0. You can't add negative amount of money
           if (newDeposit > 0) {
               UserBalance = UserBalance + newDeposit;
               Console.ForegroundColor = ConsoleColor.Green;
               Messages.SuccessMessage("Deposit Successful");
               Console.ResetColor();
           } else if (newDeposit < 0) { // If deposit is less than 0, then show an error message because you can't add negative amount when it comes to money
               Messages.ErrorMessage("You can't add negative number");
               Messages.UserInputIndicator();
               userProfile();
           }  else {
               Messages.ErrorMessage("Unsupported action  " + "(ಥ﹏ಥ)");
               Messages.UserInputIndicator();
               userProfile();
           }

           return UserBalance;
        }
        // Record a withdrawal method, takes in the amount wished to be withdrawn as parameter, returns the new balance
        public static double recordWithdrawal(double newWithdrawal) {
           // you can only withdraw if balance is more than the amount you wish to withdraw (no matter how much we would like the alternative XD )
           if (UserBalance > newWithdrawal) {
              UserBalance = UserBalance - newWithdrawal;
           } else {
               Messages.ErrorMessage("Can't withdraw amount greater than balance");
               Messages.UserInputIndicator();
               userProfile();
           }
            return UserBalance;
        }
    }
}
