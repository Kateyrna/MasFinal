namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAppointment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        VisitDate = c.DateTime(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                        SlotNumber = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        ReceptionistId = c.Int(nullable: false),
                        Doctor_PersonId = c.Int(),
                        Receptionist_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.People", t => t.Doctor_PersonId)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Receptionist_PersonId)
                .Index(t => t.PatientId)
                .Index(t => t.Doctor_PersonId)
                .Index(t => t.Receptionist_PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Receptionist_PersonId", "dbo.People");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "Doctor_PersonId", "dbo.People");
            DropIndex("dbo.Appointments", new[] { "Receptionist_PersonId" });
            DropIndex("dbo.Appointments", new[] { "Doctor_PersonId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropTable("dbo.Appointments");
        }
    }
}
