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
        [TestMethod()]
        public void Deposit_APositiveAmount_AddToBalance()
        {
            Account acc = new Account("J doe");
            acc.Deposit(100);

            Assert.AreEqual(100, acc.Balance);
        }

        [TestMethod]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            Account acc = new Account("J doe");
            double depositAmount = 100;
            double expeectedReturn = 100;
            double returnValue = acc.Deposit(depositAmount);
            Assert.AreEqual(expeectedReturn, returnValue);
        }
    }
}