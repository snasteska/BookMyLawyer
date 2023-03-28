namespace BookMyLawyer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class earnings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lawyers", "Earnings", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lawyers", "Earnings");
        }
    }
}
