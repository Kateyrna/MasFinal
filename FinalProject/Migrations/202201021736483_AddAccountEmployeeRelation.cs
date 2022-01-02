namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountEmployeeRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Doctor_PersonId", "dbo.People");
            DropForeignKey("dbo.Appointments", "Patient_PersonId", "dbo.People");
            DropForeignKey("dbo.Appointments", "Receptionist_PersonId", "dbo.People");
            DropPrimaryKey("dbo.People");
            AlterColumn("dbo.People", "PersonId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.People", "PersonId");
            CreateIndex("dbo.People", "PersonId");
            AddForeignKey("dbo.People", "PersonId", "dbo.Accounts", "AccountId");
            AddForeignKey("dbo.Appointments", "Doctor_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Appointments", "Patient_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Appointments", "Receptionist_PersonId", "dbo.People", "PersonId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Receptionist_PersonId", "dbo.People");
            DropForeignKey("dbo.Appointments", "Patient_PersonId", "dbo.People");
            DropForeignKey("dbo.Appointments", "Doctor_PersonId", "dbo.People");
            DropForeignKey("dbo.People", "PersonId", "dbo.Accounts");
            DropIndex("dbo.People", new[] { "PersonId" });
            DropPrimaryKey("dbo.People");
            AlterColumn("dbo.People", "PersonId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.People", "PersonId");
            AddForeignKey("dbo.Appointments", "Receptionist_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Appointments", "Patient_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Appointments", "Doctor_PersonId", "dbo.People", "PersonId");
        }
    }
}
