namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_personelmail_sifre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personels", "PersonelMail", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.Personels", "PersonelSifre", c => c.String(maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personels", "PersonelSifre");
            DropColumn("dbo.Personels", "PersonelMail");
        }
    }
}
