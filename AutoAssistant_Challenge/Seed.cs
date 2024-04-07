using AutoAssistant_Challenge.Data;
using AutoAssistant_Challenge.Models;

namespace AutoAssistant_Challenge
{
    //Classe para popular o banco de dados ao iniciar o programa.
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            if (!_context.Produtos.Any())
            {
                var tipoProdutos = new List<TipoProdutoModel>
                {
                    new TipoProdutoModel { Nome = "Eletrônicos", Descricao = "Produtos eletrônicos em geral" },
                    new TipoProdutoModel { Nome = "Roupas", Descricao = "Roupas de diversas categorias" },
                    new TipoProdutoModel { Nome = "Alimentos", Descricao = "Produtos alimentícios variados" }
                };
                _context.TipoProdutos.AddRange(tipoProdutos);
                _context.SaveChanges();

                var fornecedores = new List<FornecedorModel>
                {
                    new FornecedorModel
                    {
                        Nome = "Fornecedor A",
                        Pessoa = new PessoaModel
                        {
                            Nome = "João",
                            Sexo = Sexo.Masculino,
                            Telefone = 123456789,
                            Email = "joao@fornecedor.com",
                            Endereco = new EnderecoModel
                            {
                                Logradouro = "Rua A",
                                Complemento = "Complemento A",
                                Bairro = "Centro",
                                Localidade = "Cidade A",
                                UF = "UF A",
                                Cep = "12345-678",
                                IBGE = "1234567",
                                GIA = "1234",
                                DDD = "99",
                                SIAFI = "9876"
                            },
                            Cnpj = 12345678901234,
                            Senha = "senha" // Exemplo de senha, deve ser ajustado conforme sua lógica
                        },
                        Reputacao = "Boa"
                    },
                    new FornecedorModel
                    {
                        Nome = "Fornecedor B",
                        Pessoa = new PessoaModel
                        {
                            Nome = "Maria",
                            Sexo = Sexo.Feminino,
                            Telefone = 987654321,
                            Email = "maria@fornecedor.com",
                            Endereco = new EnderecoModel
                            {
                                Logradouro = "Rua B",
                                Complemento = "Complemento B",
                                Bairro = "Centro",
                                Localidade = "Cidade B",
                                UF = "UF B",
                                Cep = "98765-432",
                                IBGE = "7654321",
                                GIA = "4321",
                                DDD = "88",
                                SIAFI = "5678"
                            },
                            Cnpj = 98765432109876,
                            Senha = "outrasenha" // Exemplo de senha, deve ser ajustado conforme sua lógica
                        },
                        Reputacao = "Excelente"
                    }
                };
                _context.Fornecedores.AddRange(fornecedores);
                _context.SaveChanges();

                var produtos = new List<ProdutoModel>
                {
                    new ProdutoModel
                    {
                        Nome = "Celular",
                        Descricao = "Smartphone de última geração",
                        TipoProduto = tipoProdutos.First(tp => tp.Nome == "Eletrônicos"),
                        ProdutoFornecedor = new List<ProdutoFornecedorModel>
                        {
                            new ProdutoFornecedorModel
                            {
                                Fornecedor = fornecedores.First(f => f.Nome == "Fornecedor A"),
                                Preco = 1500,
                                Quantidade = 10
                            },
                            new ProdutoFornecedorModel
                            {
                                Fornecedor = fornecedores.First(f => f.Nome == "Fornecedor B"),
                                Preco = 1400,
                                Quantidade = 8
                            }
                        }
                    },
                    new ProdutoModel
                    {
                        Nome = "Camiseta",
                        Descricao = "Camiseta casual",
                        TipoProduto = tipoProdutos.First(tp => tp.Nome == "Roupas"),
                        ProdutoFornecedor = new List<ProdutoFornecedorModel>
                        {
                            new ProdutoFornecedorModel
                            {
                                Fornecedor = fornecedores.First(f => f.Nome == "Fornecedor B"),
                                Preco = 50,
                                Quantidade = 20
                            }
                        }
                    },
                    new ProdutoModel
                    {
                        Nome = "Arroz",
                        Descricao = "Arroz branco",
                        TipoProduto = tipoProdutos.First(tp => tp.Nome == "Alimentos"),
                        ProdutoFornecedor = new List<ProdutoFornecedorModel>
                        {
                            new ProdutoFornecedorModel
                            {
                                Fornecedor = fornecedores.First(f => f.Nome == "Fornecedor A"),
                                Preco = 5,
                                Quantidade = 100
                            }
                        }
                    }
                };
                _context.Produtos.AddRange(produtos);
                _context.SaveChanges();
            }
        }
    }
}
