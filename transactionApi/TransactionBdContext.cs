using Microsoft.EntityFrameworkCore;
using transactionApi.Models;

namespace transactionApi
{
    public class TransactionBdContext: DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Transaction> Transactions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public TransactionBdContext(DbContextOptions<TransactionBdContext> options) : base(options)
        {
            if (Database.CanConnect() == false)//проверка существует ли бд 
                Database.EnsureCreated();   // создаем бд с новой схемой
        }
    }
}
