namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatientInheritance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            AddColumn("dbo.Appointments", "Patient_PersonId", c => c.Int());
            AddColumn("dbo.People", "PatientId", c => c.Int());
            AddColumn("dbo.People", "MedicareNo", c => c.String());
            AddColumn("dbo.People", "BloodType", c => c.Int());
            AddColumn("dbo.People", "PatientType", c => c.Int());
            AddColumn("dbo.People", "PensionerId", c => c.String());
            AddColumn("dbo.People", "Allergies", c => c.String());
            AddColumn("dbo.People", "Discount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.People", "DisabilityCategory", c => c.Int());
            CreateIndex("dbo.Appointments", "Patient_PersonId");
            AddForeignKey("dbo.Appointments", "Patient_PersonId", "dbo.People", "PersonId");
            DropTable("dbo.Patients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        MedicareNo = c.String(),
                        BloodType = c.Int(nullable: false),
                        PatientType = c.Int(nullable: false),
                        PensionerId = c.String(),
                        Allergies = c.String(),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DisabilityCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatientId);
            
            DropForeignKey("dbo.Appointments", "Patient_PersonId", "dbo.People");
            DropIndex("dbo.Appointments", new[] { "Patient_PersonId" });
            DropColumn("dbo.People", "DisabilityCategory");
            DropColumn("dbo.People", "Discount");
            DropColumn("dbo.People", "Allergies");
            DropColumn("dbo.People", "PensionerId");
            DropColumn("dbo.People", "PatientType");
            DropColumn("dbo.People", "BloodType");
            DropColumn("dbo.People", "MedicareNo");
            DropColumn("dbo.People", "PatientId");
            DropColumn("dbo.Appointments", "Patient_PersonId");
            CreateIndex("dbo.Appointments", "PatientId");
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.Patients", "PatientId", cascadeDelete: true);
        }
    }
}
