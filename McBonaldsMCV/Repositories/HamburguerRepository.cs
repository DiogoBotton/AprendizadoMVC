using System.Collections.Generic;
using System.IO;
using McBonaldsMCV.Models;

namespace McBonaldsMCV.Repositories {
    public class HamburguerRepository {
        private const string PATH = "Database/Hamburguer.csv";

        public double ObterPreco (string nomeHamburguer){
            var lista = ObterTodos();
            double preco = 0;

            foreach (var hbg in lista)
            {
                if(hbg.Nome.Equals(nomeHamburguer)){
                    preco = hbg.Preco;
                    break;
                }
            }
            return preco;
        }
        public List<Hamburguer> ObterTodos () {
            List<Hamburguer> hamburgueres = new List<Hamburguer> ();

            string[] registros = File.ReadAllLines (PATH);
            foreach (string linha in registros) {
                Hamburguer h = new Hamburguer ();
                string[] dados = linha.Split (";");
                h.Nome = dados[0];
                h.Preco = System.Convert.ToDouble (dados[1]);
                hamburgueres.Add (h);
            }
            return hamburgueres;
        }
    }
}