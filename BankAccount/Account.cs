using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Account
    {
        private string owner;

        /// <summary>
        /// Creates an account with a specific owner and a balance of 0
        /// </summary>
        /// <param name="accOwner"></param>
        public Account(string accOwner)
        {
            Owner = accOwner;
        }
        public string Owner
        {
            get { return owner; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(Owner)} cannot be null");
                }
                if (value.Trim() == string.Empty)
                {
                    throw new ArgumentException($"{nameof(Owner)} must have some text");
                }

                if (IsOwnerNameVaild(value))
                {
                    owner = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(owner)} can only be up to 20 characters A-Z/Spaces only");
                }

            }
        }
        /// <summary>
        /// Checks if owner name is less than or equal to 20 characters, A - Z 
        /// and whitespace characters are allowed 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool IsOwnerNameVaild(String ownerName)
        {
            char[] validCharacters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x'
                , 'y', 'z' };

            ownerName = ownerName.ToLower();

            const int MaxLengthOwnerName = 20;

            if (ownerName.Length > MaxLengthOwnerName)
            {
                return false;
            }


            foreach (char letter in ownerName)
            {
                if (letter != ' ' && !validCharacters.Contains(letter))
                {
                    return false;
                }
                
            }
            return true;
        }

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
