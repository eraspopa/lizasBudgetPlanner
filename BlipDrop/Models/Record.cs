using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BlipDrop.Models
{
    public class Record
    {
        [Key]
        [Column(Order = 1)]
        public Guid RecordId { get; set; }

        [Required]
        public decimal RecordValue { get; set; }

        [Required]
        public string SubcategoryId { get; set; }

        
        public string CategoryId { get; set; }
       
        public string PeriodId { get; set; }

        public virtual Subcategory Subcategory { get; set; }

        public virtual Category Category { get; set; }
        public virtual Period Period { get; set; }
    }
}