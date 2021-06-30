
using transactionApi.Models;

namespace transactionApi.Interface
{
    public interface ICreateTransactionCommandWebWalletApproved
    {
        /// <summary>
        /// Approved investments
        /// </summary>
        CreateTransactionCommand Transaction { get; set; }
    }
}