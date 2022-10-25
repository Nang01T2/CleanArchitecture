using System.Net.Http;

namespace {{ cookiecutter.assembly_name }}.MVC.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
