namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoginAccountModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Logins", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        LoginId = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.LoginId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "AccountId", "dbo.Logins");
            DropIndex("dbo.Accounts", new[] { "AccountId" });
            DropTable("dbo.Logins");
            DropTable("dbo.Accounts");
        }
    }
}
