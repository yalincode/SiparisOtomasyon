using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.WinUI.Model
{
    public class KeyValue<Tvalue,TData> where Tvalue:struct where TData: class
    {
        public string Key { get; set; }
        public Nullable<Tvalue> Value { get; set; }
        public TData Data { get; set; }
    }
}
