using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using mvcVistaWeb.DAOs;
using mvcVistaWeb.Models;

namespace mvcVistaWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // Mi build
            MiPropioMain();

            // Web Build
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void MiPropioMain()
        {

            UsuarioDAO.getInstancia()
                .add(new Usuario(1, "pepito@gmail.com", "calle falsa 123", 170))
                .add(new Usuario(2, "juan_hernesto@yahoo.com", "azcuenaga 78", 0))
                .add(new Usuario(3, "admin@admin.com", "admin", 9999));

        }

    }
}
