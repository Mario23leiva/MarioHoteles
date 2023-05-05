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
            return Orm.entitites.hoteles.ToList();
        }

        public static void AddHotel(hoteles hotel)
        {
            // 1. Agregar el nuevo objeto hotel al contexto de la base de datos
            Orm.entitites.hoteles.Add(hotel);

            // 2. Guardar los cambios en la base de datos
            Orm.MySaveChanges();
        }


        public static void UpdateHotel(hoteles hotel, hoteles update)
        {
            // 1. Recuperar el hotel de la base de datos
            var hotelToUpdate = Orm.entitites.hoteles.FirstOrDefault(h => h.id_ciudad == hotel.id_ciudad && h.nombre == hotel.nombre);

            if (hotelToUpdate != null)
            {
                // 2. Modificar las propiedades del objeto hotel recuperado con los valores actualizados
                hotelToUpdate.tipo = update.tipo;
                hotelToUpdate.telefono = update.telefono;
                hotelToUpdate.categoria = update.categoria;
                hotelToUpdate.direccion = update.direccion;

                // 3. Guardar los cambios en la base de datos
                Orm.MySaveChanges();
            }
        }

        public static void DeleteHotel(hoteles hotel)
        {
            // 1. Recuperar el hotel de la base de datos
            var hotelToDelete = Orm.entitites.hoteles.FirstOrDefault(h => h.id_ciudad == hotel.id_ciudad && h.nombre == hotel.nombre);

            if (hotelToDelete != null)
            {
                // 2. Eliminar el objeto hotel recuperado de la base de datos
                Orm.entitites.hoteles.Remove(hotelToDelete);

                // 3. Guardar los cambios en la base de datos
                Orm.MySaveChanges();
            }
        }




    }
}
