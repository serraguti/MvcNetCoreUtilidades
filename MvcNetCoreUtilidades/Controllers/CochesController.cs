﻿using Microsoft.AspNetCore.Mvc;
using MvcNetCoreUtilidades.Models;

namespace MvcNetCoreUtilidades.Controllers
{
    public class CochesController : Controller
    {
        private List<Coche> Cars;

        public CochesController()
        {
            this.Cars = new List<Coche>
            {

              new Coche { IdCoche = 1, Marca = "Pontiac"

             , Modelo = "Firebird", Imagen = "https://espirituracer.com/archivos/2018/03/Pontiac-Firebird-KITT.jpg"},

              new Coche { IdCoche = 2, Marca = "Volkswagen"

             , Modelo = "Escarabajo", Imagen = "https://www.quadis.es/documents/80345/95274/herbie-el-volkswagen-beetle-mas.jpg"},

              new Coche { IdCoche = 3, Marca = "Ferrari"

             , Modelo = "Testarrosa", Imagen = "https://www.lavanguardia.com/files/article_main_microformat/uploads/2017/01/03/5f15f8b7c1229.png"},

              new Coche { IdCoche = 4, Marca = "Ford"

             , Modelo = "Mustang GT", Imagen = "https://cdn.autobild.es/sites/navi.axelspringer.es/public/styles/1200/public/media/image/2018/03/prueba-wolf-racing-mustang-gt.jpg"}

             };
        }

        //ESTA ES LA VISTA QUE VAMOS A VISUALIZAR COMO PRINCIPAL
        public IActionResult Index()
        {
            return View();
        }

        //TENDREMOS UN IACTIONRESULT PARA INTEGRAR DENTRO DE OTRA 
        //VISTA, EN NUESTRO EJEMPLO, DENTRO DE INDEX
        public IActionResult _CochesPartial()
        {
            //SI SON VISTAS PARCIALES CON AJAX, DEBEMOS 
            //DEVOLVER PartialView
            //EN EL MOMENTO DE DEVOLVER, INDICAMOS A QUE VISUALIZACION
            //TIENE QUE HACERLO
            return PartialView("_CochesPartial", this.Cars);
        }

        public IActionResult _CochesPost(int idcoche)
        {
            Coche car =
                this.Cars.FirstOrDefault(x => x.IdCoche == idcoche);
            return PartialView("_DetailsCoche", car);
        }
    }
}
