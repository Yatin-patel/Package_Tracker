using AutoMapper;
using PackageComponents.Interfaces;
using PackageComponents.Models;
using PackageDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageComponents
{
    public class CountryService : IReference
    {
        public bool Delete<T>(T t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CountryDTO> Get<CountryDTO>()
        {
            using (var ctx = new PackageDAL.PackageTrackerDBEntities())
            {
                Mapper.CreateMap<Country, CountryDTO>();
                return Mapper.Map<IEnumerable<CountryDTO>>(ctx.Countries);
            }
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
