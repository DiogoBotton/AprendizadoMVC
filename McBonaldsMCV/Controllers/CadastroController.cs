using System;
using McBonaldsMCV.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMCV.Controllers {
    public class CadastroController : Controller {
        public IActionResult Index () {
            return View ();
        }

        public IActionResult CadastrarCliente (IFormCollection form) {
            ViewData["Action"] = "Cadastro";
            try {
                Cliente cliente = new Cliente ();

                cliente.Nome = form["nome"];
                cliente.Endereco = form["endereco"];
                cliente.Telefone = form["telefone"];
                cliente.Senha = form["senha"];
                cliente.Email = form["email"];
                cliente.DataNascimento = DateTime.Parse (form["data-nascimento"]);
                return View ("Sucesso");
            } catch (Exception e) {

                System.Console.WriteLine (e.StackTrace);
                return View ("Erro");
            }
        }
    }
}