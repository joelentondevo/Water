using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.ActivityLayer.ActivityHandlers.Interfaces;
using Backend.Core.BusinessObjects;
using Backend.Core.BusinessObjects.Interfaces;

namespace Backend.ActivityLayer.ActitvityHandlers
{

    public class SecurityActivityHandler : ISecurityActivityHandler
    {
        ISecurityBO _securityBO;
        public SecurityActivityHandler(ISecurityBO securityBO)
        {
            _securityBO = securityBO;
        }
    }
}
