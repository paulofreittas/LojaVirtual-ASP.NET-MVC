namespace LojaVirtual.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Att_TabelaProduto_DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produto", "Nome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Produto", "Descricao", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produto", "Descricao", c => c.String());
            AlterColumn("dbo.Produto", "Nome", c => c.String());
        }
    }
}
