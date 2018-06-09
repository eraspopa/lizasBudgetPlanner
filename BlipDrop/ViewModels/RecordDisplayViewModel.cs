using System;
using System.ComponentModel.DataAnnotations;

namespace BlipDrop.ViewModels
{
    public class RecordDisplayViewModel
    {
        [Display(Name = "Number")]
        public Guid RecordId { get; set; }

        [Display(Name = "Value")]
        public decimal RecordValue { get; set; }
        [Display(Name = "Type")]
        public string ExpenseType { get; set; }

        [Display(Name = "Subcategory")]
        public string Subcategory { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }
        [Display(Name = "Period")]
        public string Period { get; set; }
    }
}