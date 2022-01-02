namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVisitPrescriptions_AndAppointmentRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prescriptions", "VisitId", "dbo.Visits");
            DropPrimaryKey("dbo.Visits");
            AddColumn("dbo.Appointments", "VisitId", c => c.Int(nullable: false));
            AddColumn("dbo.Visits", "AppointmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Visits", "VisitId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Visits", "VisitId");
            CreateIndex("dbo.Visits", "VisitId");
            AddForeignKey("dbo.Visits", "VisitId", "dbo.Appointments", "AppointmentId");
            AddForeignKey("dbo.Prescriptions", "VisitId", "dbo.Visits", "VisitId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.Visits", "VisitId", "dbo.Appointments");
            DropIndex("dbo.Visits", new[] { "VisitId" });
            DropPrimaryKey("dbo.Visits");
            AlterColumn("dbo.Visits", "VisitId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Visits", "AppointmentId");
            DropColumn("dbo.Appointments", "VisitId");
            AddPrimaryKey("dbo.Visits", "VisitId");
            AddForeignKey("dbo.Prescriptions", "VisitId", "dbo.Visits", "VisitId", cascadeDelete: true);
        }
    }
}
