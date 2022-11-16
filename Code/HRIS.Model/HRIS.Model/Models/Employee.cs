using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Model
{
    public class Employee : Request
    {
        public Guid InternalID { get; set; }

        [DisplayName(Constant.DN_EmployeeID)]
        public string EmployeeID { get; set; }

        [DisplayName(Constant.DN_FirstName)]
        [Required(ErrorMessage = Constant.ERR_MSG_RequiredField)]
        public string FirstName { get; set; }

        [DisplayName(Constant.DN_LastName)]
        [Required(ErrorMessage = Constant.ERR_MSG_RequiredField)]
        public string LastName { get; set; }

        [DisplayName(Constant.DN_MiddleName)]
        public string MiddleName { get; set; }

        [DisplayName(Constant.DN_Suffix)]
        public string Suffix { get; set; }

        [DisplayName(Constant.DN_Gender)]
        [Required(ErrorMessage = Constant.ERR_MSG_RequiredField)]
        public Gender Gender { get; set; }

        [DisplayName(Constant.DN_Birthdate)]
        [Required(ErrorMessage = Constant.ERR_MSG_RequiredField)]
        public DateTime Birthdate { get; set; }

        [DisplayName(Constant.DN_PlaceOfBirth)]
        [Required(ErrorMessage = Constant.ERR_MSG_RequiredField)]
        public string PlaceOfBirth { get; set; }

        [DisplayName(Constant.DN_Nationality)]
        [Required(ErrorMessage = Constant.ERR_MSG_RequiredField)]
        public string Nationality { get; set; }

        [DisplayName(Constant.DN_Religion)]
        [Required(ErrorMessage = Constant.ERR_MSG_RequiredField)]
        public string Religion { get; set; }

        [DisplayName(Constant.DN_CivilStatus)]
        [Required(ErrorMessage = Constant.ERR_MSG_RequiredField)]
        public CivilStatus CivilStatus { get; set; }

        [DisplayName(Constant.DN_FirstName)]
        [Required(ErrorMessage = Constant.ERR_MSG_RequiredField)]
        public string M_FirstName { get; set; }

        [DisplayName(Constant.DN_LastName)]
        [Required(ErrorMessage = Constant.ERR_MSG_RequiredField)]
        public string M_LastName { get; set; }

        [DisplayName(Constant.DN_MiddleName)]
        public string M_MiddleName { get; set; }

        [DisplayName(Constant.DN_Suffix)]
        public string M_Suffix { get; set; }

        [DisplayName(Constant.DN_Birthdate)]
        [Required(ErrorMessage = Constant.ERR_MSG_RequiredField)]
        public DateTime M_BirthDate { get; set; }

        [DisplayName(Constant.DN_ContactNo)]
        public string M_ContactNo { get; set; }

        [DisplayName(Constant.DN_FirstName)]
        [Required(ErrorMessage = Constant.ERR_MSG_RequiredField)]
        public string F_FirstName { get; set; }

        [DisplayName(Constant.DN_LastName)]
        [Required(ErrorMessage = Constant.ERR_MSG_RequiredField)]
        public string F_LastName { get; set; }

        [DisplayName(Constant.DN_MiddleName)]
        public string F_MiddleName { get; set; }

        [DisplayName(Constant.DN_Suffix)]
        public string F_Suffix { get; set; }

        [DisplayName(Constant.DN_Birthdate)]
        [Required(ErrorMessage = Constant.ERR_MSG_RequiredField)]
        public DateTime F_BirthDate { get; set; }

        [DisplayName(Constant.DN_ContactNo)]
        public string F_ContactNo { get; set; }

        public List<Contact> ContactList { get; set; }
        public List<Address> AddressList { get; set; }
        //------------------ COMMON ATTRIBUTE ------------------//
        public int Status { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string Name
        {
            get
            {
                var middleInitial = string.IsNullOrEmpty(MiddleName) ? string.Empty : MiddleName.Substring(0, 1);
                return string.Concat(LastName,
                                     Constant.CommaSeparator,
                                     FirstName,
                                     Constant.WhiteSpace,
                                     middleInitial);
            }
        }

        public string StatusValue
        {
            get
            {
                switch(Status)
                {
                    case 1:
                        return Constant.Status_1;
                    case 2:
                        return Constant.Status_2;
                    default:
                        return Constant.Status_0;
                }
            }
        }
    }
}
