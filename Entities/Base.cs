using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Base
    {
        [Required]
        public Guid Id { get; set; }
    }
}
