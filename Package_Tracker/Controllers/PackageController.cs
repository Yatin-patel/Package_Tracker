using PackageComponents;
using PackageComponents.Interfaces;
using PackageComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Baps.Rbv.Core;
using System.IO;

namespace Package_Tracker.Controllers
{
   // [Authorize]
    public class PackageController : Controller
    {
        // GET: Package
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Receive()
        {
            ViewBag.PageTitle = "Receive Shipment";
            ViewBag.StateCodes = null;
            PopulateDropdownsForReceivePackage();
            ViewBag.imagePath = "";
            ViewBag.HasImage = false;
            PackageDTO packageDTO = null;
            if (string.IsNullOrEmpty(Request.QueryString["BarCode"]))
            {
                packageDTO = new PackageDTO();
            }
            else
            {
                ViewBag.BarCode = Request.QueryString["BarCode"];
                using (PackageService service = new PackageService())
                {
                    packageDTO = service.RetrievePackageForBarCode(Request.QueryString["BarCode"]);
                    ViewBag.imagePath = (byte[])packageDTO.Package_Image;
                    if (packageDTO.Package_Image.Length > 0)
                        ViewBag.HasImage = true;
                }
            }

            return View(packageDTO);
        }

        [HttpPost]
        public ActionResult Receive(PackageDTO package, HttpPostedFileBase upload)
        {
            PopulateDropdownsForReceivePackage();
            PopulateDropdownsForDeliverPackage();
            ViewBag.HasImage = true;

            ViewBag.imagePath = upload.FileName;

            if (ViewBag.imagePath.Length > 0)
                ViewBag.HasImage = true;

            if (ModelState.IsValid == false) return View(package);

            if (upload != null && upload.ContentLength > 0)
            {
                package.Image_Name = upload.FileName;
                package.Image_ContentType = upload.ContentType;
            }

            using (var reader = new BinaryReader(upload.InputStream))
            {
                package.Package_Image = reader.ReadBytes(upload.ContentLength);
            }

            using (PackageService service = new PackageService())
            {
                service.SavePackage(package);
            }
            return RedirectToAction("PackageList");
        }

        public ActionResult Deliver()
        {
            if (String.IsNullOrEmpty(Request.QueryString["BarCode"]))
                return RedirectToAction("PackageList");

            ViewBag.PageTitle = "Deliver package";

            PopulateDropdownsForDeliverPackage();

            DeliverDTO dto = new DeliverDTO();

            using (PackageService service = new PackageService())
            {
                var packageDTO = service.RetrievePackageForBarCode(Request.QueryString["BarCode"].Trim());
                dto.Package_ID = packageDTO.Package_ID;
            }

            dto.Delivery_Date = DateTime.Now.Date;
            return View(dto);
        }

        [HttpPost]
        public ActionResult Deliver(DeliverDTO package, HttpPostedFileBase upload)
        {
            PopulateDropdownsForDeliverPackage();
            if (ModelState.IsValid == false) return View(package);
            using (PackageService service = new PackageService())
            {
                service.SaveDeliver(package);
            }
            return RedirectToAction("PackageList");
        }

        public ActionResult PackageList()
        {
            IEnumerable<PackageListDTO> packages = null;

            using (PackageService service = new PackageService())
            {
                packages = service.GetPackageList();
                return View(packages);
            }
        }

        private void PopulateDropdownsForReceivePackage()
        {
            var stateService = Factory.Get<StateService>();
            ViewBag.StateCodes = new SelectList(stateService.Get<StateDTO>(), "Id", "Name");

            var countryService = Factory.Get<CountryService>();
            ViewBag.Countries = new SelectList(countryService.Get<CountryDTO>(), "Country_ID", "Name");

            var courierService = Factory.Get<CourierService>();
            ViewBag.Courier_ID = (IEnumerable<SelectListItem>)new SelectList(courierService.Get<CourierDTO>(), "Courier_ID", "Courier_Name");

            // var departmentService = Factory.Get<DepartmentService>();
            // ViewBag.Department_ID = (IEnumerable<SelectListItem>)new SelectList(departmentService.Get<DepartmentDTO>(), "Department_ID", "Department_Name");
            var karyakarService = Factory.Get<DepartmentService>();
            ViewBag.Department_Karyakar_ID = (IEnumerable<SelectListItem>)new SelectList(karyakarService.GetKaryakars<Department_KaryakarDTO>(), "Department_Karyakar_ID", "Karyakar_Name");
        }

        private void PopulateDropdownsForDeliverPackage()
        {
            var departmentService = Factory.Get<DepartmentService>();
            ViewBag.Karyakars = (IEnumerable<SelectListItem>)new SelectList(departmentService.GetKaryakars<Department_KaryakarDTO>(), "Department_Karyakar_ID", "Karyakar_Name");
        }
    }
}