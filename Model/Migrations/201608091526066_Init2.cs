namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airport",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AirportName = c.String(nullable: false, maxLength: 200),
                        AirportCode = c.String(maxLength: 10),
                        SortOrder = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 300),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                        Prequent = c.String(),
                        Message = c.String(),
                        InfoFly = c.String(),
                        InfoCus = c.String(),
                        Payment = c.Int(nullable: false),
                        PayDate = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nationality",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NationalityName = c.String(nullable: false, maxLength: 200),
                        NationalityCode = c.String(),
                        Fee = c.Int(nullable: false),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        TimeZoo = c.String(),
                        Icon = c.String(maxLength: 250),
                        Embassy = c.String(),
                        Requirement = c.String(),
                        FilterName = c.String(),
                        Tips = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Nationality");
            DropTable("dbo.Booking");
            DropTable("dbo.Airport");
        }
    }
}
