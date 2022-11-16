using HRIS.Desktop.Data;
using HRIS.Model;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace HRIS.Desktop.Controllers
{
    public class HTTPController : IHTTPController
    {
        public Employee PostSaveEmployee(Employee inputEmployee)
        {
            var js = new JavaScriptSerializer();
            string data = js.Serialize(inputEmployee);
            byte[] byteArray = Encoding.UTF8.GetBytes(data);
            var url = string.Concat(Constants.EmployeeAPI, Constants.PostSaveEmployee);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = Constants.POST;
            request.ContentType = Constants.ContentType;
            request.KeepAlive = true;
            request.ContentLength = byteArray.Length;
            try
            {
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                using (var httpResponse = (HttpWebResponse)request.GetResponse())
                {
                    if (httpResponse.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception();
                    }
                    using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var objText = reader.ReadToEnd();
                        var result = (Employee)js.Deserialize(objText, typeof(Employee));
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
