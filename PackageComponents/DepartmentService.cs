using AutoMapper;
using PackageDAL;
using PackageComponents.Interfaces;
using PackageComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageComponents
{
    public class DepartmentService : IReference
    {
        public DepartmentService()
        {
        }

        public bool Save<T>(T t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DepartmentDTO> Get<DepartmentDTO>()
        {
            using (var ctx = new PackageDAL.PackageTrackerDBEntities())
            {
                var result = ctx.Departments.ToList() as IEnumerable<Department>;
                Mapper.CreateMap(typeof(Department), typeof(DepartmentDTO));
                return Mapper.Map<IEnumerable<DepartmentDTO>>(result);
            }
        }

        public IEnumerable<Department_KaryakarDTO> GetKaryakars<Department_KaryakarDTO>()
        {
            using (var ctx = new PackageDAL.PackageTrackerDBEntities())
            {
                var result = ctx.Department_Karyakar.ToList() as IEnumerable<Department_Karyakar>;
                Mapper.CreateMap(typeof(Department_Karyakar), typeof(Department_KaryakarDTO));
                return Mapper.Map<IEnumerable<Department_KaryakarDTO>>(result);
            }
        }

        public bool Delete<T>(T t)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
