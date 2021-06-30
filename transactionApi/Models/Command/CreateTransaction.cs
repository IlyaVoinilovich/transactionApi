using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace transactionApi.Models
{
    public class CreateTransaction
    {
        public Guid Id { get; set; }
        public DateTime date { get; set; }
        public decimal balance { get; set; }
        public string currency { get; set; }
    }
}
