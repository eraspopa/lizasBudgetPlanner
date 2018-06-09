namespace BlipDrop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryCode = c.String(nullable: false, maxLength: 128),
                        SubcategoryCode = c.String(nullable: false),
                        CategoryNameEnglish = c.String(nullable: false),
                        Subcategory_SubcategoryId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CategoryCode)
                .ForeignKey("dbo.Subcategories", t => t.Subcategory_SubcategoryId)
                .Index(t => t.Subcategory_SubcategoryId);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        SubcategoryId = c.String(nullable: false, maxLength: 128),
                        ExpenseTypeName = c.String(),
                        SubcategoryNameEnglish = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.SubcategoryId);
            
            CreateTable(
                "dbo.ExpenseTypes",
                c => new
                    {
                        ExpenseId = c.String(nullable: false, maxLength: 128),
                        ExpenseNameEnglish = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ExpenseId);
            
            CreateTable(
                "dbo.Periods",
                c => new
                    {
                        PeriodId = c.String(nullable: false, maxLength: 128),
                        PeriodNameEnglish = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PeriodId);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        RecordId = c.Guid(nullable: false),
                        RecordValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExpenseId = c.String(nullable: false, maxLength: 128),
                        SubcategoryId = c.String(nullable: false, maxLength: 128),
                        CategoryId = c.String(),
                        PeriodId = c.String(maxLength: 128),
                        Category_CategoryCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryCode)
                .ForeignKey("dbo.ExpenseTypes", t => t.ExpenseId, cascadeDelete: true)
                .ForeignKey("dbo.Periods", t => t.PeriodId)
                .ForeignKey("dbo.Subcategories", t => t.SubcategoryId, cascadeDelete: true)
                .Index(t => t.ExpenseId)
                .Index(t => t.SubcategoryId)
                .Index(t => t.PeriodId)
                .Index(t => t.Category_CategoryCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "SubcategoryId", "dbo.Subcategories");
            DropForeignKey("dbo.Records", "PeriodId", "dbo.Periods");
            DropForeignKey("dbo.Records", "ExpenseId", "dbo.ExpenseTypes");
            DropForeignKey("dbo.Records", "Category_CategoryCode", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Subcategory_SubcategoryId", "dbo.Subcategories");
            DropIndex("dbo.Records", new[] { "Category_CategoryCode" });
            DropIndex("dbo.Records", new[] { "PeriodId" });
            DropIndex("dbo.Records", new[] { "SubcategoryId" });
            DropIndex("dbo.Records", new[] { "ExpenseId" });
            DropIndex("dbo.Categories", new[] { "Subcategory_SubcategoryId" });
            DropTable("dbo.Records");
            DropTable("dbo.Periods");
            DropTable("dbo.ExpenseTypes");
            DropTable("dbo.Subcategories");
            DropTable("dbo.Categories");
        }
    }
}
