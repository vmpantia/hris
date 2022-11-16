using HRIS.Desktop.Models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRIS.Desktop.UserControls
{
    public partial class CustomDatePicker : UserControl
    {
        public bool _IsRequired = false;
        public CustomDatePicker()
        {
            InitializeComponent();
        }

        public string TitleValue
        {
            get
            {
                return LabelTitle.Text;
            }
            set
            {
                LabelTitle.Text = value;
            }
        }

        public string MessageValue
        {
            set
            {
                LabelMessage.Text = value;
            }
        }

        public DateTime TextValue
        {
            get
            {
                return DateTimePicker.Value;
            }
            set
            {
                if (value < DateTimePicker.MinDate)
                {
                    DateTimePicker.Value = DateTimePicker.MinDate;
                }
                else if (value > DateTimePicker.MaxDate)
                {
                    DateTimePicker.Value = DateTimePicker.MaxDate;
                }
                else
                {
                    DateTimePicker.Value = value;
                }
            }
        }
    }
}
