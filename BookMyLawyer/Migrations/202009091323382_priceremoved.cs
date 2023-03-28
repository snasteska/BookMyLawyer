namespace BookMyLawyer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class priceremoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Lawyers", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lawyers", "Price", c => c.Int(nullable: false));
        }
    }
}
