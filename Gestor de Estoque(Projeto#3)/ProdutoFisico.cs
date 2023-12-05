using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Estoque_Projeto_3_
{
    [System.Serializable] 
    internal class ProdutoFisico:Produto, IEstoque
    {
        public float frete;
        private int estoque;
     
     public ProdutoFisico (string nome, float preco, float frete) 
     {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
            
     }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionando entrada do produto: {nome}");
            Console.WriteLine("Insira a quantidade do produto desejada: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque += entrada;
            Console.WriteLine("Entrada registrada!!!");
            Console.WriteLine("Aperte ENTER para sair");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionando saida do produto: {nome}");
            Console.WriteLine("Insira a quantidade da retirada do produto: ");
            int saida = int.Parse(Console.ReadLine());
            estoque -= saida;
            Console.WriteLine("Saida registrada!!");
            Console.WriteLine("Aperte ENTER para sair");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Estoque: {estoque}");
            Console.WriteLine("===================================");

            
            
        }
    }
}
