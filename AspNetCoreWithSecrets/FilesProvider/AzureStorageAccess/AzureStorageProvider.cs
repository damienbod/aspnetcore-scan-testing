using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreAzureStorageGroups.FilesProvider.AzureStorageAccess
{
    
    public class AzureStorageProvider
    {
        private string _blobConnectionString = "https://damienbod.blob.core.windows.net/nick?sp=r&st=2021-07-30T09:16:27Z&se=2021-07-30T17:16:27Z&spr=https&sv=2020-09-04&sr=c&sig=2wde34frfr21123456zZTjPO%2B2UstoxD349vchg5078145421E75tfDKJOs%3D";
        private string _blobKey = "sp=r&st=2021-07-30T09:16:27Z&se=2021-07-30T17:16:27Z&spr=https&sv=2020-08-04&sr=c&sig=vVK1BqcbgDUDVzZTjPO%2B2Ushfdfd33435t3899oNJEPlTQDKJOs%3D";

        private readonly TokenAcquisitionTokenCredential _tokenAcquisitionTokenCredential;
        private readonly IConfiguration _configuration;

        public AzureStorageProvider(TokenAcquisitionTokenCredential tokenAcquisitionTokenCredential,
            IConfiguration configuration)
        {
            _tokenAcquisitionTokenCredential = tokenAcquisitionTokenCredential;
            _configuration = configuration;
        }

        [AuthorizeForScopes(Scopes = new string[] { "https://storage.azure.com/user_impersonation" })]
        public async Task<string> AddNewFile(BlobFileUpload blobFileUpload, IFormFile file)
        {
            try
            {
                return await PersistFileToAzureStorage(blobFileUpload, file);
            }
            catch (Exception e)
            {
                throw new ApplicationException($"Exception {e}");
            }
        }

        [AuthorizeForScopes(Scopes = new string[] { "https://storage.azure.com/user_impersonation" })]
        public async Task<Azure.Response<BlobDownloadInfo>> DownloadFile(string fileName)
        {


            var storage = _configuration.GetValue<string>("AzureStorage:StorageAndContainerName");
            var fileFullName = $"{storage}{fileName}";
            var blobUri = new Uri(fileFullName);
            var blobClient = new BlobClient(blobUri, _tokenAcquisitionTokenCredential);
            return await blobClient.DownloadAsync();

            var blobClient2 = new BlobClient("https://damienbod.blob.core.windows.net/wow-blog?sp=r&st=2021-07-30T09:16:27Z&se=2021-07-30T17:16:27Z&spr=https&sv=2020-08-04&sr=c&sig=vV234566561B543frfrth654e2dej&9)TjPO%2B2UstoxDqN0788kd34md875WdDuPl98w23KJOs%3D", "damienbod", "fdfdf");
        }

        private async Task<string> PersistFileToAzureStorage(
            BlobFileUpload blobFileUpload,
            IFormFile formFile,
            CancellationToken cancellationToken = default)
        {
            var storage = _configuration.GetValue<string>("AzureStorage:StorageAndContainerName");
            var fileFullName = $"{storage}{blobFileUpload.Name}";
            var blobUri = new Uri(fileFullName);

            var blobUploadOptions = new BlobUploadOptions
            {
                Metadata = new Dictionary<string, string>
                {
                    { "uploadedBy", blobFileUpload.UploadedBy },
                    { "description", blobFileUpload.Description }
                }
            };

            var blobClient = new BlobClient(blobUri, _tokenAcquisitionTokenCredential);

            var inputStream = formFile.OpenReadStream();
            await blobClient.UploadAsync(inputStream, blobUploadOptions, cancellationToken);

            return $"{blobFileUpload.Name} successfully saved to Azure Storage Container";
        }
    }
}
