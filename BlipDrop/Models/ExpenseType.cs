using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlipDrop.Models
{
    public class ExpenseType
    {
        [Key]
        public string ExpenseId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ExpenseNameEnglish { get; set; }

        public virtual IEnumerable<Subcategory> Subcategories { get; set; }
    }
}