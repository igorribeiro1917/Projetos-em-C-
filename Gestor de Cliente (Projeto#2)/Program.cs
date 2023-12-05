using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gestor_de_Cliente__Projeto_2_
{
    public class Program
    {
        [System.Serializable]
        struct cliente
        {
            public string nome;
            public string email;
            public string cpf;

        }
      static  List<cliente> clienteList = new List<cliente>();
        
       
        enum Menu { Listagem=1, Adicionar=2, Remover=3, Sair=4}

        static void Main(string[] args)
        {
            carregar();
           
            bool NaoEscolheuSair = true;

            while (NaoEscolheuSair)
            {

                Console.WriteLine("Bem vindo ao Sistema de clientes!! Escolha uma opção abaixo:");
                Console.WriteLine("1-Listagem\n2-Adcionar\n3-Remover\n4-Sair");
                int escolha = int.Parse(Console.ReadLine());

                Menu opcao = (Menu)escolha;
                switch (opcao)
                {
                    case Menu.Listagem:
                        exibir();
                        break;
                    case Menu.Adicionar:
                        Cadastrar();
                        break;
                    case Menu.Remover:
                        remover();
                        break;
                    case Menu.Sair:
                        NaoEscolheuSair = false;
                        break;
                    default: 
                    Console.WriteLine("O sistema não contem a opção selecionada");
                        break;
                
                }   
                Console.Clear();

            }
         
        
        
        
        
        }
     static void Cadastrar()
     {
            cliente Clientes = new cliente();
            Console.WriteLine("Bem vindo ao cadastro de cliente");
            Console.WriteLine("Insira o nome do cliente: ");
            Clientes.nome = Console.ReadLine();
            Console.WriteLine("Insira o email do cliente: ");
            Clientes.email = Console.ReadLine();
            Console.WriteLine("Insira o CPF do cliente: ");
            Clientes.cpf = Console.ReadLine();

            clienteList.Add(Clientes);
            Salvar();
            
            Console.WriteLine("Cadastro concluido");
            Console.WriteLine("Aperte ENTER para voltar ao MENU");
            Console.ReadLine();
     }
        static void exibir()
        {
            Console.WriteLine("Listagem de clientes");
            if (clienteList.Count > 0)
            {

                int i = 0;

                foreach (cliente Clientes in clienteList)
                {
                    Console.WriteLine($"ID: {i}");
                    Console.WriteLine($"Nome: {Clientes.nome}");
                    Console.WriteLine($"Email: {Clientes.email}");
                    Console.WriteLine($"CPF: {Clientes.cpf}");
                    Console.WriteLine("========================");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Não houve cadastro de nehum cliente");
            }
            Console.WriteLine("Aperte ENTER para sair");
            Console.ReadLine();
        }
      static void Salvar()
      {
        FileStream stream = new FileStream("client.dat", FileMode.OpenOrCreate);
        BinaryFormatter enconder = new BinaryFormatter();

            enconder.Serialize(stream, clienteList);
            stream.Close();
      }
      static void carregar()
      {
            FileStream stream = new FileStream("client.dat", FileMode.OpenOrCreate);
            try
            {
                
                BinaryFormatter enconder = new BinaryFormatter();

                clienteList = (List<cliente>)enconder.Deserialize(stream);
                if (clienteList == null)
                {
                    clienteList = new List<cliente>();
                }
            } 
            catch(Exception ex)
            {
                clienteList = new List<cliente>();
            }
            stream.Close();
      }
      static void remover()
      {
            exibir();
            Console.WriteLine("Digite o ID que você deseja remver.");
            int escolha = int.Parse(Console.ReadLine());

            if (escolha >= 0 && escolha < clienteList.Count)
            {
                clienteList.RemoveAt(escolha);

            }
            else
            {
                Console.WriteLine("O ID digitado é inválido. Aperte ENTER e tente novamente");
                Console.ReadLine();
            }

            Salvar();
      }
    
    
    
    
    }
   

        
    
    
    
    
}






