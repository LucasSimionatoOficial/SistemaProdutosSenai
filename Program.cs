using System;

namespace SistemaDeProdutos
{
    class Program
    {
        static void Main(string[] args)
        {            string senhaAdmin = "12345678";
            string loginAdmin = "admin";
            string[] vendedorEmail = new string[5];
            string[] vendedorNome = new string[5];
            string[] vendedorSenha = new string[5];
            string [] vendedorCadastrado = {"não","não","não","não","não"};

            string[] produtos = new string[10];
            float[] precos = new float[10];
            bool[] promocao = new bool [10];
            int i = 0;

            do {
                Console.WriteLine("Menu Principal");
                Console.Write("- Digite 0 para sair\n- Digite 1 para logar\n- Digite 2 para cadastrar vendedor\n");
            } while(Menuprincipal(Console.ReadLine()));

            bool Menuprincipal(string operacao) {
                switch (operacao)
                {
                    case "0":
                        Console.WriteLine("Saindo do sistema");
                        return false;
                    case "1":
                        LoginVendedor();
                        return true;
                    case "2":
                        CadastroVendedor();
                        return true;
                    default:
                        Console.WriteLine("Valor inválido");
                        return false;
                }
            }
            int CadastroVendedor() {
                string transferenciaLogin;
                string transferenciaSenha;
                Console.WriteLine("Cadastro de vendedores");
                Console.WriteLine("Antes de continuar, faça login como administrador");
                while(true) {
                    Console.WriteLine("Digite seu email");
                    transferenciaLogin = Console.ReadLine();
                    Console.WriteLine("Digite a senha");
                    transferenciaSenha = Console.ReadLine();
                    if (senhaAdmin == transferenciaSenha && loginAdmin == transferenciaLogin){
                        break;
                    } else {
                        Console.WriteLine("email ou senha incorreta");
                        Console.WriteLine("Digite 0 para voltar ao menu principal");
                        Console.WriteLine("Digite qualquer outra coisa para continuar");
                        if (Console.ReadLine() == "0"){
                            return 1;
                        }
                    }
                }

                for (var i = 0; i < vendedorNome.Length; i++){

                    if (vendedorCadastrado[i] == "não") {
                        Console.WriteLine("Digite o nome do vendedor");
                        vendedorNome[i] = Console.ReadLine();
                        Console.WriteLine("Digite o email do vendedor");
                        vendedorEmail[i] = Console.ReadLine();
                        Console.WriteLine("Digite a senha do vendedor");
                        vendedorSenha[i] = Console.ReadLine();
                        Console.WriteLine("Vendedor cadastrado");
                        vendedorCadastrado[i] = "sim";
                        Console.WriteLine("Deseja cadastrar mais um usuário?");
                        Console.WriteLine("Digite 0 para sair e qualquer outra coisa para continuar");
                        if(Console.ReadLine() == "0" && i < vendedorCadastrado.Length) {
                            break;
                        }
                    }
                }
                return 1;
            }

            int LoginVendedor() {
                string transferenciaEmail;
                string transferenciaSenha;
                bool verificacao = false;
                while (true) {
                    Console.WriteLine("Login vendedor");
                    Console.WriteLine("Digite seu email");
                    transferenciaEmail = Console.ReadLine();
                    Console.WriteLine("Digite sua senha");
                    transferenciaSenha = Console.ReadLine();

                    for (var i = 0; i < vendedorNome.Length; i++)
                    {
                        if(vendedorEmail[i] == transferenciaEmail){
                            if(vendedorSenha[i] == transferenciaSenha)
                            verificacao = true;
                        }
                    }
                    if(verificacao){
                        MenuOperacoes();
                        return 1;
                    }
                    Console.WriteLine("login ou senha inválido, tentar novamente?");
                    Console.WriteLine("Digite 0 para sair ou qualquer outra coisa para continuar");
                    if(Console.ReadLine() == "0"){
                        return 1;
                    }
                }
            }



            void MenuOperacoes () {
                Console.WriteLine("Menu de operações");
                do {
                    Console.Write("Escolha uma operação\n- Digite 0 para ir para o menu principal\n- Digite 1 para cadastrar produtos\n- Digite 2 para listar os produtos\n- Digite 3 para listar apenas os produtos em promoção\n");
                } while (EntradaMenu(Console.ReadLine()));
            }

            bool EntradaMenu(string entrada) {
                switch (entrada)
                {
                    case "0":
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
                        ListarPromocoes();
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

            void ListarPromocoes() {
                Console.WriteLine("Produtos com desconto");
                for (var i = 0; i < produtos.Length; i++){
                    if(produtos[i] != null){
                        if (promocao[i]){
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
