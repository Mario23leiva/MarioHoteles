using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario_hoteles.ViewModel
{
    public static class CiudadesOrm
    {
        public static List<ciudades> SelectCiudades()
        {
            return Orm.entitites.ciudades.ToList();
        }
    }
}
