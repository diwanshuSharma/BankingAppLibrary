using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BankingAppLibrary
{
    public class Account
    {
        public int AccNo { get; set; }
        public string Name { get; set; }
        public int Pin { get; set; }
        public bool IsActive { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public double Balance { get; set; }
    }

    public class Saving : Account
    {
        public string Gender { get; set; }
    }

    public class Current : Account
    {
        public string CompanyName { get; set; }
    }

    /// <summary>
    /// Business Class - Must Do Unit Testing
    /// </summary>
    public class AccountManager
    {


        public List<Account> accounts = new List<Account>
            {
            new Saving{Name="acc1", Balance = 0 ,IsActive=true},
            new Saving{Name="acc2", Balance = 13000 ,IsActive=true},
            new Current{Name="acc3", Balance = 0 ,IsActive=false},
            new Saving{Name="acc4", Balance = 1000 ,IsActive=false},
            };

        public List<Account> GetAllSavingsAccounts()
        {
            List<Account> SavingsAccounts = new List<Account>();

            foreach (var item in accounts)
            {
                if (item is Saving)
                    SavingsAccounts.Add(item);
            }

            return SavingsAccounts;
        }
        public List<Account> GetAllCurrentAccounts()
        {
            List<Account> CurrentAccounts = new List<Account>();

            foreach (var item in accounts)
            {
                if (item is Current)
                    CurrentAccounts.Add(item);
            }

            return CurrentAccounts;
        }

        public List<Account> GetAllActiveAccounts()
        {
            List<Account> ActiveAccounts = new List<Account>();

            foreach (var item in accounts)
            {
                if (item.IsActive)
                    ActiveAccounts.Add(item);
            }

            return ActiveAccounts;
        }

        public List<Account> GetAllAccountsHavingBalance()
        {
            List<Account> BalanceAccounts = new List<Account>();

            foreach (var item in accounts)
            {
                if (item.Balance != 0)
                {
                    if (!item.IsActive)
                        throw new InvalidAccountTypeException("InActive Account Can not have balance");

                    BalanceAccounts.Add(item);
                }
            }

            return BalanceAccounts;
        }














        public Account Open(Account account, string accType)
        {
            if (account == null)
                throw new Exception("Invalid Input");

            //verify the boundary condition
            // boundary exception
            if (string.IsNullOrEmpty(accType))
                throw new InvalidAccountTypeException("Invalid Account Type");


            if (account.IsActive)
                throw new AccountAlredayActiveException("Account Exist");

            if (account.Balance <= 0)
                throw new InvalidAmountTypeException("Invalid Amount");


            if (account.Pin < 999 || account.Pin > 10000)
                throw new InvalidPinException("Invalid Pin");

            account.OpeningDate = DateTime.Now.Date;
            account.IsActive = true;

            return account;
        }

        public Account Close(Account account, string accType)
        {
            if (account == null)
                throw new Exception("Invalid Input");

            //verify the boundary condition
            // boundary exception
            if (string.IsNullOrEmpty(accType))
                throw new InvalidAccountTypeException("Invalid Account Type");

            if (!account.IsActive)
                throw new AccountDoesNotExistException("Account Does Not Exist");

            if (account.Balance != 0)
                throw new BalanceNotZeroException("Balance Not Zero");

            if (account.Pin < 999 || account.Pin > 10000)
                throw new InvalidPinException("Invalid Pin");

            account.ClosingDate = DateTime.Now.Date;
            account.IsActive = false;

            return account;
        }

        public void Withdraw(Account account, double amount)
        {
            if (account.Balance < amount)
                throw new InSufficientBalanceException();

            if (!account.IsActive)
                throw new AccountDoesNotExistException("Account Does Not Exist");

            if (account.Pin < 999 || account.Pin > 10000)
                throw new InvalidPinException("Invalid Pin");

            account.Balance -= amount;

        }

        public void Deposit(Account account, double amount)
        {
            
            if (!account.IsActive)
                throw new AccountDoesNotExistException("Account Does Not Exist");

            /*
            if (account.Pin < 999 || account.Pin > 10000)
                throw new InvalidPinException("Invalid Pin");
            */

            if (amount <= 0)
                throw new InvalidAmountTypeException("Amount to to deposited can not be negative");

            account.Balance += amount;

        }

        public void Transfer(Account account1, Account account2, double amount)
        {
            if (!account1.IsActive || !account2.IsActive)
                throw new AccountDoesNotExistException("Account Does Not Exist");

            if (account1.Pin < 999 || account1.Pin > 10000 || account2.Pin < 999 || account2.Pin > 10000)
                throw new InvalidPinException("Invalid Pin");

            if (amount < 1)
                throw new InvalidAmountTypeException("Amount to to transfer can not be negative");

            account1.Balance -= amount;
            account2.Balance += amount;
        }


    }

    public class BalanceNotZeroException : ApplicationException
    {
        public BalanceNotZeroException(string message = null, Exception innerException = null) : base(message, innerException)
        {
        }
    }

    public class AccountDoesNotExistException : ApplicationException
    {
        
        public AccountDoesNotExistException(string message = null, Exception innerException = null) : base(message, innerException)
        {
        }
    }

    public class InvalidAccountTypeException : ApplicationException
    {
        public InvalidAccountTypeException(string msg = null, Exception inner = null): base(msg, inner)
        {

        }
    }

    public class InvalidAmountTypeException : ApplicationException
    {
        public InvalidAmountTypeException(string msg = null, Exception inner = null) : base(msg, inner)
        {

        }
    }

    public class InvalidPinException : ApplicationException
    {
        public InvalidPinException(string msg = null, Exception inner = null) : base(msg, inner)
        {

        }
    }

    public class AccountAlredayActiveException : ApplicationException{ 
    
        public AccountAlredayActiveException(string msg = null, Exception inner = null) : base(msg, inner)
        {

        }

    }

}
