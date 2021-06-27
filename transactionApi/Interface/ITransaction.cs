using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using transactionApi.Models;

namespace transactionApi.Interface
{
    public interface ITransaction
    {
        public Task<TransactionView> CreateTransaction(CreateTransactionCommand command, long IdUser);
        public Task<IEnumerable<TransactionView>> GetTransactions(long IdUser);

    }
}
