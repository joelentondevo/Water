using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.EntityObjects
{
    public class ProductEntryEO
    {
        public ProductEntryEO() { }
        public ProductEntryEO(string name, int type)
        {
            Name = name;
            Type = type;
        }
        public string Name { get; set; }
        public int Type { get; set; }
    }
}
