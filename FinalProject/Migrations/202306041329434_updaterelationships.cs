namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updaterelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prescriptions", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.Appointments", "Doctor_PersonId", "dbo.People");
            DropForeignKey("dbo.Appointments", "Patient_PersonId", "dbo.People");
            DropForeignKey("dbo.Appointments", "Receptionist_PersonId", "dbo.People");
            DropForeignKey("dbo.Accounts", "AccountId", "dbo.Logins");
            DropIndex("dbo.People", new[] { "PersonId" });
            DropIndex("dbo.Prescriptions", new[] { "VisitId" });
            DropColumn("dbo.Accounts", "AccountId");
            DropColumn("dbo.Logins", "LoginId");
            RenameColumn(table: "dbo.Accounts", name: "PersonId", newName: "AccountId");
            RenameColumn(table: "dbo.Logins", name: "AccountId", newName: "LoginId");
            RenameColumn(table: "dbo.Prescriptions", name: "VisitId", newName: "Visit_VisitId");
            DropPrimaryKey("dbo.People");
            DropPrimaryKey("dbo.Logins");
            AddColumn("dbo.Visits", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Prescriptions", "AppointmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.People", "PersonId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Prescriptions", "Visit_VisitId", c => c.Int());
            AlterColumn("dbo.Logins", "LoginId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.People", "PersonId");
            AddPrimaryKey("dbo.Logins", "LoginId");
            CreateIndex("dbo.Prescriptions", "AppointmentId");
            CreateIndex("dbo.Prescriptions", "Visit_VisitId");
            CreateIndex("dbo.Logins", "LoginId");
            AddForeignKey("dbo.Prescriptions", "AppointmentId", "dbo.Appointments", "AppointmentId", cascadeDelete: true);
            AddForeignKey("dbo.Prescriptions", "Visit_VisitId", "dbo.Visits", "VisitId");
            AddForeignKey("dbo.Appointments", "Doctor_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Appointments", "Patient_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Appointments", "Receptionist_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Accounts", "AccountId", "dbo.People", "PersonId");
            DropColumn("dbo.Visits", "AppointmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Visits", "AppointmentId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Accounts", "AccountId", "dbo.People");
            DropForeignKey("dbo.Appointments", "Receptionist_PersonId", "dbo.People");
            DropForeignKey("dbo.Appointments", "Patient_PersonId", "dbo.People");
            DropForeignKey("dbo.Appointments", "Doctor_PersonId", "dbo.People");
            DropForeignKey("dbo.Prescriptions", "Visit_VisitId", "dbo.Visits");
            DropForeignKey("dbo.Prescriptions", "AppointmentId", "dbo.Appointments");
            DropIndex("dbo.Logins", new[] { "LoginId" });
            DropIndex("dbo.Prescriptions", new[] { "Visit_VisitId" });
            DropIndex("dbo.Prescriptions", new[] { "AppointmentId" });
            DropPrimaryKey("dbo.Logins");
            DropPrimaryKey("dbo.People");
            AlterColumn("dbo.Logins", "LoginId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Prescriptions", "Visit_VisitId", c => c.Int(nullable: false));
            AlterColumn("dbo.People", "PersonId", c => c.Int(nullable: false));
            DropColumn("dbo.Prescriptions", "AppointmentId");
            DropColumn("dbo.Visits", "Date");
            AddPrimaryKey("dbo.Logins", "LoginId");
            AddPrimaryKey("dbo.People", "PersonId");
            RenameColumn(table: "dbo.Prescriptions", name: "Visit_VisitId", newName: "VisitId");
            RenameColumn(table: "dbo.Logins", name: "LoginId", newName: "AccountId");
            RenameColumn(table: "dbo.Accounts", name: "AccountId", newName: "PersonId");
            AddColumn("dbo.Logins", "LoginId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Accounts", "AccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Prescriptions", "VisitId");
            CreateIndex("dbo.People", "PersonId");
            AddForeignKey("dbo.Accounts", "AccountId", "dbo.Logins", "LoginId");
            AddForeignKey("dbo.Appointments", "Receptionist_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Appointments", "Patient_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Appointments", "Doctor_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Prescriptions", "VisitId", "dbo.Visits", "VisitId", cascadeDelete: true);
        }
    }
}
