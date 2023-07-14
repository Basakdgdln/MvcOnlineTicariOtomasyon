namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kargodeneme1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KargoTakips",
                c => new
                    {
                        KargoTakipID = c.Int(nullable: false, identity: true),
                        TakipKodu = c.String(maxLength: 10, unicode: false),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        TarihZaman = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoTakipID);
            
            AlterColumn("dbo.KargoDetays", "Aciklama", c => c.String(maxLength: 300, unicode: false));
            AlterColumn("dbo.KargoDetays", "TakipKodu", c => c.String(maxLength: 10, unicode: false));
            AlterColumn("dbo.KargoDetays", "Personel", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.KargoDetays", "Alici", c => c.String(maxLength: 25, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KargoDetays", "Alici", c => c.String());
            AlterColumn("dbo.KargoDetays", "Personel", c => c.String());
            AlterColumn("dbo.KargoDetays", "TakipKodu", c => c.String());
            AlterColumn("dbo.KargoDetays", "Aciklama", c => c.String());
            DropTable("dbo.KargoTakips");
        }
    }
}
