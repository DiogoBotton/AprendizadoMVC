using System;
using McBonaldsMCV.Repositories;
using McBonaldsMCV.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using McBonaldsMCV.ViewModels;

namespace McBonaldsMCV.Controllers {
    public class CadastroController : AbstractController {
        ClienteRepository clienteRepository = new ClienteRepository();
        public IActionResult Index () {
            return View (new BaseViewModel(){
                NomeView = "Cadastro",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
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

                clienteRepository.Inserir(cliente);
                return View ("Sucesso", new RespostaViewModel("Você foi cadastrado com sucesso."));
            } catch (Exception e) {

                System.Console.WriteLine (e.StackTrace);
                return View ("Erro");
            }
        }
    }
}