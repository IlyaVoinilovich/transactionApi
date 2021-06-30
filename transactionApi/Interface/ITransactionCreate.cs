
using transactionApi.Models;

namespace transactionApi.Interface
{
    public interface ITransactionCreate
    {
        CreateTransactionCommand Transaction { get; set; }
    }
}
