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
        [TestCategory("Deposit")]
        public void Deposit_APositiveAmount_AddToBalance(double depositAmount)
        {
            acc.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, acc.Balance);
        }

        [TestMethod]
        [TestCategory("Deposit")]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            double depositAmount = 100;
            double expeectedReturn = 100;
            double returnValue = acc.Deposit(depositAmount);
            Assert.AreEqual(expeectedReturn, returnValue);
        }

        [TestMethod]
        [TestCategory("Deposit")]
        [DataRow(-1)]
        [DataRow(0)]
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {

            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => acc.Deposit(invalidDepositAmount));
        }

        [TestMethod]
        [TestCategory("Withdraw")]
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
        [TestCategory("Withdraw")]
        [DataRow(100, 50)]
        [DataRow(100, .99)]
        public void Withdraw_PositiveAmount_ReturnsUpdatedBalance(double initialDeposit, double withdrawalAmount)
        {
            double expectedBalance = initialDeposit - withdrawalAmount;
            acc.Deposit(initialDeposit);

            double returnedBalance = acc.Withdraw(withdrawalAmount);

            Assert.AreEqual(expectedBalance, returnedBalance);
        }

        [TestMethod()]
        [TestCategory("Withdraw")]
        [DataRow(0)]
        [DataRow(-.01)]
        [DataRow(-1000)]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException(double withdrawlAmount)
        {

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Withdraw(withdrawlAmount));
        }

        [TestMethod]
        [TestCategory("Withdraw")]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException()
        {
            double withdrawAmount = 1000;

            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdrawAmount));
        }

        [TestMethod]
        public void Owner_SetAsNull_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => acc.Owner = null);
        }

        [TestMethod]
        public void Owner_SetAsWhiteSpaceOrEmptyString_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = String.Empty);
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = "   ");

        }

        [TestMethod]
        [DataRow("Joe")]
        [DataRow("Joe Ortiz")]
        [DataRow("Joseph Ortizio Smith")]
        public void Owner_SetAsUpTo20Characters_SetsSuccessfully(string ownerName)
            {
                acc.Owner = ownerName;
                Assert.AreEqual(ownerName, acc.Owner);
            }

            [TestMethod]
            [DataRow("Joe 3rd")]
            [DataRow("Joseph Ortizio Smiths")]
            [DataRow("#$%$")]
            public void Owner_InvalidOwnerName_ThrowsArgumentException(string ownerName)
            {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = ownerName);
            }
        }
    }