using System;

namespace BankLedger
{
    public class Messages
    {
        // Method to display the indicator for user to write some sort of input
        public static void UserInputIndicator()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n> ");
            Console.ResetColor();
        }
        // Error message template, in red
        public static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        // Success message template, in green 
        public static void SuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}