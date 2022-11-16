using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Model
{
    public class FilterSetting
    {
        public string FilterBy { get; set; }
        public string FilterValue { get; set; }
        public DateTime? FilterFromDate { get; set; }
        public DateTime? FilterToDate { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}
