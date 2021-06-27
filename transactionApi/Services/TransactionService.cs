using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using transactionApi.Interface;
using transactionApi.Models;

namespace transactionApi.Services
{
    public class TransactionService:ITransaction 
    {
        private readonly TransactionBdContext _transactionBdContext;
        public TransactionService(TransactionBdContext transactionBdContext)
        {
            _transactionBdContext = transactionBdContext;
        }

        public async Task<TransactionView> CreateTransaction(CreateTransactionCommand command,long IdUser)
        {
            var transaction = new Transaction(command.date, IdUser, command.balance, command.currency,command.info);
            await _transactionBdContext.Transactions.AddAsync(transaction);
            await _transactionBdContext.SaveChangesAsync();
            return new TransactionView(transaction);
        }
        public async Task<IEnumerable<TransactionView>> GetTransactions(long IdUser)
        {
            return await _transactionBdContext.Transactions.AsNoTracking().Where(x => x.Iduser == IdUser).Select(x => new TransactionView(x)).ToArrayAsync();
        }
    }
}
