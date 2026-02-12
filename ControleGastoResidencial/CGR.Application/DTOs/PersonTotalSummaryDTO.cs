using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Application.DTOs
{
    public class PersonTotalSummaryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Expense { get; set; }
        public decimal Income { get; set; }
        public decimal Balance { get; set; }
    }
}
