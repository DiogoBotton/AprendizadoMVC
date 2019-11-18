using System;
using System.IO;
using McBonaldsMCV.Models;
namespace McBonaldsMCV.Repositories {
    public class ClienteRepository {
        private const string PATH = "Database/Cliente.csv"; //Váriaveis constantes são escritas em tudo maiusculo.

        //Criação automatica do arquivo .csv
        public ClienteRepository () {
            if (!File.Exists (PATH)) {
                File.Create (PATH).Close (); //Necessita do Close() pois sem ele, cria-se o arquivo mas não é possível utiliza-lo depois, pois ele é removido da memoria.
            }
        }

        public bool Inserir (Cliente cliente) {
            try {
                string[] dadosCliente = { PrepararRegistroCSV (cliente) }; //Método que irá construir a linha(registro) do cliente.
                File.AppendAllLines (PATH, dadosCliente);
                return true;

            } catch (IOException e) {
                System.Console.WriteLine (e.StackTrace);
                return false;
            }

        }

        public Cliente ObterPor (string email) {
            string[] linhas = File.ReadAllLines (PATH);

            foreach (var linha in linhas) {
                if (ExtrairValorDoCampo ("email", linha).Equals (email)) {
                    Cliente c = new Cliente ();

                    c.Nome = ExtrairValorDoCampo ("nome", linha);
                    c.Email = ExtrairValorDoCampo ("email", linha);
                    c.Senha = ExtrairValorDoCampo ("senha", linha);
                    c.Endereco = ExtrairValorDoCampo ("endereco", linha);
                    c.Telefone = ExtrairValorDoCampo ("telefone", linha);
                    c.DataNascimento = DateTime.Parse (ExtrairValorDoCampo ("data_nascimento", linha));
                    return c;
                }
            }
            return null;
        }
        private string ExtrairValorDoCampo (string nomeCampo, string linha) {
            var chave = nomeCampo;

            var indiceChave = linha.IndexOf (chave);
            var indiceTerminal = linha.IndexOf (";", indiceChave); //IndexOf sempre retorna o indice do ultimo caracter da string.

            var valor = "";
            //IndexOf retorna -1 caso não encontre o valor de string.
            if (indiceTerminal != -1) { //Caso for diferente de -1, primeiro parametro startIndex, segundo EndIndex.
                valor = linha.Substring (indiceChave, indiceTerminal - indiceChave); 
            } else {
                valor = linha.Substring (indiceChave); //caso for igual á -1, unico parametro startIndex até o final da string.
            }
            System.Console.WriteLine ($"Campo {nomeCampo} e valor {valor}");
            return valor.Replace (nomeCampo + "=", "");
        }

        private string PrepararRegistroCSV (Cliente cliente) {
            return $"nome={cliente.Nome};endereco={cliente.Endereco};email={cliente.Email};senha={cliente.Senha};telefone={cliente.Telefone};data_nascimento={cliente.DataNascimento}";
        }
    }
}