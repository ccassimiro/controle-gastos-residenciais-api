using CGR.Domain.Entities;
using CGR.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Application.DTOs
{
    public class TransactionDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [MaxLength(400, ErrorMessage = "Description must be at most 400 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Value field is required.")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335",
            ErrorMessage = "Value must be greater than zero.")]
        public decimal Value { get; set; }

        // Se 0 for "None/Unknown", isso força o cliente a mandar 1+
        [Range(1, int.MaxValue, ErrorMessage = "The PurposeType field is required.")]
        public PurposeType PurposeType { get; set; }

        public Guid CategoryId { get; set; }
        public Guid PersonId { get; set; }
    }
}
