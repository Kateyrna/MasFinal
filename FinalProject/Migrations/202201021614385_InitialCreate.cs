namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        GenderType = c.Int(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        EmployeeId = c.Int(),
                        Salary = c.Decimal(precision: 18, scale: 2),
                        Hiredate = c.DateTime(),
                        DoctorId = c.Int(),
                        Title = c.String(),
                        DoctorSpecialty = c.Int(),
                        ReceptionistId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PersonId);
            
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patients");
            DropTable("dbo.People");
        }
    }
}
