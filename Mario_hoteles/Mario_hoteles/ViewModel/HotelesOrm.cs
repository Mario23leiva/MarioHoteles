using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario_hoteles.ViewModel
{
    public static class HotelesOrm
    {
        public static List<hoteles> SelectHoteles()
        {
            List<hoteles> _hoteles = (
                    from t in Orm.entitites.hoteles
                
                    select t
                ).ToList();

            return _hoteles;
        }

        public static void UpdateHotel(hoteles hotel, hoteles update)
        {
            // 1. Recuperar el hotel de la base de datos
            var hotelToUpdate = Orm.entitites.hoteles.FirstOrDefault(h => h.id_ciudad == hotel.id_ciudad && h.nombre == hotel.nombre);

            if (hotelToUpdate != null)
            {
                // 2. Modificar las propiedades del objeto hotel recuperado con los valores actualizados
                hotelToUpdate.nombre = hotel.nombre;
                hotelToUpdate.cadenas = hotel.cadenas;
                hotelToUpdate.ciudades = hotel.ciudades;
                hotelToUpdate.tipo = hotel.tipo;
                hotelToUpdate.telefono = hotel.telefono;
                hotelToUpdate.categoria = hotel.categoria;
                hotelToUpdate.direccion = hotel.direccion;

                // 3. Guardar los cambios en la base de datos
                Orm.MySaveChanges();
            }
        }



    }
}
