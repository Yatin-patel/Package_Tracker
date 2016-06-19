using PackageComponents.Models;
using PackageDAL;
using System;

namespace PackageComponents
{
    public interface IReceiverService : IDisposable
    {
        Receiver RetrieveReceiver(int packageId);
        bool SaveReceiver(DeliverDTO dto);
    }
}