namespace CommonData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pierwsza : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.CardShirts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CreatorCompany = c.String(),
                        Year = c.Int(nullable: false),
                        AgeRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("public.Stores");
            DropTable("public.Games");
            DropTable("public.CardShirts");
        }
    }
}
