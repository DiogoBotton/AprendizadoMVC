using System.IO;
using McBonaldsMCV.Models;

namespace McBonaldsMCV.Repositories
{
    public class PedidoRepository
    {
        private const string PATH = "Database/Pedido.csv";

        public PedidoRepository(){
            if(!File.Exists(PATH)){
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Pedido pedido){
            try
            {
                string[] dados = {PrepararRegistroCSV(pedido)};
                File.AppendAllLines(PATH,dados);
                return true;
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public string PrepararRegistroCSV(Pedido pedido){
            Cliente cliente = pedido.cliente;
            Hamburguer hbg = pedido.hamburguer;
            Shake shk = pedido.shake;

            return $"cliente_nome={cliente.Nome};cliente_endereco={cliente.Endereco};cliente_telefone={cliente.Telefone};cliente_email={cliente.Email};hamburguer_nome={hbg.Nome};hamburguer_preco={hbg.Preco};shake_nome={shk.Nome}shake_preco={shk.Preco};data_pedido={pedido.DataDoPedido};preco_total={pedido.PrecoTotal}";
        }
    }
}