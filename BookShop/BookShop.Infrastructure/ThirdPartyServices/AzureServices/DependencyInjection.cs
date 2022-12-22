namespace BookShop.Infrastructure.ThirdPartyServices.AzureServices
{
    using Azure.Storage.Blobs;
    using BookShop.Application.Interfaces;
    using BookShop.Infrastructure.ThirdPartyServices.AzureServices.Settings;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddThirdPartyServices(this IServiceCollection services, IConfiguration configuration)
        {
            var blobStorageSettings = new BlobStorageSettings();
            configuration.GetSection(BlobStorageSettings.SettingName).Bind(blobStorageSettings);

            services.AddSingleton(x => new BlobServiceClient(blobStorageSettings.ConnectionString));

            services.AddScoped<IFileStorageService, BlobStorageService>();

            return services;
        }
    }
}
