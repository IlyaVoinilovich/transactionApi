using Automatonymous;
using System;
using System.Threading.Tasks;
using transactionApi.Interface;

namespace transactionApi.StateMachine
{
    public class TransactionStateMachine : MassTransitStateMachine<TransactionState>
    {

        public TransactionStateMachine(ITransaction _transaction)
        {
            State(() => WaitingForResponce);
            Event(() => TransactionCreate, x => x.CorrelateById(ctx => ctx.Message.Transaction.Id).SelectId(context => Guid.NewGuid()));
            Event(() => WebWalletApproved, x => x.CorrelateById(ctx => ctx.Message.Transaction.Id));
            Event(() => WebWalletRevoked, x => x.CorrelateById(ctx => ctx.Message.Transaction.Id));

            CompositeEvent(() => TransactionApproved, x => x.ApprovementState, WebWalletApproved);

            Initially(
                When(TransactionCreate)
                    // Set received Investment to machine state
                    .Then(ctx => ctx.Instance.Transaction = ctx.Data.Transaction)
                    .TransitionTo(WaitingForResponce));

            During(WaitingForResponce,

                When(TransactionApproved)
                    // Add investment into portfolio
                   
                    .Finalize(),

                When(WebWalletRevoked)
                    .Finalize());

            SetCompletedWhenFinalized();
        }

        /// <summary>
        /// State waiting for responce from decision process
        /// </summary>
        public State WaitingForResponce { get; private set; }

        /// <summary>
        /// New investment occured on bus
        /// </summary>
        public Event<ITransactionCreate> TransactionCreate { get; private set; }

        /// <summary>
        /// Composite event investment approved
        /// </summary>
        public Event TransactionApproved { get; private set; }


        /// <summary>
        /// Order management approved the investment
        /// </summary>
        public Event<ICreateTransactionCommandWebWalletApproved> WebWalletApproved { get; private set; }

        /// <summary>
        /// Order management revoked the investment
        /// </summary>
        public Event<ICreateTransactionCommandWebWalletRevoked> WebWalletRevoked { get; private set; }
    }
}
