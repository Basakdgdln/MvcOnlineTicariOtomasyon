namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_carisifre_delete : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Carilers", "CariSifre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carilers", "CariSifre", c => c.String(maxLength: 20, unicode: false));
        }
    }
}
