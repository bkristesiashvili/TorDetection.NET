using System;
using System.Collections.Generic;
using System.Net;

using TorDetection.Models;

namespace TorDetection.Services
{
    public interface ITorDetectService
    {
        #region INTERFACE PROPERTIES

        /// <summary>
        /// Handles any error
        /// </summary>
        ICollection<Exception> Errors { get; }

        #endregion

        #region INTERFACE METHODS

        /// <summary>
        /// Get tor user object information using IP address
        /// </summary>
        /// <param name="ipAddress">Clients remote IP address</param>
        /// <returns></returns>
        TorObject GetTorObjectByIpAddress(IPAddress ipAddress);

        /// <summary>
        /// Returns true if client is Tor User
        /// </summary>
        /// <param name="torUser"></param>
        /// <returns></returns>
        bool IsTorUser(TorObject torUser);

        #endregion
    }
}
