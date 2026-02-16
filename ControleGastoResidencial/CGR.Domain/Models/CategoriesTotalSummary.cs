using CGR.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Domain.Models
{
    public class CategoriesTotalSummary
    {
        public IEnumerable<CategoryTotalSummary> Categories { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalBalance { get; set; }
    }

    public class CategoryTotalSummary
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PurposeType PurposeType { get; set; }
        public decimal Total { get; set; }
    }
}
