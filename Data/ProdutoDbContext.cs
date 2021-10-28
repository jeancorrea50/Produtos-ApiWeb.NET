using Microsoft.EntityFrameworkCore;
using ProdutosApiWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosApiWeb.Data
{
    public class ProdutoDbContext : DbContext
    {
        public DbSet<ProdutoModel> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // string C com o banco de dados sql server
            optionsBuilder.UseSqlServer("Password=Bf18102907;Persist Security Info=True;User ID=jeancpcorrea;Initial Catalog=ApiWebProduto;Data Source=DESKTOP-43O4B71\\SQLEXPRESS");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // to passando que o novo das tabelas no banco de dados será "Categoria " e "Produto", caso nao passe este parametro, será criado no pural, ex "Produtos" 
            modelBuilder.Entity<ProdutoModel>().ToTable("Produto");

            modelBuilder.Entity<ProdutoModel>().Property(p => p.Preco).HasPrecision(10, 2);

            modelBuilder.Entity<ProdutoModel>().HasData(
                new ProdutoModel { IdProduto = 1, Marca = "Apple", Modelo = "Iphone 12 Pro", Cor = "Branco", Estoque = 2, Preco = 5600.00M },
                new ProdutoModel { IdProduto = 2, Marca = "Apple", Modelo = "Iphone 8", Cor = "Vermelho", Estoque = 7, Preco = 2600.00M },
                new ProdutoModel { IdProduto = 3, Marca = "Apple", Modelo = "Iphone X", Cor = "Branco", Estoque = 4, Preco = 3100.00M },
                new ProdutoModel { IdProduto = 4, Marca = "Apple", Modelo = "Iphone 11", Cor = "Preto", Estoque = 1, Preco = 4800.00M });
        }
    }
}