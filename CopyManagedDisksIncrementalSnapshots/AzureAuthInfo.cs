using System;
using System.Collections.Generic;
using System.Text;

namespace BackupManagedDisksWithIncrementalSnapshots
{
    using System.Text.Json.Serialization;

    public class AzureAuthInfo
    {
        [JsonPropertyName("clientId")]
        public string ClientId { get; set; }

        [JsonPropertyName("clientSecret")]
        public string ClientSecret { get; set; }

        [JsonPropertyName("subscriptionId")]
        public string SubscriptionId { get; set; }

        [JsonPropertyName("tenantId")]
        public string TenantId { get; set; }

        [JsonPropertyName("activeDirectoryEndpointUrl")]
        public string ActiveDirectoryEndpointUrl { get; set; }

        [JsonPropertyName("resourceManagerEndpointUrl")]
        public string ResourceManagerEndpointUrl { get; set; }

        [JsonPropertyName("activeDirectoryGraphResourceId")]
        public string ActiveDirectoryGraphResourceId { get; set; }

        [JsonPropertyName("sqlManagementEndpointUrl")]
        public string SqlManagementEndpointUrl { get; set; }

        [JsonPropertyName("galleryEndpointUrl")]
        public string GalleryEndpointUrl { get; set; }

        [JsonPropertyName("managementEndpointUrl")]
        public string ManagementEndpointUrl { get; set; }
    }
}
