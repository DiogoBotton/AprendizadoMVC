using McBonaldsMCV.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMCV.Controllers {
    public class PedidoController : Controller {
        public IActionResult Index () {
            return View ();
        }
        public IActionResult Registrar (IFormCollection form) {
            Pedido pedido = new Pedido ();

            Shake shake = new Shake ();
            shake.Nome = form["shake"];
            shake.Preco = 0.0;
            pedido.shake = shake;

            Hamburguer hamburguer = new Hamburguer ();
            shake.Nome = form["hamburguer"];
            shake.Preco = 0.0;
            pedido.hamburguer = hamburguer;

            Cliente cliente = new Cliente () {
                Nome = form["nome"],
                Endereco = form["endereco"],
                Telefone = form["telefone"],
                Email = form["email"]
            };
            return View ("Sucesso");
        }
    }
}