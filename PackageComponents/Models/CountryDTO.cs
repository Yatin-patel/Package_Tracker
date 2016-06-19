using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageComponents.Models
{
    public class CountryDTO
    {
        public int Country_ID { get; set; }
        public string CountryCode { get; set; }
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string AddressFormat { get; set; }
    }
}
