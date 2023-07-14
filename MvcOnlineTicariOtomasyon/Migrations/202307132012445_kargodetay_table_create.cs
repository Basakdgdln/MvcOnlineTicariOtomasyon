namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kargodetay_table_create : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KargoDetays", "Alici", c => c.String(maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KargoDetays", "Alici", c => c.String(maxLength: 25, unicode: false));
        }
    }
}
