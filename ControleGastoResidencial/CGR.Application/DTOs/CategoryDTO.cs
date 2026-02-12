using CGR.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Application.DTOs
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [MaxLength(400)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The PurposeType field is required.")]
        public PurposeType PurposeType { get; set; }
    }
}
