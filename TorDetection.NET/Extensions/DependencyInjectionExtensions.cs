using Microsoft.Extensions.DependencyInjection;

using System;

using TorDetection.Services;

namespace TorDetection
{
    public static class DependencyInjectionExtensions
    {
        #region EXTENSION METHODS

        /// <summary>
        /// Add Tor Detection Service to the applications services collection
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IServiceCollection AddTorDetectionService(this IServiceCollection @this)
        {
            if (@this == null)
                throw new ArgumentNullException(nameof(@this));

            @this.AddSingleton<ITorDetectService, TorDetectService>();

            return @this;
        }

        #endregion
    }
}
