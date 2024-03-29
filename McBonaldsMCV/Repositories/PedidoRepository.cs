using System;
using System.Collections.Generic;
using System.IO;
using McBonaldsMCV.Models;

namespace McBonaldsMCV.Repositories {
    public class PedidoRepository : BaseRepository {
        private const string PATH = "Database/Pedido.csv";

        public PedidoRepository () {
            if (!File.Exists (PATH)) {
                File.Create (PATH).Close ();
            }
        }

        public bool Inserir (Pedido pedido) {
            try {
                var numPedidos = File.ReadAllLines(PATH).Length;
                pedido.ID = (ulong) ++numPedidos;

                string[] dados = { PrepararRegistroCSV (pedido) };
                File.AppendAllLines (PATH, dados);
                return true;
            } catch (IOException e) {
                System.Console.WriteLine (e.StackTrace);
                return false;
            }
        }
        public bool Atualizar (Pedido pedido){
            var pedidosTotais = File.ReadAllLines(PATH);
            var pedidoCSV = PrepararRegistroCSV(pedido);
            var linhaPedido = -1;
            bool resultado = false;

            for (int i = 0; i < pedidosTotais.Length; i++)
            {
                var idConvertido = ulong.Parse(ExtrairValorDoCampo("id",pedidosTotais[i]));

                if(pedido.ID.Equals(idConvertido)){
                    linhaPedido = i;
                    resultado = true;
                    break;
                }
            }

            if(resultado){
                pedidosTotais[linhaPedido] = pedidoCSV;
                File.WriteAllLines(PATH, pedidosTotais);
                return resultado;
            }
            
            return resultado;
        }
        public List<Pedido> ObterTodosPorCliente (string emailCliente) {
            List<Pedido> pedidosCliente = new List<Pedido>();
            var pedidos = ObterTodos ();
            foreach (var pedido in pedidos)
            {
                if(pedido.cliente.Email.Equals(emailCliente)){
                    pedidosCliente.Add(pedido);
                }
            }
            return pedidosCliente;
        }
        public Pedido ObterPor(ulong id){
            var pedidos = ObterTodos();
            foreach (var pedido in pedidos)
            {
                if(pedido.ID.Equals(id)){
                    return pedido;
                }
            }
            return null;
        }
        public List<Pedido> ObterTodos () {
            List<Pedido> pedidos = new List<Pedido> ();
            var linhas = File.ReadAllLines (PATH);
            foreach (var linha in linhas) {
                Pedido pedido = new Pedido ();

                pedido.ID = ulong.Parse(ExtrairValorDoCampo("id", linha));
                pedido.Status = uint.Parse(ExtrairValorDoCampo("status-pedido", linha));
                pedido.cliente.Nome = ExtrairValorDoCampo ("cliente_nome", linha);
                pedido.cliente.Endereco = ExtrairValorDoCampo ("cliente_endereco", linha);
                pedido.cliente.Telefone = ExtrairValorDoCampo ("cliente_telefone", linha);
                pedido.cliente.Email = ExtrairValorDoCampo ("cliente_email", linha);
                pedido.hamburguer.Nome = ExtrairValorDoCampo ("hamburguer_nome", linha);
                pedido.hamburguer.Preco = Convert.ToDouble (ExtrairValorDoCampo ("hamburguer_preco", linha));
                pedido.shake.Nome = ExtrairValorDoCampo ("shake_nome", linha);
                pedido.shake.Preco = Convert.ToDouble (ExtrairValorDoCampo ("shake_preco", linha));
                pedido.DataDoPedido = Convert.ToDateTime (ExtrairValorDoCampo ("data_pedido", linha));
                pedido.PrecoTotal = Convert.ToDouble (ExtrairValorDoCampo ("preco_total", linha));
                pedidos.Add (pedido);
            }
            return pedidos;
        }
        private string PrepararRegistroCSV (Pedido pedido) {
            Cliente cliente = pedido.cliente;
            Hamburguer hbg = pedido.hamburguer;
            Shake shk = pedido.shake;

            return $"id={pedido.ID};status-pedido={pedido.Status};cliente_nome={cliente.Nome};cliente_endereco={cliente.Endereco};cliente_telefone={cliente.Telefone};cliente_email={cliente.Email};hamburguer_nome={hbg.Nome};hamburguer_preco={hbg.Preco};shake_nome={shk.Nome};shake_preco={shk.Preco};data_pedido={pedido.DataDoPedido};preco_total={pedido.PrecoTotal}";
        }
    }
}