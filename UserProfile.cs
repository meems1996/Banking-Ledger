using System;
using System.Collections.Generic;

namespace BankLedger {
    public class UserProfile {
        public double Balance;
        public static double recordDeposit(double currentDeposit, double newDeposit) {
            currentDeposit = currentDeposit + newDeposit;
            return currentDeposit;
        }
        public static double recordWithdrawal(double currentDeposit, double newWithdrawal) {
            currentDeposit = currentDeposit - newWithdrawal;
            return currentDeposit;
        }
        public UserProfile(double balance) {
            Balance = balance;
        }
    }
}