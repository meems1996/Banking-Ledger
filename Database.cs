using System; 
using System.Collections.Generic;


namespace BankLedgerss {
   class Database{
       public static Dictionary<string, string> user = new Dictionary<string, string>();

        //  Add user and password to database Database 
        public static void ReadDatabase(String username, String password) {
            user.Add(username, password);
        }
        // Read from user database
        public static void ReadDatabase() {
            // print the hashmap to see what is in it
            foreach (var pair in user) {
                Console.WriteLine("\nUsername:" + pair.Key + " Password: " + pair.Value);
            }
        }
   }
}
