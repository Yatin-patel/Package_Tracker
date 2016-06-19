using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageComponents.Models
{
    public class DeliverDTO
    {
        public int Karyakar_ID { get; set; }
        public int Package_ID { get; set; }
        public string Karyakar_Name { get; set; }
        public string Karyakar_Signature { get; set; }
        public string Comments { get; set; }
        public DateTime Delivery_Date { get; set; }
    }
}
