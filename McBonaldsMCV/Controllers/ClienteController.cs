using System;
using McBonaldsMCV.Enums;
using McBonaldsMCV.Models;
using McBonaldsMCV.Repositories;
using McBonaldsMCV.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMCV.Controllers {
    public class ClienteController : AbstractController {
        ClienteRepository clienteRepository = new ClienteRepository ();
        PedidoRepository pedidoRepository = new PedidoRepository ();
        [HttpGet]
        public IActionResult Index () {
            return View (new BaseViewModel () {
                NomeView = "Login",
                    UsuarioEmail = ObterUsuarioSession (),
                    UsuarioNome = ObterUsuarioNomeSession ()
            });
        }

        [HttpPost]
        public IActionResult Index (IFormCollection form) {
            ViewData["Action"] = "Login";
            try {
                var usuario = form["email"];
                var senha = form["senha"];

                var cliente = clienteRepository.ObterPor (usuario);

                if (cliente != null) {
                    if (cliente.Senha.Equals (senha)) {
                        switch (cliente.TipoUsuario) {
                            case (uint) TiposUsuarioEnum.ADMINISTRADOR:
                                HttpContext.Session.SetString (SESSION_CLIENTE_EMAIL, usuario); //Funciona como um dicionário, para não perder algum tipo de dado ao ser redirecionado para outro método (na mesma classe).
                                HttpContext.Session.SetString (SESSION_CLIENTE_NOME, cliente.Nome);
                                HttpContext.Session.SetString (SESSION_CLIENTE_TIPO, cliente.TipoUsuario.ToString());
                                 //Redireciona para outra action (método) da mesma classe.
                                return RedirectToAction ("Dashboard","Administrador");
                            default:
                                HttpContext.Session.SetString (SESSION_CLIENTE_EMAIL, usuario);
                                HttpContext.Session.SetString (SESSION_CLIENTE_NOME, cliente.Nome);
                                HttpContext.Session.SetString (SESSION_CLIENTE_TIPO, cliente.TipoUsuario.ToString());
                                return RedirectToAction ("Historico", "Cliente");
                        }
                    } else {
                        return View ("Erro", new RespostaViewModel ("Senha incorreta."));
                    }
                } else {
                    return View ("Erro", new RespostaViewModel ($"Esta conta não existe. Usuário {usuario} não encontrado."));
                }

            } catch (Exception e) {
                System.Console.WriteLine (e.StackTrace);
                return View ("Erro");
            }
        }
        public IActionResult Historico () {
            var emailCliente = HttpContext.Session.GetString (SESSION_CLIENTE_EMAIL);
            var pedidosCliente = pedidoRepository.ObterTodosPorCliente (emailCliente);

            return View (new HistoricoViewModel () {
                Pedidos = pedidosCliente,
                    NomeView = "Historico",
                    UsuarioEmail = emailCliente,
                    UsuarioNome = ObterUsuarioNomeSession ()
            });
        }
        public IActionResult Logoff () {
            HttpContext.Session.Remove (SESSION_CLIENTE_EMAIL);
            HttpContext.Session.Remove (SESSION_CLIENTE_NOME);
            HttpContext.Session.Clear ();
            return RedirectToAction ("Index", "Home");
        }
    }
}