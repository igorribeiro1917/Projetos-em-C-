using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Estoque_Projeto_3_
{
    [System.Serializable]
    internal class Curso:Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome,float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionando entrada do produto {nome}");
            Console.WriteLine("Insira a quantidade de vagas: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas += entrada;
            Console.WriteLine("Entrada registrada!!!");
            Console.WriteLine("Aperte ENTER para sair");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionando saida do produto: {nome}");
            Console.WriteLine("Insira a quantidade retirada do produto: ");
            int saida = int.Parse(Console.ReadLine());
            vagas -= saida;
            Console.WriteLine("Saida registrada!!!");
            Console.WriteLine("Aperte ENTER para sair");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome do curso: {nome}");
            Console.WriteLine($"Preço do curso: {preco}");
            Console.WriteLine($"Autor do curso: {autor}");
            Console.WriteLine($"Vagas restantes: {vagas}");
            Console.WriteLine("==================================");
        }
    }
}
