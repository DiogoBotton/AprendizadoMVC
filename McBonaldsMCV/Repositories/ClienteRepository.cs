using System;
using System.IO;
using McBonaldsMCV.Models;
namespace McBonaldsMCV.Repositories {
    public class ClienteRepository : BaseRepository{
        private const string PATH = "Database/Cliente.csv"; //Váriaveis constantes são escritas em tudo maiusculo.

        //Criação automatica do arquivo .csv
        public ClienteRepository () {
            if (!File.Exists (PATH)) {
                File.Create (PATH).Close (); //Necessita do Close() pois sem ele, cria-se o arquivo mas não é possível utiliza-lo depois, pois ele é removido da memoria.
                Cliente c = new Cliente(){
                    TipoUsuario = (uint) 0,
                    Nome = "Admin",
                    Email = "admin@email.com",
                    Senha = "admin",
                };
                Inserir(c);
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

                    c.TipoUsuario = uint.Parse(ExtrairValorDoCampo("tipo-usuario", linha));
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
        private string PrepararRegistroCSV (Cliente cliente) {
            return $"tipo-usuario={cliente.TipoUsuario};nome={cliente.Nome};endereco={cliente.Endereco};email={cliente.Email};senha={cliente.Senha};telefone={cliente.Telefone};data_nascimento={cliente.DataNascimento}";
        }
    }
}