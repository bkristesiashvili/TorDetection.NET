using System;
using System.Text.Json.Serialization;

namespace TorDetection.Models
{
    public sealed class TorRelay
    {
        #region PUBLIC PROPERTIES

        [JsonPropertyName("nickname")]
        public string NickName { get; set; }

        [JsonPropertyName("fingerprint")]
        public string Fingerprint { get; set; }

        [JsonPropertyName("dir_address")]
        public string Address { get; set; }

        [JsonPropertyName("last_seen")]
        public DateTime LastSeen { get; set; }

        [JsonPropertyName("first_seen")]
        public DateTime FirstSeen { get; set; }

        [JsonPropertyName("last_changed_address_or_port")]
        public DateTime LastChanged { get; set; }

        [JsonPropertyName("running")]
        public bool IsRunning { get; set; }

        [JsonPropertyName("country_name")]
        public string Country { get; set; }

        [JsonPropertyName("as")]
        public string As { get; set; }

        [JsonPropertyName("as_name")]
        public string AsName { get; set; }

        [JsonPropertyName("platform")]
        public string Platform { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("recommended_version")]
        public bool RecommendedVersion { get; set; }

        [JsonPropertyName("measured")]
        public bool Measured { get; set; }

        #endregion
    }
}
