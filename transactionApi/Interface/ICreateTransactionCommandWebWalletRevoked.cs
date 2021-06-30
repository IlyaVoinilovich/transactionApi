
using transactionApi.Models;

namespace transactionApi.Interface
{
    public interface ICreateTransactionCommandWebWalletRevoked
    {
        CreateTransactionCommand Transaction { get; set; }
    }
}
