using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.EntityObjects
{
    public class AddProductToLibraryEO
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public string ProductKey { get; set; }

        public AddProductToLibraryEO(int userID, int ProductID, string ProductKey)
        {
            this.UserID = userID;
            this.ProductID = ProductID;
            this.ProductKey = ProductKey;
        }
    }
}
