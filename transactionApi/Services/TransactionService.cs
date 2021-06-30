﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
        public TransactionService(TransactionBdContext transactionBdContext )
        {
            _transactionBdContext = transactionBdContext;
        }

        public async Task<TransactionView> CreateTransaction(CreateTransactionCommand command, long IdUser)
        {
            var transaction = new Transaction(command.Id,command.date,command.balance,command.currency, IdUser,"no");
            await _transactionBdContext.Transactions.AddAsync(transaction);
            await _transactionBdContext.SaveChangesAsync();
            return new TransactionView(transaction);
        }
        public async Task<TransactionView> UpdateTransaction(CreateTransactionCommand command)
        {
            var transaction = new Transaction(command.Id,command.date,command.balance,command.currency,command.idUser,"yes");
            _transactionBdContext.Entry(transaction).State = EntityState.Modified;
            await _transactionBdContext.SaveChangesAsync();
            return new TransactionView(transaction);
        }

        public async Task<IEnumerable<TransactionView>> GetTransactions(long IdUser)
        {
            return await _transactionBdContext.Transactions.AsNoTracking().Where(x => x.User == IdUser).Select(x => new TransactionView(x)).ToArrayAsync();
        }
    }
}
