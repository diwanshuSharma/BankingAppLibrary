using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingAppLibrary.UnitTestProject
{

    [TestClass]
    public class AccountManagerUnitTest
    {

        
        AccountManager target = null;
        Account saving = null;
        Account saving2 = null;

        [TestInitialize]
        public void Initialize()
        {
            target = new AccountManager();
            saving = new Account { 
                Name = "name",
                Pin = 1234,
                Balance = 1000
            };

            saving2 = new Account
            {
                Name = "name",
                Pin = 1234,
                Balance = 1000
            };
        }

        [TestCleanup]
        public void CleanUp()
        {
            target = null;
            saving = null;
            saving2 = null;
        }

        ///************** for Open() ******************************/

        //[TestMethod]
        //// on successfully creation of account
        //// check for open date
        //public void Open_OnSuccess_SetOpenDate()
        //{
        //    Account account = target.Open(saving, "SAVINGS");

        //    Assert.AreEqual(DateTime.Now.Date, account.OpeningDate);
        //}

        //[TestMethod]
        //public void Open_OnSuccess_SetStatusToActive()
        //{

        //    Account account = target.Open(saving, "SAVINGS");

        //    Assert.AreEqual(true, account.IsActive);
        //}


        //[TestMethod]
        //[ExpectedException(typeof(AccountAlredayActiveException))]
        //public void Open_WithActiveAcount_ShouldThrowExp()
        //{
        //    saving.IsActive = true;

        //    Account account = target.Open(saving, "SAVINGS");

        //}


        ///************** for Close() ******************************/

        //[TestMethod]
        //public void Close_OnSuccess_SetCloseDate()
        //{
        //    saving.IsActive = true;
        //    saving.ClosingDate = DateTime.Now.Date;
        //    saving.Balance = 0;

        //    Account account = target.Close(saving, "SAVINGS");

        //    Assert.AreEqual(DateTime.Now.Date, account.ClosingDate);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(AccountDoesNotExistException))]
        //public void Close_WithoutActiveAcount_ShouldThrowExp()
        //{
        //    saving.Balance = 0;
        //    Account account = target.Close(saving, "SAVINGS");
        //}

        //[TestMethod]
        //public void Close_OnSuccess_SetStatusToInActive()
        //{
        //    saving.Balance = 0;
        //    saving.IsActive = true;
        //    Account account = target.Close(saving, "SAVINGS");

        //    Assert.AreEqual(false, account.IsActive);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(BalanceNotZeroException))]
        //public void Close_ActiveAccountBalance_ShouldThrowException()
        //{
        //    saving.IsActive = true;

        //    Account account = target.Close(saving, "SAVINGS");
        //}

        //[TestMethod]
        //[ExpectedException(typeof(InvalidPinException))]
        //public void Close_InvalidPIN_ShouldThrowException()
        //{
        //    saving.IsActive = true;
        //    saving.Pin = 10;
        //    saving.Balance = 0;

        //    target.Close(saving, "SAVINGS");
        //}



        ///**************************** Withdraw ******************************/

        //[TestMethod]
        //public void Withdraw_OnSuccess_CheckBalance()
        //{
        //    saving.IsActive = true;

        //    double amount = 50;
        //    double expeced = saving.Balance - amount;

        //    target.Withdraw(saving, 50);

        //    double actual = saving.Balance;

        //    Assert.AreEqual(actual, expeced);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(AccountDoesNotExistException))]
        //public void Withdraw_InActiveAccount_ShouldThrowException()
        //{
        //    target.Withdraw(saving, 50);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(InSufficientBalanceException))]
        //public void Withdraw_InSufficientBalance_ShouldThrowException()
        //{
        //    saving.Balance = 100;
        //    saving.IsActive = true;

        //    double amount = 20000;

        //    target.Withdraw(saving, amount);
        //}

        ///*
        //[TestMethod]
        //[ExpectedException(typeof(InvalidPinException))]
        //public void Withdraw_InvalidPIN_ShouldThrowException()
        //{
        //    AccountManager target = new AccountManager();

        //    Saving saving = new Saving
        //    {
        //        Name = "name",
        //        Pin = 10,
        //        Balance = 1000,
        //        IsActive = true
        //    };

        //    double amount = 20;

        //    target.Withdraw(saving, amount);
        //}
        //*/


        ///**************************** Deposit ******************************/


        [TestMethod]
        public void Deposit_OnSuccess_CheckBalance()
        {
            saving.IsActive = true;

            double amount = 50;
            double expeced = saving.Balance + amount;

            target.Deposit(saving, 50);

            double actual = saving.Balance;

            Assert.AreEqual(actual, expeced);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountDoesNotExistException))]
        public void Deposit_InActiveAccount_ShouldThrowException()
        {
            target.Deposit(saving, 500);
        }

        ///*
        //[TestMethod]
        //[ExpectedException(typeof(InvalidPinException))]
        //public void Deposit_InvalidPIN_ShouldThrowException()
        //{
        //    AccountManager target = new AccountManager();

        //    Saving saving = new Saving
        //    {
        //        Name = "name",
        //        Pin = 10,
        //        Balance = 1000,
        //        IsActive = true
        //    };

        //    double amount = 20;

        //    target.Deposit(saving, amount);
        //}
        //*/

        [TestMethod]
        [ExpectedException(typeof(InvalidAmountTypeException))]
        public void Deposit_InvalidAmountToDeposit_ShouldThrowException()
        {
            saving.IsActive = true;

            double amount = -20;

            target.Deposit(saving, amount);
        }


        ///******************************** Transfer ********************************/

        //[TestMethod]
        //public void Transfer_OnSuccess_CheckBalance()
        //{
        //    saving.IsActive = true;
        //    saving2.IsActive = true;

        //    double expected = saving.Balance + saving2.Balance;

        //    target.Transfer(saving, saving2, 100);

        //    Assert.AreEqual(expected, saving.Balance + saving2.Balance);
        //}

        /************************************  GetAllSavingAccounts  ************************************/

        [TestMethod]
        public void GetAllSavingAccounts_OnSuccess_CheckUniqueness()
        {
            var actual = target.GetAllSavingsAccounts();

            CollectionAssert.AllItemsAreUnique(actual);

        }

        [TestMethod]
        public void GetAllSavingAccounts_OnSuccess_CheckType()
        {
            var actual = target.GetAllSavingsAccounts();

            CollectionAssert.AllItemsAreInstancesOfType(actual, typeof(Saving));

        }

        /************************************  GetAllCurrentAccounts  ************************************/

        [TestMethod]
        public void GetAllCurrentAccounts_OnSuccess_CheckUniqueness()
        {
            var actual = target.GetAllCurrentAccounts();

            CollectionAssert.AllItemsAreUnique(actual);

           
            // get All active accounts
            // making use of a record
            // is first record is there
            // beacuse its IsActive = true
            // #### compare with the known record (information) #####
            //CollectionAssert.Contains(actual, target.accounts[0]);
            //Assert.That(actual.Any(p => p.IsActive == true));
        }

        [TestMethod]
        public void GetAllCurrentAccounts_OnSuccess_CheckType()
        {
            var actual = target.GetAllCurrentAccounts();

            CollectionAssert.AllItemsAreInstancesOfType(actual, typeof(Current));

        }
        /********************************** GetAllAccountsHavingBalance *************************/

        [TestMethod]
        [ExpectedException(typeof(InvalidAccountTypeException))]
        public void GetAllAccountsHavingBalance_OnSuccess_ShouldThrowException()
        {
            target.GetAllAccountsHavingBalance();
        }



        /*
[TestMethod]
public void AllSavingsAccount_OnSucess_ShouldGetOnlySavingsAccounts()
{​​​​​
var actual = target.GetAllSavingsAccounts();
CollectionAssert.AllItemsAreInstancesOfType(actual,typeof(Savings));
}​​​​​

 [TestMethod]
public void AllCurrentAccount_OnSucess_ShouldGetOnlyCurrentAccounts()
{​​​​​
var actual = target.GetAllCurrentAccounts();
CollectionAssert.AllItemsAreInstancesOfType(actual, typeof(Current));
}​​​​​
 [TestMethod]
public void AllActiveAccounts_OnSucess_ShouldGetOnlyActiveAccounts()
{​​​​​
var actual = target.GetAllActiveAccounts();
CollectionAssert.Contains(actual, target.accounts[0]);
}​​​​​
 [TestMethod]
public void AccountsHavingBalance_OnSucess_ShouldGetAccountsHavingBalance()
{​​​​​
var actual = target.GetAllAccountsHavingBalance();
Assert.AreNotEqual(actual[0].Balance, 0);
}​​​​​

         */

    }
}
