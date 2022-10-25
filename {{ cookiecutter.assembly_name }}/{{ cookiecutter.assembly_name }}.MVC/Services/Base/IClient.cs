using System.Net.Http;

namespace {{ cookiecutter.assembly_name }}.MVC.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }

    }
}
