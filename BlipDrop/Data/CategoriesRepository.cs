using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlipDrop.Data
{
    public class CategoriesRepository
    {
        public IEnumerable<SelectListItem> GetCategories()
        {
            List<SelectListItem> categories = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = " "
                }
            };
            return categories;
        }

        public IEnumerable<SelectListItem> GetCategories(string subcategoryCode)
        {
            if (!String.IsNullOrWhiteSpace(subcategoryCode))
            {
                using (var context = new ApplicationDbContext())
                {
                    IEnumerable<SelectListItem> categories = context.Categories.AsNoTracking()
                        .OrderBy(n => n.CategoryNameEnglish)
                        .Where(n => n.SubcategoryCode == subcategoryCode)
                        .Select(n =>
                           new SelectListItem
                           {
                               Value = n.CategoryCode,
                               Text = n.CategoryNameEnglish
                           }).ToList();
                    return new SelectList(categories, "Value", "Text");
                }
            }
            return null;
        }
    }
}