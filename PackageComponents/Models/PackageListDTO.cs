using PackageDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageComponents.Models
{
    public class PackageListDTO
    {
        public int Package_ID { get; set; }
        public int Department_ID { get; set; }
        public int Courier_ID { get; set; }
        public int Shipper_ID { get; set; }
        public string BarCode { get; set; }
        public Nullable<System.DateTime> Date_Received { get; set; }
        public string Package_Received_By { get; set; }
        public byte[] Package_Image { get; set; }
        public string Image_Name { get; set; }
        public string Image_ContentType { get; set; }
        public string Comments { get; set; }
        public System.DateTime Create_Date { get; set; }

        public virtual Courier Courier { get; set; }
        public virtual Department_Karyakar Department_Karyakar { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual DeliverDTO Deliver { get; set; }
    }
}
