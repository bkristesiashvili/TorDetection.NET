using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TorDetection.Models
{
    public sealed class TorObject
    {
        #region PUBLIC PROPERTIES

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("build_revision")]
        public string BuildVersion { get; set; }

        [JsonPropertyName("relays_published")]
        public DateTime RelaysPublished { get; set; }

        [JsonPropertyName("relays")]
        public ICollection<TorRelay> Relays { get; set; }

        [JsonPropertyName("bridges_published")]
        public DateTime BridgesPublished { get; set; }

        #endregion
    }
}
