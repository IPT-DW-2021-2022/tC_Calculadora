﻿using Calculadora.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace Calculadora.Controllers {
   public class HomeController : Controller {
      private readonly ILogger<HomeController> _logger;

      public HomeController(ILogger<HomeController> logger) {
         _logger = logger;
      }



      [HttpGet]  // esta anotação é facultativa
      public IActionResult Index() {

         // inicializar a calculadora
         ViewBag.Visor = "0";


         return View();
      }



      [HttpPost]  // mas, esta anotação já é obrigatória, para o método 'escutar' o HTTP POST
      public IActionResult Index(string botao, string visor) {

         int i = 0;


         switch (botao) {
            case "0":
            case "1":
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
               // atribuir ao VISOR o algarismo selecionado
               if (visor != "0") visor = visor + botao;
               else { visor = botao; }
               break;
            case ",":
               // transforma o num inteiro em real
               if (!visor.Contains(',')) visor += ",";
               break;
            case "+/-":
               //  inverte o valor do visor
               if (visor.StartsWith('-')) visor = visor.Substring(1);
               else visor = "-" + visor;
               // poderíamos executar esta mesma operação de forma algébrica
               break;
           


         }

         // preparar dados a serem enviados para a View
         ViewBag.Visor = visor;


         return View();
      }





      public IActionResult Privacy() {
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error() {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}