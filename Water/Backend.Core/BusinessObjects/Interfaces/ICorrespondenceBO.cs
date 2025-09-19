using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.EntityObjects;

namespace Backend.Core.BusinessObjects.Interfaces
{
    public interface ICorrespondenceBO
    {
        void GenerateReceipt(ReceiptDataEO generateRecieptEO);

        void RaiseReceiptTask(ReceiptDataEO receiptDataEO);
    }
}
