using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Model
{
    public class Address
    {
        public Guid InternalID { get; set; }
        public Guid Employee_InternalID { get; set; }
        public int Type { get; set; }
        public string FirstLevel { get; set; }
        public string SecondLevel { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        //------------------ COMMON ATTRIBUTE ------------------//
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
