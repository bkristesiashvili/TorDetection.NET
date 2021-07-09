using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;

using TorDetection.Models;
using TorDetection.Services.Converters;

namespace TorDetection.Services
{
    public sealed class TorDetectServiceFactory : ITorDetectService
    {
        #region CTOR

        public TorDetectServiceFactory()
        {
            Errors = new List<Exception>();
        }

        #endregion

        #region IMPLEMENTED PROPERTIES

        /// <summary>
        /// Handles any error
        /// </summary>
        public ICollection<Exception> Errors { get; }

        #endregion

        #region INTERNAL IMPLEMENTED METHODS

        /// <summary>
        /// Get tor user object information using IP address
        /// </summary>
        /// <param name="ipAddress">Clients remote IP address</param>
        /// <returns></returns>
        public TorObject GetTorObjectByIpAddress(IPAddress ipAddress)
        {
            try
            {
                if (ipAddress == null)
                    throw new ArgumentNullException(nameof(ipAddress));

                var ip = ipAddress.ToString();
                var completedUrl = string.Format(TorConstants.URL, ip);

                using var webCLient = new WebClient();
                string data = webCLient.DownloadStringTaskAsync(completedUrl).Result;
                webCLient.Dispose();

                return ConvertToTorObject(data);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Returns true if client is Tor User
        /// </summary>
        /// <param name="torUser"></param>
        /// <returns></returns>
        public bool IsTorUser(TorObject torUser)
        {
            if (torUser == null) return false;

            if (!torUser.Relays.Any()) return false;

            var runningRelays = from relay in torUser.Relays
                                where relay.IsRunning && relay.Measured
                                select relay;

            if (!runningRelays.Any()) return false;

            return true;
        }

        #endregion

        #region PRIVATE METHODS

        private TorObject ConvertToTorObject(string data)
        {
            TorObject result = null;

            try
            {
                if (string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data))
                    throw new ArgumentException($"JSON: {nameof(data)}");

                var option = new JsonSerializerOptions();
                option.Converters.Add(new JsonDateTimeConverter());

                result = JsonSerializer.Deserialize<TorObject>(data, option);

                return result;
            }
            catch(Exception e)
            {
                Errors.Add(e);
                return result;
            }
        }

        #endregion
    }
}
