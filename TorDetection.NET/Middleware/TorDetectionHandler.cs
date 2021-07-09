using Microsoft.AspNetCore.Http;

using System;
using System.Threading.Tasks;

using TorDetection.Services;

namespace TorDetection.Middleware
{
    public sealed class TorDetectionHandler
    {
        #region PRIVATE FIELDS

        private readonly RequestDelegate _requestDelegate;
        private readonly string _redirectUrl;

        #endregion

        #region CTOR

        public TorDetectionHandler(RequestDelegate next, string url)
        {
            _requestDelegate = next ?? throw new ArgumentNullException(nameof(next));
            _redirectUrl = url;
        }

        #endregion

        #region PUBLIC METHODS

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (context == null)
                    throw new ArgumentNullException(nameof(context));

                var service = (ITorDetectService)context.RequestServices
                    .GetService(typeof(ITorDetectService));

                if (service == null)
                    throw new ArgumentNullException($"TOR DETECTION: {nameof(service)}");

                var host = context.Request.Host;

                if (host.Host == "localhost")
                {
                    await _requestDelegate(context);
                    return;
                }

                var path = context.Request.Path;

                if(path == _redirectUrl)
                {
                    await _requestDelegate(context);
                    return;
                }

                var ipaddress = context.Connection.RemoteIpAddress;

                var result = await Task.FromResult(service.GetTorObjectByIpAddress(ipaddress));

                if (service.IsTorUser(result))
                    context.Response.Redirect(_redirectUrl);
                else
                    await _requestDelegate(context);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion
    }
}
