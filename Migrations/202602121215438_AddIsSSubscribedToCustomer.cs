namespace Vidly_Asp.Net.Mvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSSubscribedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribedToNewsletter");
        }
    }
}
