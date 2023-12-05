using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Estoque_Projeto_3_
{
    [System.Serializable]
    internal class Ebook:Produto, IEstoque
    {
        public string autor;
        private int vendas;
    
     public Ebook(string nome, float preco, string autor)
     {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
     }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possível realizar a entrada de um produto digital");
            Console.WriteLine("Aperte ENTER para sair");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine("Insira a quantidade de vendas realizadas: ");
            int venda = int.Parse(Console.ReadLine());
            vendas += venda;
            Console.WriteLine("Saida de vendas realizada!!");
            Console.WriteLine("Aperte ENTER para sair");
            Console.ReadLine();
        
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Vendas: {vendas}");
            Console.WriteLine("===========================");
        }
    }
}
