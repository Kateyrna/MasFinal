namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "EmployeeTest", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "EmployeeTest");
        }
    }
}
