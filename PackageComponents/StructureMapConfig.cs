using AutoMapper;
using PackageComponents.Models;
using PackageDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageComponents
{
    public class StructureMapConfig
    {

        public static MapperConfiguration Config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Department, DepartmentDTO>();
            });

            config.AssertConfigurationIsValid();
            return config;
        }
    }
}
