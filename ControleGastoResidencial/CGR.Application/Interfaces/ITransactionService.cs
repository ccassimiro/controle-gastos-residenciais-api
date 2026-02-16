using CGR.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<CreateTransactionDTO> CreateAsync(CreateTransactionDTO transactionDto);
        Task<IEnumerable<TransactionDTO>> GetTransactionsAsync();
    }
}
