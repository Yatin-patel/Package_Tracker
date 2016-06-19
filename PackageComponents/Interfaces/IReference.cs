using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageComponents.Interfaces
{
    public interface IReference : IDisposable
    {
        bool Save<T>(T t);

        IEnumerable<T> Get<T>();

        bool Delete<T>(T t);

        T Get<T>(int id);
    }
}
