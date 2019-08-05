using System;
using System.Collections.Generic;

namespace BankLedger
{    
    class  StartApplication{
        static String chooseUsername, choosePassword;
        private static Dictionary<string, string> user = new Dictionary<string, string>();

        public static void start() {
            DisplayOptions();
            AskForOption();
        }
        public static void DisplayOptions() {
            Title();
            Console.ForegroundColor = ConsoleColor.Magenta;
            center("1. Sign up       2. Log In");
            Console.ResetColor();
            Console.Write("$ ");
        }

        public static void AskForOption() {
            String userInput = Console.ReadLine();

            if (userInput == "1") {
                SignUp();
            }

            if (userInput == "2") {
                 LogIn();
                // prints the data (user, password)
                 foreach (var pair in user) {
                Console.WriteLine("\nUsername:" + pair.Key + " Password: " + pair.Value);
            }
            }

        }

        public static void SignUp() {
            // String[] createUserProfile = new String[2]; 
            Console.WriteLine("\nSign Up By Choosing a Username and a Password.");
            Console.Write("\nChoose Username: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            chooseUsername = Console.ReadLine();
            Console.ResetColor();

            Console.Write("Choose Password: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            choosePassword = Console.ReadLine();
            Console.ResetColor();
            Console.Write("Retype Password: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            String retypePassword = Console.ReadLine();
            Console.ResetColor();

            // If the passwords match and the username fits, hash the password and save them into a map
            if (choosePassword == retypePassword) {
                // return the user name and the password 
                // createUserProfile[0] = chooseUsername;
                // createUserProfile[1] = choosePassword; 
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSign up successful! You can log in now!  " + @"\(^-^)/");
                Console.ResetColor();
                user.Add(chooseUsername, choosePassword);

            } else if (choosePassword != retypePassword) {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nPasswords don't match!    " + "(ಥ﹏ಥ)");
                Console.ResetColor();
                SignUp();
            }
        }
        public static void LogIn() {
            Console.Clear();
            // think of more efficient way of doing this
            foreach (var pair in user) {
                center("==========================");
                Console.ForegroundColor = ConsoleColor.Yellow;
                center("Welcome, " + pair.Key);
                Console.ResetColor();
                center("==========================");
                center("\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                center("1. Make Transaction\t" + "2. Make Widthdrawal\t" +"3. Check Transaction History");
                Console.ResetColor();
            }

            Console.WriteLine("\nLog in to your account by typing in your username and password.");
            Console.WriteLine("\nUsername:");
            Console.ForegroundColor = ConsoleColor.Red;
            String username = Console.ReadLine();
            Console.ResetColor();
            Console.WriteLine("\nPassword:");
            Console.ForegroundColor = ConsoleColor.Red;
            String password = Console.ReadLine();
            Console.ResetColor();
            Console.WriteLine("In Login");
        }

// Show the title Welcome to Bank Ledger
        public static void Title() {
            center("\n\n");
            center("____              _      _              _                 ");
            center(@"|  _ \            | |    | |            | |                ");
            center("| |_) | __ _ _ __ | | __ | |     ___  __| | __ _  ___ _ __ ");
            center(@"|  _ < / _` | '_ \| |/ / | |    / _ \/ _` |/ _` |/ _ \ '__|");
            center("| |_) | (_| | | | |   <  | |___|  __/ (_| | (_| |  __/ |   ");
            center(@"|____/ \__,_|_| |_|_|\_\ |______\___|\__,_|\__, |\___|_|   ");
            center("                                           __/ |          ");
            center("                                          |___/           ");
            center("\n");
        }

        public static void center(String message) {
            int screenWidth = Console.WindowWidth;
            int stringWidth = message.Length;
            int spaces = (screenWidth / 2) + (stringWidth / 2); 
            Console.WriteLine(message.PadLeft(spaces));
        }
    }
}
