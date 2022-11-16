using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Model
{
    public class Request
    {
        public string RequestID { get; set; }
        public string FunctionID { get; set; }
        public int RequestStatus { get; set; }
        public Guid? RequestBy { get; set; }
        public DateTime RequestDate { get; set; }
        public Guid? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
