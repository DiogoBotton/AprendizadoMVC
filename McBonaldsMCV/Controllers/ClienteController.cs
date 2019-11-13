using System;
using McBonaldsMCV.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace McBonaldsMCV.Controllers
{
    public class ClienteController : Controller
    {
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
            return View("Sucesso");
                
            }catch(Exception e){
                System.Console.WriteLine(e.StackTrace);
                return View("Erro");
            }

        }
    }
}