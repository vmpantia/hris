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
    public partial class CustomComboBox : UserControl
    {
        public bool _IsRequired = false;
        public CustomComboBox()
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

        public string TextValue
        {
            get
            {
                return ComboBox.Text;
            }
            set
            {
                ComboBox.SelectedValue = value;
            }
        }

    }
}
