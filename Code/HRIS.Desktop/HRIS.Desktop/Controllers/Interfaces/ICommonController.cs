namespace HRIS.Desktop.Controllers
{
    public interface ICommonController
    {
        void ResetField(params object[] inputFields);
        void TrimField(params object[] inputFields);
    }
}