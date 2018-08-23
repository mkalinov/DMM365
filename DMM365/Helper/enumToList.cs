using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMM365.Helper
{
    public class enumToList
    {
        public static IEnumerable<KeyValuePair<int, string>> Of<T>(bool isFirstEmpty = false)
        {
            List<KeyValuePair<int, string>> r = Of<T>().ToList();
            if (isFirstEmpty) r.Insert(0, new KeyValuePair<int, string>(-1, ""));
            return r;
        }


        private static IEnumerable<KeyValuePair<int, string>> Of<T>()
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(p => new KeyValuePair<int, string>(Convert.ToInt32(p), p.ToString()))
                .ToList();
        }

    }
}
