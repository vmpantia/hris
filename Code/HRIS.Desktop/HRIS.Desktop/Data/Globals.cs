using HRIS.Desktop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HRIS.Desktop.Data
{
    public static class Globals
    {
        public static Regex emailRegex = new Regex(@"^$|^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        public static Regex numberRegex = new Regex(@"^[0-9]*$");
        public static Regex textRegex = new Regex(@"^[A-Za-z -]*$");

        public static ICommonController commonController;
        public static IHTTPController httpController;
    }
}
