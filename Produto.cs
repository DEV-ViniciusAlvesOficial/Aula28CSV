using System.IO;
using System.Collections.Generic;
using System;

namespace Aula_27_28_29_30 {

    

    public class Produto {

        //Criação de Variaveis

        public int Codigo { get; set; }

        public string Nome { get; set; }

        public float Preco { get; set; }

        private const string PATH = "Database/produto.csv";

        // Criação de pasta  - - CSV

        public Produto (){

            string DataBase = PATH.Split ('/') [0];
            if (!Directory.Exists (DataBase)) {
                Directory.CreateDirectory (DataBase);
            }


            if (!File.Exists (PATH)) {
              
                File.Create (PATH).Close ();
            }
        }

     

        public void Cadastrar (Produto prod) {
            var linha = new string[] { PrepararLinha (prod) };
            File.AppendAllLines (PATH, linha);
        }

        public List<Produto> Ler () {

            

            List<Produto> produtos = new List<Produto> ();

           
            string[] linhas = File.ReadAllLines (PATH);

            foreach (var linha in linhas) {

                

                string[] dado = linha.Split (";");

                Produto p = new Produto ();
                p.Codigo = Int32.Parse (Separar (dado[0]));
                p.Nome = Separar (dado[1]);
                p.Preco = float.Parse (Separar (dado[2]));

                

                produtos.Add (p);

            }

            return produtos;
        }

        private string Separar (string _coluna) {
            return _coluna.Split ("=") [1];
        }

    
        public string PrepararLinha (Produto p) {
            return $"Código = {p.Codigo}; Nome = {p.Nome}; Preço = {p.Preco}";
        }
    }

}