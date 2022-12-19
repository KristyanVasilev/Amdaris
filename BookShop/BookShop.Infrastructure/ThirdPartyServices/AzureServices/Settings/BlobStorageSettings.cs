namespace BookShop.Infrastructure.ThirdPartyServices.AzureServices.Settings
{
    public class BlobStorageSettings
    {
        public const string SettingName = "BlobStorageSettings";

        public string ConnectionString { get; set; } = null!;
    }
}
