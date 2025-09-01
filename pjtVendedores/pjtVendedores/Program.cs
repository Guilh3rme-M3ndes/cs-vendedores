namespace pjtVendedores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vendedores vendedores = new Vendedores();
            string opcoes = "Opções \n" +
                "0 - Sair\n" +
                "1 - Cadastrar Vendedor\n" +
                "2 - Consultar Vendedor\n" +
                "3 - Excluir Vendedor\n" +
                "4 - Registrar Venda\n" +
                "5 - Listar Vendedores";
            int seletor = -1;
            int id;

            Console.WriteLine(new string('-',10) + "Gerenciamento de vendas" + new string('-', 10));

            while (seletor != 0)
            {
                id = vendedores.Qtde;
                Console.WriteLine(opcoes);
                Console.WriteLine(new string('-', 43));
                Console.WriteLine("Informe a opção desejada: ");
                seletor = Utils.lerInt(Console.ReadLine(), 0, "Precisa ser um inteiro!");
                switch(seletor)
                {
                    case 0:
                        Console.WriteLine("Fim da execução");
                        break;
                    case 1: 
                        Console.WriteLine("Informe o nome do vendedor:");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Informe o percentual de comissão: ");
                        double comissao = Utils.lerDouble(Console.ReadLine(), 0, "Precisa ser um numero positivo");
                        Vendedor vendedor = new Vendedor(id, nome, comissao);
                        if(vendedores.addVendedor(vendedor)) 
                        {
                            Console.WriteLine("Vendedor cadastrado!");
                        }
                        else
                         Console.WriteLine("A lista está cheia!");
                        Console.WriteLine(new string('-', 43));
                        break;
                    case 2:
                        {
                            Console.WriteLine("Informe o ID do vendedor: ");
                            int searchId = Utils.lerInt(Console.ReadLine(), 0, "Precisa ser um inteiro");
                            Vendedor v = new Vendedor(searchId);
                            Vendedor vendedorPesquisado = vendedores.searchVendedor(v);
                            if (vendedorPesquisado.Id == -1)
                            {
                                Console.WriteLine("Vendedor não encontrado");
                                Console.WriteLine(new string('-', 43));
                            }
                            else
                            {
                                Console.WriteLine(new string('-', 43));
                                Console.WriteLine("Dados do Vendedor");
                                Console.WriteLine("Id: " + vendedorPesquisado.Id +
                                    "\nNome: " + vendedorPesquisado.Nome +
                                    "\nVendidos: R$" + vendedorPesquisado.ValorVendas().ToString("f") +
                                    "\nComissão: R$" + vendedorPesquisado.ValorComissao().ToString("f") +
                                    "\nMedia dos dias: ");
                                for (int ii = 0; ii < 31; ii++)
                                {
                                    if (vendedorPesquisado.Vendas[ii].Qtde > 0)
                                    {
                                        Console.Write("R$ " + vendedorPesquisado.Vendas[ii].ValorMedio().ToString("f") + "(dia " + (ii + 1) +")");
                                    }
                                }
                                Console.WriteLine("\n" + new string('-', 43));
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Informe o ID do vendedor: ");
                            int deleteId = Utils.lerInt(Console.ReadLine(), 0, "Precisa ser um inteiro positivo");
                            Vendedor vdelete = new Vendedor(deleteId);
                            Console.WriteLine(vendedores.delVendedor(vdelete) ? 
                                $"Vendedor deletado id {vdelete.Id}!" : "Não foi possível deletar o usuario");
                            break;
                        }
                    case 4:
                        Console.WriteLine("Informe o n de vendas: ");
                        int qnt = Utils.lerInt(Console.ReadLine(), 1, "Precisa ser um inteiro positivo");
                        Console.WriteLine("Informe o valor vendido");
                        double valor = Utils.lerDouble(Console.ReadLine(), 0, "Precisa ser um número positivo");
                        Console.WriteLine("Informe o vendedor");
                        int vendId = Utils.lerInt(Console.ReadLine(), 0, "Precisa ser um inteiro positivo");
                        Console.WriteLine("Informe o dia da venda");
                        int dia = Utils.lerInt(Console.ReadLine(), 0, "Precisa ser um inteiro positivo");
                        while(dia < 1 || dia > 31)
                        {
                            Console.WriteLine("O dia deve estar entre 1 e 31");
                            dia = Utils.lerInt(Console.ReadLine(), 0, "Precisa ser um inteiro positivo");

                        }
                        Vendedor pesquisa = vendedores.searchVendedor(new Vendedor(vendId));
                        if (pesquisa.Id == -1 || pesquisa.Vendas[dia].Qtde > 0)
                        {
                            Console.WriteLine("Não foi possivel registrar a venda" + pesquisa.Id + pesquisa.Vendas[dia].Qtde);
                            Console.WriteLine(new string('-', 43));
                        }
                        else
                        {
                            vendedores.vendedores[vendId].RegistrarVenda(dia, new Venda(qnt, valor));
                            Console.WriteLine("Venda registrada");
                            Console.WriteLine(new string('-', 43));
                        }
                        break;
                    case 5:
                        for (int ii = 0; ii < vendedores.Max; ii++)
                        {
                            if (vendedores.vendedores[ii].Id != -1)
                            {
                                Console.WriteLine("\nId: " + vendedores.vendedores[ii].Id +
                                    "\nNome: " + vendedores.vendedores[ii].Nome + "" +
                                    "\nVendas totais: R$" + vendedores.vendedores[ii].ValorVendas() +
                                    "\nComissão: R$" + vendedores.vendedores[ii].ValorComissao());
                            }
                        }
                        Console.WriteLine(new string('-', 43));

                        Console.WriteLine("TOTAL VENDAS: R$" + vendedores.ValorVendas() + " TOTAL COMISSÃO: R$" + vendedores.ValorComissao());
                        ;
                        break;
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
