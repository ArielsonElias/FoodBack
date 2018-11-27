namespace FoodBack_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pedido : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestauranteId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        Quantidade = c.Single(nullable: false),
                        ValorUnitario = c.Single(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurantes", t => t.RestauranteId, cascadeDelete: true)
                .Index(t => t.RestauranteId)
                .Index(t => t.ProdutoId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restaurantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Endereco = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidoes", "RestauranteId", "dbo.Restaurantes");
            DropForeignKey("dbo.Pedidoes", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.Pedidoes", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Pedidoes", new[] { "ApplicationUserId" });
            DropIndex("dbo.Pedidoes", new[] { "ProdutoId" });
            DropIndex("dbo.Pedidoes", new[] { "RestauranteId" });
            DropTable("dbo.Restaurantes");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Pedidoes");
        }
    }
}
