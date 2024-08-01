using MultipleSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleSolutions.Interfaces
{
    public interface IDuplicateFinder<T>
    {
        Dictionary<T, int> FindDuplicates(List<T> items);
    }
}
