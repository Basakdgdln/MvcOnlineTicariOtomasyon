namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kargodetayy_table_create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KargoDetayies",
                c => new
                    {
                        KargoDetayID = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 300, unicode: false),
                        TakipKodu = c.String(maxLength: 10, unicode: false),
                        Personel = c.String(maxLength: 30, unicode: false),
                        Alici = c.String(maxLength: 25, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoDetayID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KargoDetayies");
        }
    }
}
