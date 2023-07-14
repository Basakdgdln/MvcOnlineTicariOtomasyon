namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personel_detay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personels", "Adres", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.Personels", "Telefon", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.Personels", "Hakkında", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Personels", "PersonelSoyad", c => c.String(maxLength: 11, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personels", "PersonelSoyad", c => c.String(maxLength: 30, unicode: false));
            DropColumn("dbo.Personels", "Hakkında");
            DropColumn("dbo.Personels", "Telefon");
            DropColumn("dbo.Personels", "Adres");
        }
    }
}
