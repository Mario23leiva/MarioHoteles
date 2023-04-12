using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario_hoteles.ViewModel
{
    public static class HotelesOrm
    {
        public static List<hoteles> SelectByMale()
        {
            List<hoteles> _hoteles = (
                    from t in Orm.entitites.hoteles
                
                    select t
                ).ToList();

            return _hoteles;
        }

    }
}
