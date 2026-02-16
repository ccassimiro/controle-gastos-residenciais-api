using CGR.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CGR.Domain.Models
{
    public class CategoriesTotalSummary
    {
        [NotMapped]
        public IEnumerable<CategoryTotalSummary> Categories { get; set; } = new List<CategoryTotalSummary>();

        [NotMapped]
        public TotalsRow Totals { get; set; } = new TotalsRow();
    }

    public class TotalsRow
    {
        public decimal TotalExpense { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalBalance { get; set; }
    }

    public class CategoryTotalSummary
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public PurposeType PurposeType { get; set; }
        public decimal Total { get; set; }
    }
}