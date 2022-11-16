using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRIS.Desktop.UserControls
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public Color DashboardColor
        {
            set
            {
                this.BackColor = value;
            }
        }
        public int DashboardCount
        {
            set
            {
                Count.Text = value.ToString();
            }
        }

        public string DashboardTitle
        {
            set
            {
                Title.Text = value;
            }
        }

        public Image DashboardIcon
        {
            set
            {
                Icon.Image = value;
            }
        }
    }
}
