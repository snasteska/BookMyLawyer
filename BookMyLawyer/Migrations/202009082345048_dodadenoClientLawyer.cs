namespace BookMyLawyer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodadenoClientLawyer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LawyerClients",
                c => new
                    {
                        Lawyer_ID = c.Int(nullable: false),
                        Client_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Lawyer_ID, t.Client_ID })
                .ForeignKey("dbo.Lawyers", t => t.Lawyer_ID, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_ID, cascadeDelete: true)
                .Index(t => t.Lawyer_ID)
                .Index(t => t.Client_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LawyerClients", "Client_ID", "dbo.Clients");
            DropForeignKey("dbo.LawyerClients", "Lawyer_ID", "dbo.Lawyers");
            DropIndex("dbo.LawyerClients", new[] { "Client_ID" });
            DropIndex("dbo.LawyerClients", new[] { "Lawyer_ID" });
            DropTable("dbo.LawyerClients");
        }
    }
}
