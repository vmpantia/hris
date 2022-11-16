using HRIS.Desktop.Data;
using HRIS.Desktop.UserControls;
using System;

namespace HRIS.Desktop.Controllers
{
    public class CommonController : ICommonController
    {
        public void ResetField(params object[] inputFields)
        {
            foreach (var inputField in inputFields)
            {
                var inputType = inputField.GetType();
                switch (inputType.BaseType.Name)
                {
                    case Constants.UC_CustomTextBox:
                        {
                            ((CustomTextBox)inputField).TextValue = string.Empty;
                            break;
                        }
                    case Constants.UC_CustomDatePicker:
                        {
                            ((CustomDatePicker)inputField).TextValue = DateTime.Now;
                            break;
                        }
                    case Constants.UC_CustomComboBox:
                        {
                            ((CustomComboBox)inputField).TextValue = string.Empty;
                            break;
                        }
                }
            }
        }

        public void TrimField(params object[] inputFields)
        {
            foreach (var inputField in inputFields)
            {
                var inputType = inputField.GetType();
                switch (inputType.BaseType.Name)
                {
                    case Constants.UC_CustomTextBox:
                        {
                            ((CustomTextBox)inputField).TextValue = ((CustomTextBox)inputField).TextValue.Trim();
                            break;
                        }
                    case Constants.UC_CustomComboBox:
                        {
                            ((CustomComboBox)inputField).TextValue = ((CustomComboBox)inputField).TextValue.Trim();
                            break;
                        }
                }
            }
        }
    }
}
