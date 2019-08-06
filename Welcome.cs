using System; 

namespace BankLedger {

    public class Welcome {
        // Show the title Welcome to Bank Ledger
        public static void Title() {
            // center("\n\n");
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

        public static void welcomeUser(string userName) {
            center("==========================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            center("Welcome, " + userName);
            Console.ResetColor();
            center("==========================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            center("1. Balance\t" + "2. Deposit\t" + "3. Withdrawal\t" +"4. Transaction History");
            Console.ResetColor();
        }
    }
}