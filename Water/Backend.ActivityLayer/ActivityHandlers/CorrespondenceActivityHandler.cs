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
        ICorrespondenceBO _correspondenceBO;
        public CorrespondenceActivityHandler(ICorrespondenceBO correspondenceBO) 
        {
            _correspondenceBO = correspondenceBO;
        }

        public void GenerateOrderReceipt(ReceiptDataEO receiptData)
        {
            _correspondenceBO.GenerateReceipt(receiptData);
        }

    }
}
