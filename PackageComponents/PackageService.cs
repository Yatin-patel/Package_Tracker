using AutoMapper;
using PackageComponents.Models;
using PackageDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://www.mikesdotnetting.com/article/259/asp-net-mvc-5-with-ef-6-working-with-files

namespace PackageComponents
{
    public class PackageService : IPackageService
    {
        public PackageDTO SavePackage(PackageDTO dto)
        {
            using (var p = new PackageTrackerDBEntities())
            {
                Address address = p.Addresses.Where(a => a.Address_ID == dto.Address_ID).SingleOrDefault();

                if (address == null)
                    address = new Address();

                address.Address_Line1 = dto.Address_Line1;
                address.Address_Line2 = dto.Address_Line2;
                address.Address_Line3 = dto.Address_Line3;
                address.City = dto.City;
                address.State_ID = dto.State_ID;
                address.Zip_Code = dto.Zip_Code;
                address.Country_ID = dto.Country_ID;

                Shipper shipper = p.Shippers.Where(s => s.Shipper_ID == dto.Shipper_ID).SingleOrDefault();
                if (shipper == null)
                    shipper = new Shipper();

                shipper.Shipper_Name = dto.Shipper_Name;
                shipper.Shipping_Company = dto.Shipper_Name;

                Package package = p.Packages.Where(pkg => pkg.Package_ID == dto.Package_ID).SingleOrDefault();
                if (package == null)
                    package = new Package();

                package.BarCode = dto.BarCode;
                package.Comments = dto.Comments;
                package.Courier_ID = dto.Courier_ID;
                package.Create_Date = DateTime.Now;
                package.Date_Received = dto.Date_Received;
                package.Department_Karyakar_ID = dto.Department_Karyakar_ID;
                package.Package_Received_By = string.Empty;
                package.Image_Name = dto.Image_Name;
                package.Image_ContentType = dto.Image_ContentType;
                package.Package_Image = dto.Package_Image;
                package.Shipper = shipper;

                using (var dbTrans = p.Database.BeginTransaction())
                {
                    try
                    {
                        p.Addresses.Add(address);
                        //p.SaveChanges();

                        int addressID = address.Address_ID;
                        shipper.Address_ID = addressID;

                        //p.Shippers.Add(shipper);
                        //p.SaveChanges();

                        //int shipperID = shipper.Shipper_ID;
                        //package.Shipper_ID = shipperID;
                        package.Shipper = shipper;
                        p.Packages.Add(package);
                        
                        p.SaveChanges();
                        dbTrans.Commit();

                        dto.Address_ID = addressID;
                        dto.Shipper_ID = package.Shipper.Shipper_ID;
                        dto.Package_ID = package.Package_ID;
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        throw ex;
                    }
                }
            }
            return dto;
        }

        public DeliverDTO SaveDeliver(DeliverDTO dto)
        {
            using (var p = new PackageTrackerDBEntities())
            {
                var karyakar = p.Department_Karyakar.Where(k => k.Department_Karyakar_ID == dto.Karyakar_ID).SingleOrDefault();
                string name = karyakar.Karyakar_Name;
                Deliver deliver = new Deliver
                {
                    Delivery_Date = dto.Delivery_Date,
                    Comments = dto.Comments,
                    Karyakar_ID = dto.Karyakar_ID,
                    Karyakar_Name = name,
                    Department_Karyakar = karyakar,
                    Package = p.Packages.Where(p1 => p1.Package_ID == dto.Package_ID).FirstOrDefault(),
                    Karyakar_Signature = dto.Karyakar_Signature,
                    Package_ID = dto.Package_ID
                };
                p.Delivers.Add(deliver);
                p.SaveChanges();
            }
            return dto;
        }

        public Package RetrievePackage(int packageId)
        {
            try {
                var p = new PackageTrackerDBEntities();
                var result = (from pkg in p.Packages
                              where pkg.Package_ID == packageId
                              select pkg).FirstOrDefault();
                return result ?? new Package();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public PackageDTO RetrievePackageForBarCode(string barCode)
        {
            try
            {
                var p = new PackageTrackerDBEntities();
                var result = (from pkg in p.Packages
                              where pkg.BarCode == barCode
                              select pkg).FirstOrDefault();

                //Mapper.CreateMap(typeof(Package), typeof(PackageDTO))
                //    .ForMember("Shipper_Name", src => src.Shipper.Shipper_Name);

                Mapper.CreateMap<Package, PackageDTO>()
                    .ForMember(dest => dest.Shipper_Name, opt => opt.MapFrom(src => src.Shipper.Shipper_Name))
                    .ForMember(dest => dest.Address_Line1, opt => opt.MapFrom(src => src.Shipper.Address.Address_Line1))
                    .ForMember(dest => dest.Address_Line2, opt => opt.MapFrom(src => src.Shipper.Address.Address_Line2))
                    .ForMember(dest => dest.Address_Line3, opt => opt.MapFrom(src => src.Shipper.Address.Address_Line3))
                    .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Shipper.Address.City))
                    .ForMember(dest => dest.State_ID, opt => opt.MapFrom(src => src.Shipper.Address.State_ID))
                    .ForMember(dest => dest.Zip_Code, opt => opt.MapFrom(src => src.Shipper.Address.Zip_Code))
                    .ForMember(dest => dest.Country_ID, opt => opt.MapFrom(src => src.Shipper.Address.Country_ID));
                return Mapper.Map<PackageDTO>(result ?? new Package());
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<PackageListDTO> GetPackageList()
        {
            IEnumerable<PackageListDTO> packages = null;
            try
            {
                using (var ctx = new PackageDAL.PackageTrackerDBEntities())
                {
                    IEnumerable<Package> result = ctx.Packages.Where(p => p.Delivers.Count() == 0).OrderByDescending(p => p.Create_Date).ThenByDescending(p => p.Date_Received).ToList();
                    //Mapper.CreateMap<Package, PackageListDTO>();
                    Mapper.CreateMap(typeof(Package), typeof(PackageListDTO));
                    return Mapper.Map<IEnumerable<PackageListDTO>>(result);
                }
            }
            catch (Exception e)
            {
                return new List<PackageListDTO>();
            }
        }
    }
}
