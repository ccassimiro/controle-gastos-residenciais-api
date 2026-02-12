using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Application.DTOs
{
    public enum PurposeTypeDTO
    {
        [Display(Name = "Despesa")]
        Expense = 1,

        [Display(Name = "Receita")]
        Income = 2,

        [Display(Name = "Ambos")]
        Both = 3
    }

    public class CategoryTotalSummaryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PurposeTypeDTO PurposeType { get; set; }
        public decimal Total { get; set; }
    }
}
