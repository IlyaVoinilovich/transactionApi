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
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public long User { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public string State { get; set; }
        public Transaction(Guid id,DateTime date,decimal balance,string currency,long user,string state)
        {
            Id = id;
            Date = date;
            User = user;
            Balance = balance;
            Currency = currency;
            State = state;
        }

    }
}
