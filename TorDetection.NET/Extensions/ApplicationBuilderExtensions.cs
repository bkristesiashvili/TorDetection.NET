using Microsoft.AspNetCore.Builder;

using System;

using TorDetection.Middleware;

namespace TorDetection
{
    public static class ApplicationBuilderExtensions
    {
        #region EXTENSION METHODS

        /// <summary>
        /// Protects the application accessing from TOR network
        /// </summary>
        /// <param name="this"></param>
        /// <param name="redirectUrl">redirect URL where the request will be redirected if access will be presented.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseTorDetection(this IApplicationBuilder @this,
            string redirectUrl)
        {
            if (@this == null)
                throw new ArgumentNullException(nameof(@this));

            if (string.IsNullOrEmpty(redirectUrl) || string.IsNullOrWhiteSpace(redirectUrl))
                throw new ArgumentNullException($"URL: {nameof(redirectUrl)}");

            @this.UseMiddleware(typeof(TorDetectionHandler), new[] { redirectUrl });

            return @this;
        }

        #endregion
    }
}
