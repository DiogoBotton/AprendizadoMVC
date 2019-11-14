using System;
using McBonaldsMCV.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using McBonaldsMCV.Repositories;
using McBonaldsMCV.ViewModels;

namespace McBonaldsMCV.Controllers {
    public class PedidoController : Controller {
        PedidoRepository pedidoRepository = new PedidoRepository();
        HamburguerRepository hbgRepository = new HamburguerRepository();
        ShakeRepository shkRepository = new ShakeRepository();
        [HttpGet]
        public IActionResult Index () {
            PedidoViewModel pvm = new PedidoViewModel();
            pvm.Hamburgueres = hbgRepository.ObterTodos();
            pvm.Shakes = shkRepository.ObterTodos();
            return View (pvm); //Enviando ViewModel para a tela PEDIDO.
        }
        [HttpPost]
        public IActionResult Registrar (IFormCollection form) {
            ViewData["Action"] = "Pedido";
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
            pedido.cliente = cliente;
            pedido.DataDoPedido = DateTime.Now; //Now pega a data atual.

            if(pedidoRepository.Inserir(pedido)){
                return View ("Sucesso");
            }
            else{
                return View("Erro");
            }

            
        }
    }
}