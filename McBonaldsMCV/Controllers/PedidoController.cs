using System;
using McBonaldsMCV.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using McBonaldsMCV.Repositories;
using McBonaldsMCV.ViewModels;

namespace McBonaldsMCV.Controllers {
    public class PedidoController : AbstractController {
        ClienteRepository clienteRepository = new ClienteRepository();
        PedidoRepository pedidoRepository = new PedidoRepository();
        HamburguerRepository hbgRepository = new HamburguerRepository();
        ShakeRepository shkRepository = new ShakeRepository();
        [HttpGet]
        public IActionResult Index () {
            PedidoViewModel pvm = new PedidoViewModel();
            pvm.Hamburgueres = hbgRepository.ObterTodos();
            pvm.Shakes = shkRepository.ObterTodos();

            var emailCliente = ObterUsuarioSession();
            if(!string.IsNullOrEmpty(emailCliente)){
            var cliente = clienteRepository.ObterPor(emailCliente);
            pvm.Cliente = cliente;
            }

            var nomeCliente = ObterUsuarioNomeSession();
            if(!string.IsNullOrEmpty(nomeCliente)){
                pvm.NomeCliente = nomeCliente;
            }
            pvm.NomeView = "Pedido";
            pvm.UsuarioEmail = emailCliente;
            pvm.UsuarioNome = nomeCliente;

            return View (pvm); //Enviando ViewModel para a tela PEDIDO.
        }
        [HttpPost]
        public IActionResult Registrar (IFormCollection form) {
            ViewData["Action"] = "Pedido";
            Pedido pedido = new Pedido ();
            ////////////////////////////////////////////////////////
            Shake shake = new Shake ();
            string nomeShake = form["shake"];
            shake.Nome = nomeShake;
            shake.Preco = shkRepository.ObterPreco(nomeShake);

            pedido.shake = shake;
            ////////////////////////////////////////////////////////
            Hamburguer hamburguer = new Hamburguer ();
            string nomeHamburguer = form["hamburguer"];

            hamburguer.Nome = nomeHamburguer;
            hamburguer.Preco = hbgRepository.ObterPreco(nomeHamburguer);
            
            pedido.hamburguer = hamburguer;
            ///////////////////////////////////////////////////////
            Cliente cliente = new Cliente () {
                Nome = form["nome"],
                Endereco = form["endereco"],
                Telefone = form["telefone"],
                Email = form["email"]
            };
            pedido.cliente = cliente;

            pedido.PrecoTotal = hamburguer.Preco + shake.Preco;
            
            pedido.DataDoPedido = DateTime.Now; //Now pega a data atual.

            if(pedidoRepository.Inserir(pedido)){
                return View ("Sucesso", new RespostaViewModel("Pedido realizado com sucesso."){
                    NomeView = "Sucesso",
                    UsuarioNome = ObterUsuarioNomeSession(),
                    UsuarioEmail = ObterUsuarioSession()
                });
            }
            else{
                return View("Erro");
            }

            
        }
    }
}