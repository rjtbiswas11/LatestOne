using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderedNumbers
{
    public class SaveOrderedNumberRequest
    {
        public int[] ArrayToSort { get; set; }

        public string FileName { get; set; }
    }
}
