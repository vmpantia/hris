using HRIS.Desktop.Controllers;
using HRIS.Desktop.Data;
using HRIS.Desktop.Views;
using System;
using System.Windows.Forms;

namespace HRIS.Desktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Globals.commonController = new CommonController();
            Globals.httpController = new HTTPController();

            InitializeComponent();
            InitialForm(Constants.viewDashboardForm);
        }

        private void InitialForm(string newForm)
        {
            //Remove Previous Form
            if (body.Controls.Count > 0)
            {
                body.Controls.Clear();
            }

            switch (newForm)
            {
                case Constants.viewDashboardForm:
                    {
                        SetViewForm(new DashboardForm());
                        break;
                    }
                case Constants.viewEmployeeForm:
                    {
                        SetViewForm(new EmployeeForm());
                        break;
                    }
            }
        }

        private void SetViewForm(Form form)
        {
            form.TopLevel = false;
            form.AutoScroll = true;
            form.Dock = DockStyle.Fill;
            body.Controls.Add(form);
            form.Show();
            form.Focus();
        }

        private void btnViewDashboard_Click(object sender, EventArgs e)
        {
            InitialForm(Constants.viewDashboardForm);
        }

        private void btnViewEmployee_Click(object sender, EventArgs e)
        {
            InitialForm(Constants.viewEmployeeForm);
        }

    }
}
