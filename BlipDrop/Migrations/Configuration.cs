namespace BlipDrop.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BlipDrop.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            var subcategories = new List<Subcategory>
            {
                new Subcategory {
                    SubcategoryId = "1",
                    SubcategoryNameEnglish = "Pay"
                },
                new Subcategory
                {
                    SubcategoryId = "2",
                    SubcategoryNameEnglish = "Benefits"
                },
                new Subcategory
                {
                    SubcategoryId = "3",
                    SubcategoryNameEnglish = "Other income"
                }
            };
            subcategories.ForEach(s => context.Subcategories.AddOrUpdate(p => p.SubcategoryId, s));
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category
                {
                    SubcategoryCode = "1",
                    CategoryCode = "1",
                    CategoryNameEnglish = "Pay (after tax)"
                },
                new Category
                {
                    SubcategoryCode = "1",
                    CategoryCode = "2",
                    CategoryNameEnglish = "Income from self-employment"
                },
                new Category
                {
                    SubcategoryCode = "1",
                    CategoryCode = "3",
                    CategoryNameEnglish = "Statutory Sick Pay"
                },
                new Category
                {
                    SubcategoryCode = "1",
                    CategoryCode = "4",
                    CategoryNameEnglish = "Statutory Maternity Pay"
                },
                new Category
                {
                    SubcategoryCode = "2",
                    CategoryCode = "5",
                    CategoryNameEnglish = "Child Benefits"
                },
                new Category
                {
                    SubcategoryCode = "3",
                    CategoryCode = "6",
                    CategoryNameEnglish = "Savings"
                }
            };
            categories.ForEach(s => context.Categories.AddOrUpdate(p => p.CategoryCode, s));
            context.SaveChanges();

            var periods = new List<Period>
            {
                new Period {
                    PeriodId = "1",
                    PeriodNameEnglish = "per day"
                },
                new Period {
                    PeriodId = "2",
                    PeriodNameEnglish = "per week"
                },
                new Period {
                    PeriodId = "3",
                    PeriodNameEnglish = "per 2 weeks"
                },
            };
            periods.ForEach(s => context.Periods.AddOrUpdate(p => p.PeriodId, s));
            context.SaveChanges();
        }
    }
}