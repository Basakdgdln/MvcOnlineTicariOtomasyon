namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_hakkında_sil : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Personels", "Hakkında");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personels", "Hakkında", c => c.String(maxLength: 250, unicode: false));
        }
    }
}
