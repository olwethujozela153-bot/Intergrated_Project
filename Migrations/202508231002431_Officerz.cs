namespace Intergrated_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Officerz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Officers",
                c => new
                    {
                        BadgeNum = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BadgeNum);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Officers");
        }
    }
}
