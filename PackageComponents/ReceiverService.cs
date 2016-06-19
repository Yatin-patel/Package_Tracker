using PackageComponents.Models;
using PackageDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageComponents
{
    public class ReceiverService : IReceiverService
    {
        public bool SaveReceiver(DeliverDTO dto)
        {
            throw new NotImplementedException();
        }

        public Receiver RetrieveReceiver(int packageId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
