using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using transactionApi.Models;

namespace transactionApi.Interface
{
    public interface ITransaction
    {
        public Task<TransactionView> CreateTransaction(CreateTransactionCommand command,long idUser);
        public Task<IEnumerable<TransactionView>> GetTransactions(long IdUser);
        public Task<TransactionView> UpdateTransaction(CreateTransactionCommand command);

    }
}
