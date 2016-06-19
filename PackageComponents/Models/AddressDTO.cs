using PackageDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageComponents.Models
{
    public class AddressDTO
    {
        public int Address_ID { get; set; }
        public string Address_Line1 { get; set; }
        public string Address_Line2 { get; set; }
        public string Address_Line3 { get; set; }
        public string City { get; set; }
        public Nullable<int> State_ID { get; set; }
        public Nullable<int> Country_ID { get; set; }
        public string Zip_Code { get; set; }
        public Nullable<System.DateTime> Create_Date { get; set; }

        public virtual Country Country { get; set; }
        public virtual StateProvince StateProvince { get; set; }
        public virtual ICollection<Shipper> Shippers { get; set; }
    }
}
