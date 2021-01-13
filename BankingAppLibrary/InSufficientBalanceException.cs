using System;
using System.Runtime.Serialization;

namespace BankingAppLibrary
{
    public class InSufficientBalanceException : ApplicationException
    {
        
        public InSufficientBalanceException(string message=null, Exception innerException=null) : base(message, innerException)
        {
        }
    }
}