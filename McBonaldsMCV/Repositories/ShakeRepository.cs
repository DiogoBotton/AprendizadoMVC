using System.Collections.Generic;
using System.IO;
using McBonaldsMCV.Models;

namespace McBonaldsMCV.Repositories
{
    public class ShakeRepository
    {
        private const string PATH = "Database/Shake.csv";
        public List<Shake> ObterTodos () {
            List<Shake> shakes = new List<Shake> ();

            string[] registros = File.ReadAllLines (PATH);
            foreach (string linha in registros) {
                Shake h = new Shake ();
                string[] dados = linha.Split (";");
                h.Nome = dados[0];
                h.Preco = System.Convert.ToDouble (dados[1]);
                shakes.Add (h);
            }
            return shakes;
        }
    }
}