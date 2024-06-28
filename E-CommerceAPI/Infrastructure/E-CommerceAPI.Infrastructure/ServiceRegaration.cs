﻿using E_CommerceAPI.Application.Abstractions.Services;
using E_CommerceAPI.Application.Abstractions.Storage;
using E_CommerceAPI.Application.Abstractions.Token;
using E_CommerceAPI.Infrastructure.Enums;
using E_CommerceAPI.Infrastructure.Services;
using E_CommerceAPI.Infrastructure.Services.Storage;
using E_CommerceAPI.Infrastructure.Services.Storage.Local;
using E_CommerceAPI.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;



namespace E_CommerceAPI.Infrastructure
{

    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<IMailService, MailService>();
          

        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage , IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection , StorageType storageTaype)
        {
            switch (storageTaype)
            {
                
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.AWS:
                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}
