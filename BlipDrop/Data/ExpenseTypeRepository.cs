using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlipDrop.Data
{
    public class ExpenseTypeRepository
    {
        public IEnumerable<SelectListItem> GetExpenseTypes()
        {
            using (var context = new ApplicationDbContext())
            {
                List<SelectListItem> types = context.ExpenseTypes.AsNoTracking()
                    .OrderBy(n => n.ExpenseNameEnglish)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.ExpenseId.ToString(),
                            Text = n.ExpenseNameEnglish
                        }).ToList();
                var typesTip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- select types ---"
                };
                types.Insert(0, typesTip);
                return new SelectList(types, "Value", "Text");
            }
        }
    }
}