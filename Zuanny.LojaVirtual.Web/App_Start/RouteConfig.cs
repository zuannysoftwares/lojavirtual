using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Zuanny.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            // Rotas para URL amigável
            
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //1 - Traz tudo
            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Vitrine"
                    ,
                    action = "ListaProdutos"
                    ,
                    categoria = (string) null
                    ,
                    pagina = 1
                });
            
            // 2 - Mostra a pagina que estou
            routes.MapRoute(null,
            "Pagina{pagina}",
                new { controller = "Vitrine", 
                    action = "ListaProdutos", 
                    categoria = (string) null}, 
                    new { pagina = @"\d+" });
            
            // 3 - Busca as categorias
            routes.MapRoute(null, "{categoria}", new
            {
                controller = "Vitrine",
                action = "ListaProdutos",
                pagina = 1
            });

            // 4 - Mostra a categoria e a pagina
            routes.MapRoute(null,
                "{categoria}Pagina{pagina}",
                new { controller = "Vitrine",
                      action = "ListaProdutos"},
                      new { pagina = @"\d+" });

            // Default
            routes.MapRoute(null, "{controller}/{action}");


        }
    }
}
