using Shopi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopi.Business
{
    public interface IReflectionSorter
    {
        List<T> Sorter<T>(List<T> stortedList, string sortBy);
    }
}
