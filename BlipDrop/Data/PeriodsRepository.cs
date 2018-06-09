using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlipDrop.Data
{
    public class PeriodsRepository
    {
        public IEnumerable<SelectListItem> GetPeriods()
        {
            using (var context = new ApplicationDbContext())
            {
                List<SelectListItem> periods = context.Periods.AsNoTracking()
                    .OrderBy(n => n.PeriodNameEnglish)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.PeriodId.ToString(),
                            Text = n.PeriodNameEnglish
                        }).ToList();
                var periodTip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- select periods ---"
                };
                periods.Insert(0, periodTip);
                return new SelectList(periods, "Value", "Text");
            }
        }
    }
}