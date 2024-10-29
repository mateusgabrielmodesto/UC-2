using System;
using System.Collections.Generic;

namespace Ecommerce
{

    internal class Program
    {
        static List<Categoria> categorias = new List<Categoria>();
        static List<Fornecedor> fornecedores = new List<Fornecedor>();
        static List<Produto> produtos = new List<Produto>();
       

        static void Main(string[] args)
        {
            int opcao;

            do
            {
                Console.WriteLine("BEM VINDO AO MEU ERP DE VENDAS DE CELULARES");
                Separador('=', 100);
                Console.WriteLine("CADASTRO GERAL DO SISTEMA");
                Console.WriteLine("(1) - Cadastro de Categorias");
                Console.WriteLine("(2) - Cadastro de Fornecedores");
                Console.WriteLine("(3) - Cadastro de Produtos");
                Console.WriteLine("(4) - Listar Categorias");
                Console.WriteLine("(5) - Listar Fornecedores");
                Console.WriteLine("(6) - Listar Produtos");
                Console.WriteLine("(0) - Sair");
                Console.WriteLine("Digite sua opção: ");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        ModuloCategoria();
                        break;
                    case 2:
                        ModuloFornecedor();
                        break;
                    case 3:
                        ModuloProduto();
                        break;
                    case 4:
                        ListarCategorias();
                        break;
                    case 5:
                        ListarFornecedores();
                        break;
                    case 6:
                        ListarProdutos();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

            } while (opcao != 0);
        }

        static void Separador(char simbolo, int quantidade)
        {
            for (int i = 0; i < quantidade; i++)
            {
                Console.Write(simbolo);
            }
            Console.Write("\n");
        }

        static void ModuloCategoria()
        {
            Console.WriteLine("Digite o nome da nova categoria (ex: Smartphones, Acessórios, etc.): ");
            string nomeCategoria = Console.ReadLine();

            var categoria = new Categoria
            {
                Nome = nomeCategoria
            };

            categorias.Add(categoria);

            Console.WriteLine("Categoria cadastrada com sucesso!");
        }

        static void ModuloFornecedor()
        {
            Console.WriteLine("Digite o nome do fornecedor (ex: Samsung, Apple, Xiaomi): ");
            string nomeFornecedor = Console.ReadLine();

            Console.WriteLine("Digite o CNPJ do fornecedor");
            string CnpjFornecedor = Console.ReadLine();

            var fornecedor = new Fornecedor()
            {
                Nome = nomeFornecedor + "\n   CNPJ: " + CnpjFornecedor
            };

            fornecedores.Add(fornecedor);
            Console.WriteLine("Fornecedor cadastrado com sucesso!");
        }

        static void ModuloProduto()
        {
            Console.WriteLine("Digite o nome do produto (ex: iPhone 13, Galaxy S21): ");
            string nomeProduto = Console.ReadLine();

            Console.WriteLine("Escolha uma categoria para o produto: ");
            ListarCategorias();
            int categoriaEscolhida = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Escolha um fornecedor para o produto: ");
            ListarFornecedores();
            int fornecedorEscolhido = int.Parse(Console.ReadLine()) - 1;

            var produto = new Produto
            {
                Nome = nomeProduto,
                Categoria = categorias[categoriaEscolhida],
                Fornecedor = fornecedores[fornecedorEscolhido],
            };

            produtos.Add(produto);
            Console.WriteLine("Produto cadastrado com sucesso!");
        }

        static void ListarCategorias()
        {
            if (categorias.Count > 0)
            {
                Console.WriteLine("CATEGORIAS CADASTRADAS: ");
                for (int i = 0; i < categorias.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + categorias[i].Nome);
                }
            }
            else
            {
                Console.WriteLine("Nenhuma categoria cadastrada.");
            }
        }

        static void ListarFornecedores()
        {
            if (fornecedores.Count > 0)
            {
                Console.WriteLine("FORNECEDORES CADASTRADOS: ");
                for (int i = 0; i < fornecedores.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + fornecedores[i].Nome);
                }
            }
            else
            {
                Console.WriteLine("Nenhum fornecedor cadastrado.");
            }
        }

        static void ListarProdutos()
        {
            if (produtos.Count > 0)
            {
                Console.WriteLine("PRODUTOS CADASTRADOS: ");
                foreach (var produto in produtos)
                {
                    Console.WriteLine($"Produto: {produto.Nome}, Categoria: {produto.Categoria.Nome}, Fornecedor: {produto.Fornecedor.Nome}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum produto cadastrado.");
            }
        }
    }
}
