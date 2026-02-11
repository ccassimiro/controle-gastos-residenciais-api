using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CGR.Domain.Enum
{
    public enum PurposeType
    {
        [Display(Name = "Despesa")]
        Expense = 1,

        [Display(Name = "Receita")]
        Income = 2,

        [Display(Name = "Ambos")]
        Both = 3
    }
}
