using System;
using System.Collections.Generic;
using System.Net;

using TorDetection.Models;

namespace TorDetection.Services
{
    public interface ITorDetectService
    {
        #region INTERFACE PROPERTIES

        ICollection<Exception> Errors { get; }

        #endregion

        #region INTERFACE METHODS

        TorObject GetTorObjectByIpAddress(IPAddress ipAddress);

        bool IsTorUser(TorObject torUser);

        #endregion
    }
}
