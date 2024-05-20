﻿// <auto-generated />
using System;
using AutoAssistant_Challenge.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoAssistant_Challenge.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240520145226_Sprint4")]
    partial class Sprint4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoAssistant_Challenge.Models.CompraModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("CodigoCompra")
                        .HasColumnType("bigint");

                    b.Property<int>("CompradorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("datetime2");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompradorId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("AutoAssistant_Challenge.Models.EnderecoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<string>("GIA")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.Property<string>("IBGE")
                        .IsRequired()
                        .HasColumnType("varchar(7)");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SIAFI")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("AutoAssistant_Challenge.Models.FornecedorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("Reputacao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("AutoAssistant_Challenge.Models.PessoaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("Cnpj")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Telefone")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("AutoAssistant_Challenge.Models.ProdutoCompraModel", b =>
                {
                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("CompraId")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId", "CompraId");

                    b.HasIndex("CompraId");

                    b.ToTable("ProdutoCompras");
                });

            modelBuilder.Entity("AutoAssistant_Challenge.Models.ProdutoFornecedorModel", b =>
                {
                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId", "FornecedorId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("ProdutoFornecedores");
                });

            modelBuilder.Entity("AutoAssistant_Challenge.Models.ProdutoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<int>("TipoProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoProdutoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("AutoAssistant_Challenge.Models.TipoProdutoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("TipoProdutos");
                });

            modelBuilder.Entity("AutoAssistant_Challenge.Models.CompraModel", b =>
                {
                    b.HasOne("AutoAssistant_Challenge.Models.PessoaModel", "Comprador")
                        .WithMany()
                        .HasForeignKey("CompradorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AutoAssistant_Challenge.Models.FornecedorModel", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Comprador");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("AutoAssistant_Challenge.Models.FornecedorModel", b =>
                {
                    b.HasOne("AutoAssistant_Challenge.Models.PessoaModel", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("AutoAssistant_Challenge.Models.PessoaModel", b =>
                {
                    b.HasOne("AutoAssistant_Challenge.Models.EnderecoModel", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("AutoAssistant_Challenge.Models.ProdutoCompraModel", b =>
                {
                    b.HasOne("AutoAssistant_Challenge.Models.CompraModel", "Compra")
                        .WithMany("ProdutoCompra")
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoAssistant_Challenge.Models.ProdutoModel", "Produto")
                        .WithMany("ProdutoCompra")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compra");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("AutoAssistant_Challenge.Models.ProdutoFornecedorModel", b =>
                {
                    b.HasOne("AutoAssistant_Challenge.Models.FornecedorModel", "Fornecedor")
                        .WithMany("ProdutoFornecedor")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoAssistant_Challenge.Models.ProdutoModel", "Produto")
                        .WithMany("ProdutoFornecedor")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("AutoAssistant_Challenge.Models.ProdutoModel", b =>
                {
                    b.HasOne("AutoAssistant_Challenge.Models.TipoProdutoModel", "TipoProduto")
                        .WithMany()
                        .HasForeignKey("TipoProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoProduto");
                });

            modelBuilder.Entity("AutoAssistant_Challenge.Models.CompraModel", b =>
                {
                    b.Navigation("ProdutoCompra");
                });

            modelBuilder.Entity("AutoAssistant_Challenge.Models.FornecedorModel", b =>
                {
                    b.Navigation("ProdutoFornecedor");
                });

            modelBuilder.Entity("AutoAssistant_Challenge.Models.ProdutoModel", b =>
                {
                    b.Navigation("ProdutoCompra");

                    b.Navigation("ProdutoFornecedor");
                });
#pragma warning restore 612, 618
        }
    }
}