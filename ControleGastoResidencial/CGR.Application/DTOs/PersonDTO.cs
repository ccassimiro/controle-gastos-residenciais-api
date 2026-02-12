using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Application.DTOs
{
    public class PersonDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Age field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Age must be greater than zero.")]
        public int Age { get; set; }
    }
}
