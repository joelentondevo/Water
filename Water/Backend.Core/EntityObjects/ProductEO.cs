using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.EntityObjects
{
    internal class ProductEO
    {
        public ProductEO(int id, string name, int type)
        {
            Id = id;
            Name = name;
            Type = type;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
    }
}
