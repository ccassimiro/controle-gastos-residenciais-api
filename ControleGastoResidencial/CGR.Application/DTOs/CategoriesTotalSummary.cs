using CGR.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Application.DTOs
{
    public class CategoriesTotalSummaryDTO
    {
        public IEnumerable<CategoryTotalSummaryDTO> Categories { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalBalance { get; set; }
    }

    public class CategoryTotalSummaryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PurposeType PurposeType { get; set; }
        public decimal Total { get; set; }
    }
}
