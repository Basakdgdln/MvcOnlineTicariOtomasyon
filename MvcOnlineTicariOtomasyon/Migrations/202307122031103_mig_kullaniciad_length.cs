namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_kullaniciad_length : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "KullaniciAd", c => c.String(maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "KullaniciAd", c => c.String(maxLength: 10, unicode: false));
        }
    }
}
