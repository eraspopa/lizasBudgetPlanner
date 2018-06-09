using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BlipDrop.ViewModels
{
    public class RecordEditViewModel
    {
        [Display(Name = "Number")]
        public string RecordId { get; set; }

        [Required]
        [Display(Name = "Value")]
        public decimal RecordValue { get; set; }
        [Required]
        [Display(Name = "Type")]
        public string SelectedExpenseTypeId { get; set; }
        public IEnumerable<SelectListItem> ExpenseTypes { get; set; }
        [Required]
        [Display(Name = "Subcategory")]
        public string SelectedSubcategoryId { get; set; }
        public IEnumerable<SelectListItem> Subcategories { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string SelectedCategoryCode { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        [Required]
        [Display(Name = "Period")]
        public string SelectedPeriodCode { get; set; }
        public IEnumerable<SelectListItem> Periods { get; set; }

    }
}