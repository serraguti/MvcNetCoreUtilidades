﻿using MvcNetCoreUtilidades.Models;

namespace MvcNetCoreUtilidades.Repositories
{
    public class RepositoryCoches
    {
        private List<Coche> Cars;

        public RepositoryCoches()
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

             , Modelo = "Mustang GT", Imagen = "https://cdn.autobild.es/sites/navi.axelspringer.es/public/styles/1200/public/media/image/2018/03/prueba-wolf-racing-mustang-gt.jpg"},
            new Coche
            {
                IdCoche = 5,
                Marca = "DMG"            ,
                Modelo = "Deloread",
                Imagen = "https://images.squarespace-cdn.com/content/v1/594eb9274c8b03ee09b041e9/1528551342886-RUWQG9WMW71X1Q0OH7RN/del1.png"
            }

             };
        }

        public List<Coche> GetCoches()
        {
            return this.Cars;
        }

        public Coche FindCoche(int idCoche)
        {
            return this.Cars.FirstOrDefault(x => x.IdCoche == idCoche);
        }
    }
}
