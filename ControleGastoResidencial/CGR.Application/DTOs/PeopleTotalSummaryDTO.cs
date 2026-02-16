using CGR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Application.DTOs
{
    public class PeopleTotalSummaryDTO
    {
        public IEnumerable<PersonTotalSummary> People { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalBalance { get; set; }
    }

    public class PersonTotalSummaryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Expense { get; set; }
        public decimal Income { get; set; }
        public decimal Balance { get; set; }
    }
}
