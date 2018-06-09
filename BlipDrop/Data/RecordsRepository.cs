using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlipDrop.Models;
using BlipDrop.ViewModels;

namespace BlipDrop.Data
{
    public class RecordsRepository
    {
        public List<RecordDisplayViewModel> GetRecords()
        {
            using (var context = new ApplicationDbContext())
            {
                List<Record> records = new List<Record>();
                records = context.Records.AsNoTracking()
                    .Include(x=>x.ExpenseType)
                    .Include(x => x.Subcategory)
                    .Include(x => x.Category)
                    .Include(x=>x.Period)
                    .ToList();

                if (records != null)
                {
                    List<RecordDisplayViewModel> recordsDisplay = new List<RecordDisplayViewModel>();
                    foreach (var x in records)
                    {
                        var recordDisplay = new RecordDisplayViewModel()
                        {
                           RecordId = x.RecordId,
                           RecordValue = x.RecordValue,
                           ExpenseType = x.ExpenseType.ExpenseNameEnglish,
                           Subcategory = x.Subcategory.SubcategoryNameEnglish,
                           Category = x.Category.CategoryNameEnglish,
                           Period = x.Period.PeriodNameEnglish

                        };
                        recordsDisplay.Add(recordDisplay);
                    }
                    return recordsDisplay;
                }
                return null;
            }
        }


        public RecordEditViewModel CreateRecord()
        {

            var eRepo = new ExpenseTypeRepository();
            var sRepo = new SubcategoryRepository();
            var cRepo = new CategoriesRepository();
            var pRepo = new PeriodsRepository();
            var record = new RecordEditViewModel()
            {
                RecordId = Guid.NewGuid().ToString(),
                ExpenseTypes = eRepo.GetExpenseTypes(),
                Subcategories = sRepo.GetSubcategories(),
                Categories = cRepo.GetCategories(),
                Periods = pRepo.GetPeriods()
            };
            return record;
        }

        public bool SaveRecord(RecordEditViewModel recordEdit)
        {
            if(recordEdit != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    if (Guid.TryParse(recordEdit.RecordId, out Guid newGuid))
                    {
                        var record = new Record()
                        {
                            RecordId = newGuid,
                            RecordValue = recordEdit.RecordValue,
                            ExpenseId = recordEdit.SelectedExpenseTypeId,
                            SubcategoryId = recordEdit.SelectedSubcategoryId,
                            CategoryId = recordEdit.SelectedCategoryCode,
                            PeriodId = recordEdit.SelectedPeriodCode
                        };
                        record.ExpenseType = context.ExpenseTypes.Find(recordEdit.SelectedExpenseTypeId);
                        record.Subcategory = context.Subcategories.Find(recordEdit.SelectedSubcategoryId);
                        record.Category = context.Categories.Find(recordEdit.SelectedCategoryCode);
                        record.Period = context.Periods.Find(recordEdit.SelectedPeriodCode);
                        context.Records.Add(record);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            // Return false if customeredit == null or CustomerID is not a guid
            return false;
        }
    }
}