namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updaterelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Visits", "VisitId", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "Doctor_PersonId", "dbo.People");
            DropForeignKey("dbo.Appointments", "Patient_PersonId", "dbo.People");
            DropForeignKey("dbo.Appointments", "Receptionist_PersonId", "dbo.People");
            DropForeignKey("dbo.Prescriptions", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.Accounts", "AccountId", "dbo.Logins");
            DropIndex("dbo.People", new[] { "PersonId" });
            DropColumn("dbo.Accounts", "AccountId");
            DropColumn("dbo.Visits", "AppointmentId");
            DropColumn("dbo.Logins", "LoginId");
            RenameColumn(table: "dbo.Accounts", name: "PersonId", newName: "AccountId");
            RenameColumn(table: "dbo.Logins", name: "AccountId", newName: "LoginId");
            RenameColumn(table: "dbo.Visits", name: "VisitId", newName: "AppointmentId");
            RenameIndex(table: "dbo.Visits", name: "IX_VisitId", newName: "IX_AppointmentId");
            DropPrimaryKey("dbo.People");
            DropPrimaryKey("dbo.Visits");
            DropPrimaryKey("dbo.Logins");
            AddColumn("dbo.Visits", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.People", "PersonId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Visits", "VisitId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Logins", "LoginId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.People", "PersonId");
            AddPrimaryKey("dbo.Visits", "VisitId");
            AddPrimaryKey("dbo.Logins", "LoginId");
            CreateIndex("dbo.Logins", "LoginId");
            AddForeignKey("dbo.Visits", "AppointmentId", "dbo.Appointments", "AppointmentId", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "Doctor_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Appointments", "Patient_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Appointments", "Receptionist_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Accounts", "AccountId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Prescriptions", "VisitId", "dbo.Visits", "VisitId", cascadeDelete: true);
            DropColumn("dbo.Appointments", "VisitId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "VisitId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Prescriptions", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.Accounts", "AccountId", "dbo.People");
            DropForeignKey("dbo.Appointments", "Receptionist_PersonId", "dbo.People");
            DropForeignKey("dbo.Appointments", "Patient_PersonId", "dbo.People");
            DropForeignKey("dbo.Appointments", "Doctor_PersonId", "dbo.People");
            DropForeignKey("dbo.Visits", "AppointmentId", "dbo.Appointments");
            DropIndex("dbo.Logins", new[] { "LoginId" });
            DropPrimaryKey("dbo.Logins");
            DropPrimaryKey("dbo.Visits");
            DropPrimaryKey("dbo.People");
            AlterColumn("dbo.Logins", "LoginId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Visits", "VisitId", c => c.Int(nullable: false));
            AlterColumn("dbo.People", "PersonId", c => c.Int(nullable: false));
            DropColumn("dbo.Visits", "Date");
            AddPrimaryKey("dbo.Logins", "LoginId");
            AddPrimaryKey("dbo.Visits", "VisitId");
            AddPrimaryKey("dbo.People", "PersonId");
            RenameIndex(table: "dbo.Visits", name: "IX_AppointmentId", newName: "IX_VisitId");
            RenameColumn(table: "dbo.Visits", name: "AppointmentId", newName: "VisitId");
            RenameColumn(table: "dbo.Logins", name: "LoginId", newName: "AccountId");
            RenameColumn(table: "dbo.Accounts", name: "AccountId", newName: "PersonId");
            AddColumn("dbo.Logins", "LoginId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Visits", "AppointmentId", c => c.Int(nullable: false));
            AddColumn("dbo.Accounts", "AccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "PersonId");
            AddForeignKey("dbo.Accounts", "AccountId", "dbo.Logins", "LoginId");
            AddForeignKey("dbo.Prescriptions", "VisitId", "dbo.Visits", "VisitId", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "Receptionist_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Appointments", "Patient_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Appointments", "Doctor_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Visits", "VisitId", "dbo.Appointments", "AppointmentId");
        }
    }
}
