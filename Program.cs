using System;
using System.Net;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using ServiceStack.Redis;
using ServiceStack;
using ServiceStack.Text;
using ServiceStack.DataAnnotations;

namespace BankLedger
{    
    class  StartApplication{
        public void DisplayOptions() {
            Console.ForegroundColor = ConsoleColor.White;

            var signuptext = "1. Sign up";
            var logintext = "2. Log In";

            Console.WriteLine("=============================================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("           Welcome to Bank Ledger");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=============================================");

            Console.Write(signuptext);
            Console.Write("     ");
            Console.WriteLine(logintext);
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
            var retypepassword = "Retype Password";

            Console.WriteLine("\nSign Up By Choosing a Username and a Password.");
            Console.WriteLine("\nChoose Username:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            String chooseUsername = Console.ReadLine();
            Console.ResetColor();
            Console.WriteLine("Choose Password");
            String choosePassword = Console.ReadLine();
            Console.WriteLine(retypepassword);
            Console.ForegroundColor = ConsoleColor.Yellow;
            String retypePassword = Console.ReadLine();
            Console.ResetColor();
        }
        public void LogIn() {
            Console.WriteLine("\nLog in to your account by typing in your username and password.");
            Console.WriteLine("\nUsername:");
            Console.ForegroundColor = ConsoleColor.Red;
            String username = Console.ReadLine();
            Console.ResetColor();
            Console.WriteLine("\nPassword:");
            Console.ForegroundColor = ConsoleColor.Red;
            String password = Console.ReadLine();
            Console.ResetColor();

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var redisManager = new RedisManagerPool("localhost:6379");
            
            using (var client = redisManager.GetClient()) {
                //client.Set("foo", "bar");
                Console.WriteLine("foo={0}", client.Get<String>("mystring"));
            }

            StartApplication start = new StartApplication();
            start.DisplayOptions();
            start.AskForOption();
        }
    }
}
