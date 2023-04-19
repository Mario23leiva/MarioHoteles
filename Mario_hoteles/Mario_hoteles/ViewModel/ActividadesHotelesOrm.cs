using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario_hoteles.ViewModel
{
    public static class ActividadesHotelesOrm
    {
        public static List<String> SelectAct_Hotel(hoteles hotel)
        {
            List<String> _act_hotel = Orm.entitites.act_hotel
                .Where(c => c.id_ciudad == hotel.id_ciudad && c.nombre == hotel.nombre)
                .Select(c => c.actividades.descripcion)
                .ToList();

            return _act_hotel;
        }
        
        public static List<actividades> SelectActividades()
        {
            List<actividades> _act_hotel = Orm.entitites.actividades
                .ToList();

            return _act_hotel;
        }

        public static int SelectGradoDificultad(actividades actividades)
        {
            int grado = Orm.entitites.act_hotel
                .Where(c => c.id_act == actividades.id_act)
                .Select(c => c.grado)
                .FirstOrDefault();

            return grado;
        }


    }
}
