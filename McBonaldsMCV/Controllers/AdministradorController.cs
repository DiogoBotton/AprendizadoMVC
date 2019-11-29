using McBonaldsMCV.Enums;
using McBonaldsMCV.Repositories;
using McBonaldsMCV.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMCV.Controllers {
    public class AdministradorController : AbstractController {
        PedidoRepository pedidoRepository = new PedidoRepository ();
        public IActionResult Dashboard () {
            bool ninguemLogado = string.IsNullOrEmpty (ObterUsuarioTipoSession ());

            if (!ninguemLogado && (uint) TiposUsuarioEnum.ADMINISTRADOR == uint.Parse(ObterUsuarioTipoSession())) {

                DashboardViewModel dbv = new DashboardViewModel ();
                var pedidos = pedidoRepository.ObterTodos ();
                foreach (var pedido in pedidos) {
                    switch (pedido.Status) {
                        case (uint) StatusPedidoEnum.APROVADO:
                            dbv.PedidosAprovados++;
                            break;
                        case (uint) StatusPedidoEnum.REPROVADO:
                            dbv.PedidosReprovados++;
                            break;
                        case (uint) StatusPedidoEnum.PENDENTE:
                            dbv.PedidosPendentes++;
                            dbv.Pedidos.Add (pedido);
                            break;
                        default:
                            dbv.PedidosPendentes++;
                            dbv.Pedidos.Add (pedido);
                            break;
                    }
                }
                dbv.NomeView = "Dashboard";
                dbv.UsuarioEmail = ObterUsuarioSession ();
                dbv.UsuarioNome = ObterUsuarioNomeSession ();
                return View (dbv);
            } else {
                return RedirectToAction ("Index", "Home");
            }
        }
    }
}