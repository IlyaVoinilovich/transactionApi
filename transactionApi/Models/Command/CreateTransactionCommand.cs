using System;

namespace transactionApi.Models
{
    public class CreateTransactionCommand
    {
        public DateTime date { get; set; }
        public decimal balance { get; set; }
        public string currency { get; set; }
        public string info { get; set; }
    }
}
