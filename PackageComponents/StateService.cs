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
    public class StateService : IReference
    {
        static StateService()
        {
        }

        public bool Delete<T>(T t)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<StateDTO> Get<StateDTO>()
        {
            using (var ctx = new PackageDAL.PackageTrackerDBEntities())
            {
                var result = ctx.StateProvinces;
                Mapper.CreateMap<StateProvince, StateDTO>();
                return Mapper.Map<IEnumerable<StateDTO>>(ctx.StateProvinces);
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
    }
}
