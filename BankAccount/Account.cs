using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Account
    {
        /// <summary>
        /// Creates an account with a specific owner and a balance of 0
        /// </summary>
        /// <param name="accOwner"></param>
        public Account(string accOwner)
        {
            Owner= accOwner;
        }
        public string Owner { get; set; }

        public double Balance { get; private set; }
        /// <summary>
        /// Add a specified amount of money to the account
        /// </summary>
        /// <param name="amt"></param>
        public double Deposit(double amt)
        {
            if (amt <= 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(amt)}Amt must be more than 0");
            }
            Balance += amt;
            return Balance;
        }
        /// <summary>
        /// Withdraws an amount of money from the balance 
        /// </summary>
        /// <param name="amt">The positive amount of money to be taken from the balance </param>
        public double Withdraw(double amount)
        { 
            if (amount > Balance)
            {
                throw new ArgumentException($"{nameof(amount)} cannot be greater than {nameof(Balance)}");
            }
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(amount)} must be greater than 0");
            }
            Balance -= amount;
            return Balance;
        
        }
    }
}
