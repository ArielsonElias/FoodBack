namespace FoodBack_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteraçõesestruturaisparaosrelacionamentos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItensPedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Single(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        PedidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedidoes", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ProdutoId)
                .Index(t => t.PedidoId);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestauranteId = c.Int(nullable: false),
                        DataPedido = c.DateTime(nullable: false),
                        Restaurante_Id = c.Int(),
                        Restaurantes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurantes", t => t.Restaurante_Id)
                .ForeignKey("dbo.Restaurantes", t => t.RestauranteId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurantes", t => t.Restaurantes_Id)
                .Index(t => t.RestauranteId)
                .Index(t => t.Restaurante_Id)
                .Index(t => t.Restaurantes_Id);
            
            CreateTable(
                "dbo.Restaurantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Endereco = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        ValorUnitario = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItensPedidoes", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.Pedidoes", "Restaurantes_Id", "dbo.Restaurantes");
            DropForeignKey("dbo.Pedidoes", "RestauranteId", "dbo.Restaurantes");
            DropForeignKey("dbo.Pedidoes", "Restaurante_Id", "dbo.Restaurantes");
            DropForeignKey("dbo.ItensPedidoes", "PedidoId", "dbo.Pedidoes");
            DropIndex("dbo.Pedidoes", new[] { "Restaurantes_Id" });
            DropIndex("dbo.Pedidoes", new[] { "Restaurante_Id" });
            DropIndex("dbo.Pedidoes", new[] { "RestauranteId" });
            DropIndex("dbo.ItensPedidoes", new[] { "PedidoId" });
            DropIndex("dbo.ItensPedidoes", new[] { "ProdutoId" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.Restaurantes");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.ItensPedidoes");
        }
    }
}
