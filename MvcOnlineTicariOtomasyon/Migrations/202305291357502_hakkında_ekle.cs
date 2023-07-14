namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hakkında_ekle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Personels", "Hakkında", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personels", "Hakkında", c => c.String(maxLength: 200, unicode: false));
        }
    }
}
