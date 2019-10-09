using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvcVistaWeb.DAOs;
using mvcVistaWeb.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace mvcVistaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscarUsuarioSinAjax(IFormCollection form)
        {

            // Creo vista a devolver
            ViewResult vista = View("Index");

            // Obtengo id traido del form
            var id = Convert.ToInt32(form["usuarioIdSinAjax"].ToString());

            // Busco usuario en DAO
            Usuario usuario = UsuarioDAO.getInstancia().getUsuarioById(id);
            vista.ViewData.Add("usuario", usuario);

            return vista;

        }
        
        [HttpPost]
        public JsonResult BuscarUsuarioConAjax([FromBody] JsonUsuario jsonUsuario)
        {

            // Busco usuario en DAO
            Usuario usuario = UsuarioDAO.getInstancia().getUsuarioById(jsonUsuario.id);

            var jsonResult = JsonConvert.SerializeObject(usuario);

            return Json(jsonResult);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public class JsonUsuario {
            public int id { get; set; }
        }
    
    }
}
