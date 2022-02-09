using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.Core.Utility
{
    public static class CoreHelper
    {
        public const string AppName = "Siparis Otomasyon";
        public const string AppVersion = "0.0.1";
        public static string AppNameVersion
        {
            get { return $"{AppName} V= {AppVersion}"; }
        }
    }
}
