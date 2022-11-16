using HRIS.Model;

namespace HRIS.Desktop.Controllers
{
    public interface IHTTPController
    {
        Employee PostSaveEmployee(Employee inputEmployee);
    }
}