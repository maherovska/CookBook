namespace Cookbook.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changepropertyname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingredients", "Units", c => c.String());
            DropColumn("dbo.Ingredients", "Unit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredients", "Unit", c => c.String());
            DropColumn("dbo.Ingredients", "Units");
        }
    }
}
