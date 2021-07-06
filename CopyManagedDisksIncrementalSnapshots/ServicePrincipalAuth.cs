using System;
using System.Collections.Generic;
using System.Text;

namespace BackupManagedDisksWithIncrementalSnapshots
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure.Authentication;
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;
    using System.Runtime.CompilerServices;
    using Microsoft.Azure.Management.Network.Fluent.Models;

    /// <summary>
    /// Contains public methods to get configuration settings, to initiate authentication, output error results, etc.
    /// </summary>
    public static class ServicePrincipalAuth
    {
        /// <summary>
        /// Gets service principal based credentials
        /// </summary>
        /// <param name="authFile">Environment variable that points to the file system secured azure auth settings</param>
        /// <returns>ServiceClientCredentials</returns>
        public static async Task<ServiceClientCredentials> GetServicePrincipalCredential(string authFile)
        {
            Console.WriteLine($"fullAuthFilePath = {authFile}");

            AzureAuthInfo authSettings = JsonSerializer.Deserialize<AzureAuthInfo>(File.ReadAllText(authFile));
            var aadSettings = new ActiveDirectoryServiceSettings
            {
                AuthenticationEndpoint = new Uri(authSettings.ActiveDirectoryEndpointUrl),
                TokenAudience = new Uri(authSettings.ManagementEndpointUrl),
                ValidateAuthority = true
            };



            ServiceClientCredentials servicePrincipalCredentials = null;
            try
            {
                Task<ServiceClientCredentials> task = ApplicationTokenProvider.LoginSilentAsync(
                    authSettings.TenantId,
                    authSettings.ClientId,
                    authSettings.ClientSecret,
                    aadSettings);
                servicePrincipalCredentials = await task.ConfigureAwait(true);
            }
            catch
            {
                throw;
            }
            return servicePrincipalCredentials;
        }
    }
}
