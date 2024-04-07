using AutoAssistant_Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoAssistant_Challenge.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<PessoaModel> Pessoas {  get; set; }
        public DbSet<TipoProdutoModel> TipoProdutos { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<FornecedorModel> Fornecedores { get; set;}
        public DbSet<CompraModel> Compras { get; set; }
        public DbSet<ProdutoFornecedorModel> ProdutoFornecedores { get; set; }
        public DbSet<ProdutoCompraModel> ProdutoCompras { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PessoaModel>()
                .Property(p => p.Sexo)
                .HasConversion<string>();

            modelBuilder.Entity<CompraModel>()
                .HasOne(c => c.Comprador)
                .WithMany()
                .HasForeignKey(c => c.CompradorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CompraModel>()
                .HasOne(c => c.Fornecedor)
                .WithMany()
                .HasForeignKey(c => c.FornecedorId)
                .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento ManyToMany Produto e Fornecedor
            modelBuilder.Entity<ProdutoFornecedorModel>().
                HasKey(pf => new { pf.ProdutoId, pf.FornecedorId });
            modelBuilder.Entity<ProdutoFornecedorModel>().
                HasOne(p => p.Produto).
                WithMany(pf => pf.ProdutoFornecedor).
                HasForeignKey(p => p.ProdutoId);
            modelBuilder.Entity<ProdutoFornecedorModel>().
                HasOne(f => f.Fornecedor).
                WithMany(pf => pf.ProdutoFornecedor).
                HasForeignKey(f => f.FornecedorId);

            //Relacionamento ManyToMany Produto e Compra
            modelBuilder.Entity<ProdutoCompraModel>().
                HasKey(pc => new { pc.ProdutoId, pc.CompraId });
            modelBuilder.Entity<ProdutoCompraModel>().
                HasOne(p => p.Produto).
                WithMany(pc => pc.ProdutoCompra).
                HasForeignKey(p => p.ProdutoId);
            modelBuilder.Entity<ProdutoCompraModel>().
                HasOne(c => c.Compra).
                WithMany(pc => pc.ProdutoCompra).
                HasForeignKey(c => c.CompraId);


        }
    }
}
