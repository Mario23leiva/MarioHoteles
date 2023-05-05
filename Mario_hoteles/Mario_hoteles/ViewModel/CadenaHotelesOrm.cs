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
    }
}
