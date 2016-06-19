using PackageDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageComponents.Models
{
    public class ShipperDTO
    {
        public int Shipper_ID { get; set; }
        public int Address_ID { get; set; }
        public string Shipping_Company { get; set; }
        public string Shipper_Name { get; set; }
        public Nullable<System.DateTime> Create_Date { get; set; }

        public virtual Address Address { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Package> Packages { get; set; }
    }
}
