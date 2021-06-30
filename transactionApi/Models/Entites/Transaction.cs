using Automatonymous;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace transactionApi.Models
{
    [Serializable]
    public class Transaction
    {
        [Key]
        public long Id { get; set; }
        public DateTime date { get; set; }
        public long IdUser { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }

        public Transaction(DateTime dateTime,decimal balance,string currency,long User)
        {
            date = dateTime;
            Balance = balance;
            Currency = currency;
            IdUser = User;
        }
        public Transaction()
        {
        }
    }
}
