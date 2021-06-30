using System;

namespace transactionApi.Models
{
    public class TransactionView
    {
        private readonly Transaction _transaction;
        public TransactionView(Transaction transaction)
        {
            _transaction = transaction;
        }
        public DateTime date => _transaction.date;
        public decimal balance => _transaction.Balance;
        public string currency => _transaction.Currency;
    }
}
