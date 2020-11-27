using System;

namespace SistemaDeProdutos
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] produtos = new string[10];
            float[] precos = new float[10];
            bool[] promocao = new bool [10];
            int i = 0;
                Console.WriteLine("Menu");
            do {
                Console.Write("Escolha uma operação\n- Digite 0 para sair\n- Digite 1 para cadastrar produtos\n - Digite 2 para listar os produtos\n- Digite 3 para mostrar o menu\n");
            } while (EntradaMenu(Console.ReadLine()));

            bool EntradaMenu(string entrada) {
                switch (entrada)
                {
                    case "0":
                        Console.WriteLine("Saindo");
                        return false;
                    case "1":
                        CadastrarProduto();
                        Console.WriteLine("Menu");
                        return true;
                    case "2":
                        ListarProdutos();
                        Console.WriteLine("Menu");
                        return true;
                    case "3":
                        Console.WriteLine("Menu");
                        return true;
                    default:
                    Console.WriteLine("Valor inválido");
                        return true;
                }
                
            }
            void CadastrarProduto() {
                if(produtos[9] == null){
                    Console.WriteLine("Todos os produtos foram cadastrados");
                } else {
                    while(i < produtos.Length){
                        Console.WriteLine("Produto " + i);
                        Console.WriteLine("Digite o nome do produto");
                        produtos[i] = Console.ReadLine();
                        Console.WriteLine("Digite o preço");
                        precos[i] = float.Parse(Console.ReadLine());
                        do {
                            Console.WriteLine("O produto está em promoção? (S/N)");
                            switch (Console.ReadLine().ToUpper()){
                                case "S":
                                    promocao[i] = true;
                                    break;
                                case "N":
                                    promocao[i] = false;
                                    break;
                                default:
                                    Console.WriteLine("Valor inválido");
                                    break;
                            }
                        } while (promocao[i] != true != promocao[i] != false);
                        Console.WriteLine("Produto " + i + " cadastrado");
                    }
                }
            }
            void ListarProdutos(){
                for (var i = 0; i < produtos.Length; i++){
                    if(produtos[i] != null){
                        if (promocao[i]){
                            Console.WriteLine("- " + produtos[i] + "    custa " + precos[i] + " com desconto");
                        } else {
                            Console.WriteLine("- " + produtos[i] + "    custa " + precos[i]);
                        }
                    } else {
                        break;
                    }
                }
            }
        }
    }
}
