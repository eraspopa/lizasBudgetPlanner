using System.ComponentModel.DataAnnotations;

namespace BlipDrop.Models
{
    public class Category
    {
        [Key]
        public string CategoryCode { get; set; }

        [Required]
        public string SubcategoryCode { get; set; }

        [Required]
        public string CategoryNameEnglish { get; set; }

        public virtual Subcategory Subcategory { get; set; }
    }
}