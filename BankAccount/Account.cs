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
            Balance += amt;
            return Balance;
        }
        /// <summary>
        /// Withdraws an amount of money from the balance 
        /// </summary>
        /// <param name="amt">The positive amount of money to be taken from the balance </param>
        public void Withdraw(double amt)
        { throw new NotImplementedException(); 
        
        }
    }
}
