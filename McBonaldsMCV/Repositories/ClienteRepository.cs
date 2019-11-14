using McBonaldsMCV.Models;
using System.IO;
namespace McBonaldsMCV.Repositories
{
    public class ClienteRepository
    {
        private const string PATH = "Database/Cliente.csv"; //Váriaveis constantes são escritas em tudo maiusculo.

        //Criação automatica do arquivo .csv
        public ClienteRepository(){
            if(!File.Exists(PATH)){
                File.Create(PATH).Close(); //Necessita do Close() pois sem ele, cria-se o arquivo mas não é possível utiliza-lo depois, pois ele é removido da memoria.
            }
        }

        public bool Inserir(Cliente cliente){
            try{
            string[] dadosCliente = {PrepararRegistroCSV(cliente)}; //Método que irá construir a linha(registro) do cliente.
            File.AppendAllLines(PATH, dadosCliente);
            return true;

            }catch(IOException e){
                System.Console.WriteLine(e.StackTrace);
                return false;
            }

        }

        private string PrepararRegistroCSV(Cliente cliente){
            return $"nome={cliente.Nome};endereco={cliente.Endereco};email={cliente.Email};senha={cliente.Senha};telefone={cliente.Telefone};data_nascimento={cliente.DataNascimento};";
        }
    }
}