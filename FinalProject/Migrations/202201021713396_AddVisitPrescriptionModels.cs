namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVisitPrescriptionModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        PrescriptionId = c.Int(nullable: false, identity: true),
                        Medication = c.String(),
                        Strength = c.String(),
                        Amount = c.String(),
                        Frequency = c.String(),
                        Reason = c.String(),
                        DispenseAmount = c.String(),
                        Refill = c.String(),
                        IssuedDate = c.DateTime(nullable: false),
                        VisitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrescriptionId)
                .ForeignKey("dbo.Visits", t => t.VisitId, cascadeDelete: true)
                .Index(t => t.VisitId);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        VisitId = c.Int(nullable: false, identity: true),
                        Reason = c.String(),
                        Diagnosis = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.VisitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "VisitId", "dbo.Visits");
            DropIndex("dbo.Prescriptions", new[] { "VisitId" });
            DropTable("dbo.Visits");
            DropTable("dbo.Prescriptions");
        }
    }
}
