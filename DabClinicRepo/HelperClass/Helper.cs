using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabClinicRepo.HelperClass
{
    public static class Helper
    {
        public static Func<T, bool> CombineFilters<T>(List< Func<T, bool>> filters)
        {
            return x => filters.All(filter => filter(x));
        }
    }
}
