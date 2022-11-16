using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Model
{
    public class Contact
    {
        public Guid InternalID { get; set; }
        public Guid Employee_InternalID { get; set; }
        public int PrimaryFlag { get; set; }
        public int Type { get; set; }
        public string Value { get; set; }
        //------------------ COMMON ATTRIBUTE ------------------//
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
