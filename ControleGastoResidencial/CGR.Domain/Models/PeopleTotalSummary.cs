using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Domain.Models
{
    public class PeopleTotalSummary
    {
        public IEnumerable<PersonTotalSummary> People { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal TotalBalance { get; set; }
    }


    public class PersonTotalSummary
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Expense { get; set; }
        public decimal Income { get; set; }
        public decimal Balance { get; set; }
    }
}
