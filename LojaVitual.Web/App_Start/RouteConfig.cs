using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LojaVitual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Rota Inicial - Todos os produtos de todas as categorias
            routes.MapRoute(
                null,
                "",
                new { controller = "Vitrine", action = "ListaProdutos", categoria = (string)null, pagina = 1 });

            // Rota - Lista todos os produtos de todas as categorias filtrando por pagina
            routes.MapRoute(
            null,
            "Pagina/{pagina}",
            new { controller = "Vitrine", action = "ListaProdutos", categoria = (string)null },
            new { pagina = @"\d+" });

            // Rota - Lista todos os produtos por categoria
            routes.MapRoute(
                null,
                "{categoria}",
                new { controller = "Vitrine", action = "ListaProdutos", pagina = 1 }
                );

            // Rota - Lista produtos por categoria e página
            routes.MapRoute(
               null,
               "{categoria}/Pagina/{pagina}",
               new { controller = "Vitrine", action = "ListaProdutos" },
               new { pagina = @"\d+" }
               );

            // Rota Default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Vitrine", action = "ListaProdutos", id = UrlParameter.Optional }
            );
        }
    }
}
