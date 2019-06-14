namespace WindowsFormsApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Test", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Test");
        }
    }
}
