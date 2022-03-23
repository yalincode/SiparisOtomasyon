using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.VM
{
    public class OrderVM
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string personalName { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CargoName { get; set; }
        public string ShipName   { get; set; }
    }
}
