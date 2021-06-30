using Automatonymous;
using System;
using transactionApi.Models;

namespace transactionApi.StateMachine
{
    public class TransactionState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }

        public CreateTransactionCommand Transaction { get; set; }

        public State State { get; set; }

        public CompositeEventStatus ApprovementState { get; set; }
    }
}