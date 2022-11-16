using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Model
{
    public class Constant
    {
        //Symbols
        public const string CommaSeparator = ", ";
        public const string WhiteSpace = " ";

        public const string Status_0 = "Active";
        public const string Status_1 = "In-active";
        public const string Status_2 = "For Deletion";




        #region Error Messages
        public const string ERR_MSG_RequiredField = "This field is required.";
        #endregion

        #region Display Names
        public const string DN_EmployeeID = "Employee ID";
        public const string DN_FirstName = "First Name";
        public const string DN_LastName = "Last Name";
        public const string DN_MiddleName = "Middle Name";
        public const string DN_Suffix = "Suffix";
        public const string DN_Gender = "Gender";
        public const string DN_Birthdate = "Birthdate";
        public const string DN_PlaceOfBirth = "Place of Birth";
        public const string DN_Nationality = "Nationality";
        public const string DN_Religion = "Religion";
        public const string DN_CivilStatus = "Civil Status";
        public const string DN_ContactNo = "Contact No.";
        #endregion
    }
}
