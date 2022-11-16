using HRIS.Desktop.Data;
using HRIS.Desktop.Models.enums;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HRIS.Desktop.UserControls
{
    public partial class CustomTextBox : UserControl
    {
        public bool _IsRequired = false;
        public CustomTextBoxType _CustomTextBoxType = CustomTextBoxType.DEFAULT;
        public CustomTextBox()
        {
            InitializeComponent();
        }
        public bool IsRequired
        {
            get
            {
                return _IsRequired;
            }
            set
            {
                _IsRequired = value;
            }
        }

        public bool IsValid
        {
            get
            {
                return ValidateTextBox();
            }
        }

        public string TitleValue
        {
            get
            {
                return LabelTitle.Text;
            }
            set
            { 
                LabelTitle.Text =  value;
            }
        }

        public string MessageValue
        {
            set
            {
                LabelMessage.Text = value;
            }
        }

        public string TextValue
        {
            get
            {
                return TextBox.Text;
            }
            set
            {
                TextBox.Text = value;
            }
        }

        public CustomTextBoxType CustomTextBoxTypeValue
        {
            get
            {
                return _CustomTextBoxType;
            }
            set
            {
                _CustomTextBoxType = value;
            }
        }

        public int MaxLengthValue
        {
            get
            {
                return TextBox.MaxLength;
            }
            set
            {
                TextBox.MaxLength = value;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBox();
        }

        private bool ValidateTextBox()
        {
            if (IsRequired)
            {
                if (string.IsNullOrEmpty(TextBox.Text))
                {
                    LabelMessage.ForeColor = Color.IndianRed;
                    LabelMessage.Text = Constants.REQUIRED_FIELD_MSG;
                    return false;
                }
            }

            switch (CustomTextBoxTypeValue)
            {
                case CustomTextBoxType.EMAIL:
                    {
                        if (!Globals.emailRegex.IsMatch(TextBox.Text))
                        {
                            LabelMessage.ForeColor = Color.IndianRed;
                            LabelMessage.Text = Constants.INVALID_EMAIL_MSG;
                            return false;
                        }
                        return true;
                    }
                case CustomTextBoxType.NUMBER:
                    {
                        if (!Globals.numberRegex.IsMatch(TextBox.Text))
                        {
                            LabelMessage.ForeColor = Color.IndianRed;
                            LabelMessage.Text = Constants.INVALID_NUMBER_MSG;
                            return false;
                        }
                        return true;
                    }
                case CustomTextBoxType.TEXT:
                    {
                        if (!Globals.textRegex.IsMatch(TextBox.Text))
                        {
                            LabelMessage.ForeColor = Color.IndianRed;
                            LabelMessage.Text = Constants.INVALID_TEXT_MSG;
                            return false;
                        }
                        return true;
                    }
                default:
                    break;
            }

            LabelMessage.ForeColor = Color.ForestGreen;
            LabelMessage.Text = Constants.VALID_DATA_MSG;
            return true;
        }
    }
}
