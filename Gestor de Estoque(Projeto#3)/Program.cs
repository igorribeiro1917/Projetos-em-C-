using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Estoque_Projeto_3_
{
    internal class Program
    {
        enum menu { Listar = 1, Adicionar = 2, Remover = 3, Entrada = 4, Saida = 5, Sair = 6 }

        static List<IEstoque> produtos = new List<IEstoque>();
        static void Main(string[] args)
        {
            Carregar();
            bool NaoEscolheuSair = true;

            while (NaoEscolheuSair)
            {
                
                Console.WriteLine("Bem vindo ao Sistema de Estoque!!");
                Console.WriteLine("1-Listar \n2-Adicionar \n3-Remover \n4- Registro de Entrada \n5-Registro de Saida \n6-Sair");
                Console.WriteLine("Escolha uma opção acima: ");
                int escolheu = int.Parse(Console.ReadLine());
                menu escolher = (menu)escolheu;
                
                switch (escolher)
                {
                    case menu.Listar:
                        Listagem();
                        break;
                    case menu.Adicionar:
                        Cadastro();
                        break;
                    case menu.Remover:
                        Remover();
                        break;
                    case menu.Entrada:
                        Entrada();
                        break;
                    case menu.Saida:
                        Saida();
                        break;
                     case menu.Sair:
                        NaoEscolheuSair = false;
                        break;
                    default:
                       Console.WriteLine("Opção selecionada não está contida no sistema de estoque");
                       break;
                }
                 Console.Clear();
            }
        }
      static public void Listagem()
      {
            int id = 0;
            Console.WriteLine("Listagem de produtos");
            foreach (IEstoque produto in produtos)
            {
                Console.WriteLine($"ID do produto: {id}");
                produto.Exibir();
                id++;
            }
            Console.WriteLine("Aperte ENTER para sair");
            Console.ReadLine();
      }
     static public void Remover()
     {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer remover");
            int escolheID = int.Parse(Console.ReadLine());
            if (escolheID >= 0 && escolheID < produtos.Count)
            {
                produtos.RemoveAt(escolheID);
                Salvar();
            }
     }
     static public void Entrada()
     {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer adicionar entrada: ");
            int escolheID = int.Parse(Console.ReadLine());
            if (escolheID >= 0 && escolheID <= produtos.Count)
            {
                produtos[escolheID].AdicionarEntrada();
                Salvar();
            }

     }  
     static public void Saida()
     {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer adcionar saida: ");
            int escolheID = int.Parse(Console.ReadLine());
            if (escolheID >= 0 && escolheID <= produtos.Count)
            {
                produtos[escolheID].AdicionarSaida();
                Salvar();
            }


     }   
        
     enum menuCadastro {ProdutoFisico=1, Ebook=2, Curso=3}
     static public void Cadastro()
     {
            Console.WriteLine("Cadastro de produto");
            Console.WriteLine("1-Produto Físico\n2-Ebook\n3-Curso");
            int escolhaCadastro = int.Parse(Console.ReadLine());
            menuCadastro escolhaMenu = (menuCadastro)escolhaCadastro;

            switch (escolhaMenu)
            {
                case menuCadastro.ProdutoFisico:
                    CadastrarProdFisico();
                    break;
                case menuCadastro.Ebook:
                    CadastrarEbook();
                    break;
                case menuCadastro.Curso:
                    CadastrarCurso();
                    break;
                default: 
                Console.WriteLine("Opção escolhida não está contida no menu de cadastro!!");
                    break;
            }   
     }
     static public void CadastrarProdFisico()
     {
            Console.WriteLine("Cadastrando produtos: ");
            Console.WriteLine("Produto: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
     }
     static public void CadastrarEbook()
     {
            Console.WriteLine("Cadastrando produtos: ");
            Console.WriteLine("Produto: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();
            
            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();
     }
     static public void CadastrarCurso()
     {
            Console.WriteLine("Cadastrando produtos; ");
            Console.WriteLine("Produto: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Curso c = new Curso(nome, preco, autor);
            produtos.Add(c);
            Salvar();
     }
     static public void Salvar()
     {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();
            encoder.Serialize(stream, produtos);

            stream.Close();
     }
     static public void Carregar()
     {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();
            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);
                if (produtos == null)
                {
                   produtos = new List<IEstoque>();
                }
            }
            catch (Exception ex)
            {
               produtos = new List<IEstoque>();
            }
            stream.Close();
     }
    
    }
}
