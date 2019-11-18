using System;
using McBonaldsMCV.Models;
using McBonaldsMCV.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace McBonaldsMCV.Controllers
{
    public class ClienteController : Controller
    {
        ClienteRepository clienteRepository = new ClienteRepository();
        [HttpGet]
        public IActionResult Index(){
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form){
            ViewData["Action"] = "Login";
            try{
            var usuario = form["email"];
            var senha = form["senha"];

            var cliente = clienteRepository.ObterPor(usuario);

            if (cliente.Senha.Equals(senha)){
                return View("Sucesso");
            }
            else{
                return View("Erro");
            }

                
            }catch(Exception e){
                System.Console.WriteLine(e.StackTrace);
                return View("Erro");
            }

        }
    }
}