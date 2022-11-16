using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Desktop.Data
{
    public class Constants
    {
        public const string viewDashboardForm = "DashboardForm";
        public const string viewEmployeeForm = "EmployeeForm";

        public const string REQUIRED_FIELD_MSG = "✖ This field is required.";
        public const string INVALID_EMAIL_MSG = "✖ This field require a valid Email Address only.";
        public const string INVALID_NUMBER_MSG = "✖ This field require a Number only.";
        public const string INVALID_TEXT_MSG = "✖ This field require a Letter only.";
        public const string INVALID_LIMIT_MSG = "✖ The length of inputted value is exceeds on {0}.";
        public const string VALID_DATA_MSG = "✔ Valid Data.";

        #region User Controls
        public const string UC_CustomTextBox = "CustomTextBox";
        public const string UC_CustomDatePicker = "CustomDatePicker";
        public const string UC_CustomComboBox = "CustomComboBox";
        #endregion

        #region APIs
        public const string EmployeeAPI = "https://localhost:44395/";
        #endregion

        #region API Requests
        public const string PostSaveEmployee = "PostSaveEmployee";
        #endregion

        #region Request Methods
        public const string POST = "POST";
        #endregion

        #region Request Content Type
        public const string ContentType = "application/json";
        #endregion

        #region Form Text

        public const string FormText_NewEmployee = "New Employee Record";
        public const string FormText_ExistingEmployee = "{0} - Employee Record";
        #endregion

    }
}
