namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class duyurtable_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Duyurulars",
                c => new
                    {
                        DuyuruID = c.Int(nullable: false, identity: true),
                        Yayınlayan = c.String(maxLength: 30, unicode: false),
                        İçerik = c.String(maxLength: 500, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DuyuruID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Duyurulars");
        }
    }
}
