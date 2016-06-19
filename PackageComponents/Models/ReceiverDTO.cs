using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageComponents.Models
{
    public class ReceiverDTO
    {
        public int Receiver_ID { get; set; }
        public int Package_ID { get; set; }
        public string Receiver_Name { get; set; }
        public string Receiver_Signature { get; set; }
        public string Comments { get; set; }
        public DateTime Date_Received { get; set; }
    }
}
