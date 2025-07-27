using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.DatabaseObjects;

namespace Backend.Core.BusinessObjects
{ 
    public class LibraryBO : ILibraryBO
    {
        private readonly IDOFactory _dOFactory;
        private readonly ILibraryDO _libraryDO;

        public LibraryBO(IDOFactory dOFactory)
        {
            _dOFactory = dOFactory;
            _libraryDO = _dOFactory.CreateLibraryDO();
        }
    }
}
