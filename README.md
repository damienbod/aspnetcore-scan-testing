# aspnetcore-scan-testing

[![.NET](https://github.com/damienbod/aspnetcore-scan-testing/actions/workflows/dotnet-gitguardian.yml/badge.svg)](https://github.com/damienbod/aspnetcore-scan-testing/actions/workflows/dotnet-gitguardian.yml)

[![.NET](https://github.com/damienbod/aspnetcore-scan-testing/actions/workflows/dotnet-gitleaks.yml/badge.svg)](https://github.com/damienbod/aspnetcore-scan-testing/actions/workflows/dotnet-gitleaks.yml)

## secrets added to the appsettings.json

```
{
   "ConnectionStrings": {
    "DefaultConnection": "Data Source=.\\SQLEXPRESS;Initial Catalog=FilesDescriptionAzureStorage;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
    "AzureServiceBus": "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=h1fdfdgfjnhmcvbtz65h65hn6hgeb"
  },
  "AzureAd": {
    "ClientSecret": "vvfgfhghgjw4tgrgfbgfhgfjsrt",
  },
  "ApiTwo": {
    "accessToken": "eygregertg4ert3gtrhzi76gfnghmjhmjhmdfrsfreterhgfndghvbfvb"
  },
  "ApiThree": {
    "key": "fgfgfgmr43rfef)333ffrvvdedcggfd43r43gtjnumjnb"
  },
  "CosmosSecrets": {
    "PrimaryKey": "snHKwybUbSd43fvr4tbz56bUVMyYT61ssp3787v8v338rf8dd80003f3cf2ddc3r3w=="
  },
  "MyBotSecrets": {
    "ApiKey": "Yp9B3$7i6epJbuUfOcgC"
  },
}
```

## secrets added to the AzureStorageProvider.cs

```
private string _blobConnectionString = "https://damienbod.blob.core.windows.net/nick?sp=r&st=2021-07-30T09:16:27Z&se=2021-07-30T17:16:27Z&spr=https&sv=2020-09-04&sr=c&sig=2wde34frfr21123456zZTjPO%2B2UstoxD349vchg5078145421E75tfDKJOs%3D";

private string _blobKey = "sp=r&st=2021-07-30T09:16:27Z&se=2021-07-30T17:16:27Z&spr=https&sv=2020-08-04&sr=c&sig=vVK1BqcbgDUDVzZTjPO%2B2Ushfdfd33435t3899oNJEPlTQDKJOs%3D";

var blobClient2 = new BlobClient("https://damienbod.blob.core.windows.net/wow-blog?sp=r&st=2021-07-30T09:16:27Z&se=2021-07-30T17:16:27Z&spr=https&sv=2020-08-04&sr=c&sig=vV234566561B543frfrth654e2dej&9)TjPO%2B2UstoxDqN0788kd34md875WdDuPl98w23KJOs%3D", "damienbod", "fdfdf");

```

## Links

https://github.com/GitGuardian/ggshield

https://dashboard.gitguardian.com/workspace/142648/perimeter?health=_&sort_health=true&sort_ic=true

https://github.com/zricethezav/gitleaks

https://codeql.github.com/docs/

https://github.com/codacy/codacy-analysis-cli