using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageComponents.Models
{
    public class PackageDTO
    {
        public int Package_ID { get; set; }

        [Required(ErrorMessage = "Please select Karyakar.")]
        public int Department_Karyakar_ID { get; set; }

        [Required(ErrorMessage = "Please select Courier.")]
        public int Courier_ID { get; set; }

        public int Shipper_ID { get; set; }

        [Required(ErrorMessage = "Please scan Barcode.")]
        public string BarCode { get; set; }

        [Required(ErrorMessage = "Please specify received date.")]
        public Nullable<System.DateTime> Date_Received { get; set; }

        public byte[] Package_Image { get; set; }

        public string Image_Name { get; set; }
        public string Image_ContentType { get; set; }
        public string Comments { get; set; }
        public System.DateTime Create_Date { get; set; }
        public string Package_Received_By { get; set; }
        public string Shipper_Name { get; set; }
        public int Address_ID { get; set; }
        public string Address_Line1 { get; set; }
        public string Address_Line2 { get; set; }
        public string Address_Line3 { get; set; }
        public string City { get; set; }
        public int State_ID { get; set; }
        public string Zip_Code { get; set; }
        public int Country_ID { get; set; }
    }
}
