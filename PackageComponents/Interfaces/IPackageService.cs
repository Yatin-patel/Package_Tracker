using PackageComponents.Models;
using PackageDAL;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PackageComponents
{
    public interface IPackageService : IDisposable
    {
        PackageDTO SavePackage(PackageDTO dto);
        Package RetrievePackage(int packageId);
        IEnumerable<PackageListDTO> GetPackageList();
    }
}