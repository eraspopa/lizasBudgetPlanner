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
    }
}