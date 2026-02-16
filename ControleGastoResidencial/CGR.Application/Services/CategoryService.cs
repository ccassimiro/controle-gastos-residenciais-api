using AutoMapper;
using CGR.Application.DTOs;
using CGR.Application.Interfaces;
using CGR.Domain.Entities;
using CGR.Domain.Interfaces;
using CGR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, ITransactionRepository transactionRepository, IMapper mapper)
        {
             _categoryRepository = categoryRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task CreateAsync(CategoryDTO categoryDto)
        {
            await _categoryRepository.CreateAsync(_mapper.Map<Category>(categoryDto));
        }

        public async Task<CategoriesTotalSummary> GetCategoriesTotalSummaryAsync()
        {
            var categoriesTotalSummary = await _transactionRepository.GetCategoriesTotalSummary();
            return _mapper.Map<CategoriesTotalSummary>(categoriesTotalSummary);
        }
    }
}
