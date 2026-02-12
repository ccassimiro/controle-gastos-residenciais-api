using CGR.Domain.Entities;
using CGR.Domain.Interfaces;
using CGR.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Infra.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private ApplicationDbContext _transactionContext;

        public TransactionRepository(ApplicationDbContext context)
        {
            _transactionContext = context;
        }

        public async Task<Transaction> CreateAsync(Transaction transaction)
        {
            _transactionContext.Transactions.Add(transaction);
            await _transactionContext.SaveChangesAsync();

            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            return await _transactionContext.Transactions.ToListAsync();
        }
    }
}
