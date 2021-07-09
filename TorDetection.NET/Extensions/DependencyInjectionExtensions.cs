using Microsoft.Extensions.DependencyInjection;

using System;

using TorDetection.Services;

namespace TorDetection
{
    public static class DependencyInjectionExtensions
    {
        #region EXTENSION METHODS

        public static IServiceCollection AddTorDetectionService(this IServiceCollection @this)
        {
            if (@this == null)
                throw new ArgumentNullException(nameof(@this));

            @this.AddSingleton<ITorDetectService, TorDetectServiceFactory>();

            return @this;
        }

        #endregion
    }
}
