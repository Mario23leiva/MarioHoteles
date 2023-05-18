using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario_hoteles.ViewModel
{
    public static class CadenaHotelesOrm
    {
        public static List<cadenas> SelectCadenaHoteles()
        {
            return Orm.entitites.cadenas.ToList();
        }

        public static string AddCadena(cadenas cadena)
        {
            // 1. Agregar el nuevo objeto hotel al contexto de la base de datos
            Orm.entitites.cadenas.Add(cadena);

            // 2. Guardar los cambios en la base de datos
            return Orm.MySaveChanges();
        }


        public static string UpdateCadena(cadenas cadena, cadenas update)
        {
            // 1. Recuperar el hotel de la base de datos
            var cadenaToUpdate = Orm.entitites.cadenas.FirstOrDefault(h => h.cif == cadena.cif);

            if (cadenaToUpdate != null)
            {
                // 2. Modificar las propiedades del objeto hotel recuperado con los valores actualizados
                cadenaToUpdate.cif = update.cif;
                cadenaToUpdate.dir_fis = update.dir_fis;
                cadenaToUpdate.nombre = update.nombre;
                

                // 3. Guardar los cambios en la base de datos
                
            }
            return Orm.MySaveChanges();
        }

        public static string DeleteCadena(cadenas cadena)
        {
            // 1. Recuperar el hotel de la base de datos
            var cadenaToDelete = Orm.entitites.cadenas.FirstOrDefault(h => h.cif == cadena.cif);

            if (cadenaToDelete != null)
            {
                // 2. Eliminar el objeto hotel recuperado de la base de datos
                Orm.entitites.cadenas.Remove(cadenaToDelete);

                // 3. Guardar los cambios en la base de datos
                
            }
            return Orm.MySaveChanges();
        }
    }
}
