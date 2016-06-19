using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageComponents.Models
{
    public class DepartmentDTO
    {
        public int Department_ID { get; set; }
        public string Department_Name { get; set; }
        public string Department_Head { get; set; }
        public DateTime Create_Date { get; set; }
    }
}
