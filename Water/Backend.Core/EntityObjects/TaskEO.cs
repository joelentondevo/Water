using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.EntityObjects
{
    public class TaskEO
    {
        public int Id { get; set; }
        public string Type {  get; set; }
        public string Name { get; set; }
        public string TaskData { get; set; }
        public int Priority { get; set; }

    }
}
