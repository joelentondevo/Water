using Backend.ActivityLayer.ActivityHandlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.Core.EntityObjects;

namespace Backend.ActivityLayer.ActivityHandlers
{
    public class CorrespondenceActivityHandler : ICorrespondenceActivityHandler
    {
        IBOFactory _bOFactory;
        ICorrespondenceBO _correspondenceBO;
        public CorrespondenceActivityHandler(IBOFactory bOFactory) 
        {
            _bOFactory = bOFactory;
            _correspondenceBO = _bOFactory.CreateCorrespondenceBO();
        }

        public void GenerateOrderReceipt(ReceiptDataEO receiptData)
        {
            _correspondenceBO.GenerateReceipt(receiptData);
        }

    }
}
