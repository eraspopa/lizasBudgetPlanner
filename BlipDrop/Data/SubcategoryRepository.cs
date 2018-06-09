using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlipDrop.Data
{
    public class SubcategoryRepository
    {
        public IEnumerable<SelectListItem> GetSubcategories()
        {
            using (var context = new ApplicationDbContext())
            {
                List<SelectListItem> subcategories = context.Subcategories.AsNoTracking()
                    .OrderBy(n => n.SubcategoryNameEnglish)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.SubcategoryId.ToString(),
                            Text = n.SubcategoryNameEnglish
                        }).ToList();
                var subcategoryTip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- select subcategory ---"
                };
                subcategories.Insert(0, subcategoryTip);
                return new SelectList(subcategories, "Value", "Text");
            }
        }
        public IEnumerable<SelectListItem> GetSubcategories(string typeCode)
        {
            if (!String.IsNullOrWhiteSpace(typeCode))
            {
                using (var context = new ApplicationDbContext())
                {
                    IEnumerable<SelectListItem> categories = context.Subcategories.AsNoTracking()
                        .OrderBy(n => n.SubcategoryNameEnglish)
                        .Where(n => n.ExpenseTypeName == typeCode)
                        .Select(n =>
                            new SelectListItem
                            {
                                Value = n.SubcategoryId,
                                Text = n.SubcategoryNameEnglish
                            }).ToList();
                    return new SelectList(categories, "Value", "Text");
                }
            }
            return null;
        }
    }
}