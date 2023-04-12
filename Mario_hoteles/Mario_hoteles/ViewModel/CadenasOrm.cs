using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario_hoteles.ViewModel
{
    public static class CadenasOrm
    {
        public static string SelectByCif(string cif)
        {
            cadenas hoteles = Orm.entitites.cadenas.FirstOrDefault(t => t.cif == cif);


            return hoteles.nombre;
        }
    }
}
