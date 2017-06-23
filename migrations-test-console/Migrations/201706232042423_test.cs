namespace migrations_test_console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foos", "TestViewObj_testfield", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foos", "TestViewObj_testfield");
        }
    }
}
