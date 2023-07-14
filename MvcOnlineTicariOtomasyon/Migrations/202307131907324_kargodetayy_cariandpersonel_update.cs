namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kargodetayy_cariandpersonel_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KargoDetayies", "PersonelID", c => c.Int(nullable: false));
            AddColumn("dbo.KargoDetayies", "CariID", c => c.Int(nullable: false));
            CreateIndex("dbo.KargoDetayies", "PersonelID");
            CreateIndex("dbo.KargoDetayies", "CariID");
            AddForeignKey("dbo.KargoDetayies", "CariID", "dbo.Carilers", "CariID", cascadeDelete: true);
            AddForeignKey("dbo.KargoDetayies", "PersonelID", "dbo.Personels", "PersonelID", cascadeDelete: true);
            DropColumn("dbo.KargoDetayies", "Personel");
            DropColumn("dbo.KargoDetayies", "Alici");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KargoDetayies", "Alici", c => c.String(maxLength: 25, unicode: false));
            AddColumn("dbo.KargoDetayies", "Personel", c => c.String(maxLength: 30, unicode: false));
            DropForeignKey("dbo.KargoDetayies", "PersonelID", "dbo.Personels");
            DropForeignKey("dbo.KargoDetayies", "CariID", "dbo.Carilers");
            DropIndex("dbo.KargoDetayies", new[] { "CariID" });
            DropIndex("dbo.KargoDetayies", new[] { "PersonelID" });
            DropColumn("dbo.KargoDetayies", "CariID");
            DropColumn("dbo.KargoDetayies", "PersonelID");
        }
    }
}
