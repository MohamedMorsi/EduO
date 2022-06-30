using EduO.Web.HttpServices.Contract;
using System.Net.Http.Headers;
using Toolbelt.Blazor;

namespace EduO.Web.HttpServices.Service
{
    public class HttpInterceptorService
    {
        private readonly HttpClientInterceptor _interceptor;
        private readonly IAuthenticationService _authenticationService;

        public HttpInterceptorService(HttpClientInterceptor interceptor, IAuthenticationService authenticationService)
        {
            _interceptor = interceptor;
            _authenticationService = authenticationService;
        }

        public void RegisterEvent() => _interceptor.BeforeSendAsync += InterceptBeforeHttpAsync;

        public async Task InterceptBeforeHttpAsync(object sender, HttpClientInterceptorEventArgs e)
        {
            var absPath = e.Request.RequestUri.AbsolutePath;

            if (!absPath.Contains("token") && !absPath.Contains("accounts"))
            {
                var token = await _authenticationService.TryRefreshToken();

                if (!string.IsNullOrEmpty(token))
                {
                    e.Request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
                }
            }
        }

        public void DisposeEvent() => _interceptor.BeforeSendAsync -= InterceptBeforeHttpAsync;
    }
}
