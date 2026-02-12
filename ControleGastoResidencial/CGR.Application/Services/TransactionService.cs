using AutoMapper;
using CGR.Application.DTOs;
using CGR.Application.Interfaces;
using CGR.Domain.Entities;
using CGR.Domain.Enum;
using CGR.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IPersonRepository personRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _personRepository = personRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionDTO>> GetTransactionsAsync()
        {
            var transactions = await _transactionRepository.GetTransactionsAsync();
            return _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
        }

        public async Task<TransactionDTO> CreateAsync(TransactionDTO transactionDto)
        {
            var transactionPerson = await _personRepository.GetByIdAsync(transactionDto.PersonId);
            if (transactionPerson.Age < 18 && transactionDto.PurposeType == PurposeType.Income)
            {
                throw new InvalidOperationException("Person under 18 years old cannot have income transactions.");
            }

            // Apenas um safe check que adicionei testando criar transações pelo Swagger, achei necessário ter ele.
            var transactionCategory = await _categoryRepository.GetByIdAsync(transactionDto.CategoryId);
            if (transactionCategory.PurposeType != transactionDto.PurposeType && transactionCategory.PurposeType != PurposeType.Both)
            {
                throw new InvalidOperationException("Transaction purpose type does not match category purpose type.");
            }

            var newTransaction = await _transactionRepository.CreateAsync(_mapper.Map<Transaction>(transactionDto));

            return _mapper.Map<TransactionDTO>(newTransaction);
        }
    }
}
