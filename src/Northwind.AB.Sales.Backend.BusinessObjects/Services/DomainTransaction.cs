using Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.Transactions;
using System.Transactions;

namespace Northwind.AB.Sales.Backend.BusinessObjects.Services;
internal class DomainTransaction : IDomainTransaction
{
    TransactionScope _transactionScope;

    public void BeginTransaction()
    {
        TransactionManager.ImplicitDistributedTransactions = true;
        _transactionScope = new TransactionScope(
            TransactionScopeOption.Required,
            new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            },
            TransactionScopeAsyncFlowOption.Enabled);
    }
    public void CommitTransaction() 
    {
        _transactionScope.Complete();
        Dispose();
    }
    public void Dispose()
    {
        _transactionScope?.Dispose();
    }
    public void RollbackTransaction() 
    {
        Dispose();
    }
}
