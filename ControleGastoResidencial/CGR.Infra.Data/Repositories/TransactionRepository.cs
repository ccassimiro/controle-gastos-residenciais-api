using CGR.Domain.Entities;
using CGR.Domain.Interfaces;
using CGR.Domain.Models;
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

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            return await _transactionContext.Transactions.ToListAsync();
        }

        public async Task<IEnumerable<PersonTotalSummary>> GetTotalSummary()
        {
            const string sql = @"
                                SELECT
                                    p.Id   AS Id,
                                    p.Name AS [Name],
                                    SUM(CASE WHEN t.PurposeType = 2 THEN t.[Value] ELSE 0 END) AS Income,
                                    SUM(CASE WHEN t.PurposeType = 1 THEN t.[Value] ELSE 0 END) AS Expense,
                                    SUM(CASE WHEN t.PurposeType = 2 THEN t.[Value] ELSE 0 END)
                                  - SUM(CASE WHEN t.PurposeType = 1 THEN t.[Value] ELSE 0 END) AS Balance
                                FROM [CGRdb].[dbo].[People] AS p
                                LEFT JOIN [Transactions] AS t
                                    ON t.PersonId = p.Id
                                   AND t.PurposeType IN (1, 2)
                                GROUP BY p.Id, p.Name
                                ORDER BY p.Name;";

            return await _transactionContext.PersonTotalSummaries
                .FromSqlRaw(sql)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<CategoryTotalSummary>> GetCategoriesTotalSummary()
        {
            const string sql = @"SELECT
                                    c.Id AS Id,
                                    c.Description AS [Name],
                                    c.PurposeType AS PurposeType,
                                    CAST(COALESCE(SUM(t.[Value]), 0) AS decimal(18,2)) AS Total
                                FROM [Categories] c
                                LEFT JOIN [Transactions] t
                                    ON t.CategoryId = c.Id
                                   AND t.PurposeType = c.PurposeType
                                GROUP BY
                                    c.Id,
                                    c.Description,
                                    c.PurposeType
                                ORDER BY
                                    c.Description,
                                    c.PurposeType;";                           

            return await _transactionContext.CategoriesTotalSummaries
                .FromSqlRaw(sql)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
