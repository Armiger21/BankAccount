using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;

        public AccountTests() 
        {
            acc = new Account("J doe");
        }   

        [TestMethod()]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(1.99)]
        [DataRow(9_999.99)]
        public void Deposit_APositiveAmount_AddToBalance(double depositAmount)
        {
            acc.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, acc.Balance);
        }

        [TestMethod]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            double depositAmount = 100;
            double expeectedReturn = 100;
            double returnValue = acc.Deposit(depositAmount);
            Assert.AreEqual(expeectedReturn, returnValue);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {

            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => acc.Deposit(invalidDepositAmount));
        }

        [TestMethod]
        public void Withdraw_PositiveAmount_DecreasesBalance()
        {
            double initialDeposit = 100;
            double withdrawalAmount = 50;
            double expectedBalance = initialDeposit - withdrawalAmount;

            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawalAmount);

            double actualBalance = acc.Balance;

            Assert.AreEqual(expectedBalance, actualBalance);
        }

        [TestMethod]
        public void Withdraw_PositiveAmount_ReturnsUpdatedBalance()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Withdraw_PositiveAmount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException()
        {
            Assert.Fail();
        }
    }



}