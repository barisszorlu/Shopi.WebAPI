using Shopi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Shopi.Business
{
    public class ReflectionSorter : IReflectionSorter
    {
        public List<T> Sorter<T>(List<T> stortedList, string sortBy)
        {
            PropertyInfo prop = typeof(T).GetProperty(sortBy);
            if (prop != null)
                stortedList = stortedList.OrderBy(x => prop.GetValue(x, null)).ToList();

            return stortedList;
        }
    }
}
