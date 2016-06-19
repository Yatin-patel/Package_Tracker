using PackageComponents.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageComponents
{
    public class AddressService : IReference
    {
        public bool Delete<T>(T t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get<T>()
        {
            throw new NotImplementedException();
        }

        public T Get<T>(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save<T>(T t)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
