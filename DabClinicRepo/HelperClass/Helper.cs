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

        public static T? GetDtgSelectedItemAttr<T>(object selectedItem, string attrName)
        {
            if (selectedItem == null)
            {
                return default(T);
            }

            T result = default(T);

            try
            {
                System.Type itemType = selectedItem.GetType();
                result = (T)itemType
                    .GetProperty(attrName)!
                    .GetValue(selectedItem, null)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetDtgSelectedItemAttr: " + ex.Message);
            }
            return result;

        }
    }
}
