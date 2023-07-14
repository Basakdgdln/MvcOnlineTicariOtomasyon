namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_mesajdurum_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mesajlars", "Durum", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mesajlars", "Durum");
        }
    }
}
