using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace transactionApi.Models
{
    public class Transaction
    {
        [Key]
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public long Iduser { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public string Info { get; set; }

        public Transaction(DateTime date, long iduser, decimal balance, string currency, string info)
        {
            Date = date;
            Iduser = iduser;
            Balance = balance;
            Currency = currency;
            Info = info; 
        }
    }
}
