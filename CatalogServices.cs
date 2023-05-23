using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Play.Common.Entities;
using Play.Common.MongoDB;
using Play.Common.Repositories;
using Play.Common.Settings;

namespace Play.Catalog.service
{
    public static class CatalogServices
    {
        //public static IServiceCollection AddMongo(this IServiceCollection services)
        //{
        //    BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
        //    BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String)); 

        //    services.AddSingleton(serviceProvider => {
        //        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        //        ServiceSettings serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
        //        var mongoDbSettings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
        //        var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
        //        return mongoClient.GetDatabase(serviceSettings.ServiceName);
        //    });

        //    services.AddControllers(options => { options.SuppressAsyncSuffixInActionNames = false; });

        //    return services;
        //}

        //public static IServiceCollection AddMongoRepository<T>(this IServiceCollection services, string collectionName) where T : IEntity
        //{
        //    services.AddSingleton<IRepository<T>>(serviceProvider => {
        //        var database = serviceProvider.GetService<IMongoDatabase>();
        //        return new MongoRepository<T>(database, collectionName);
        //    });

        //    return services;
        //}
    }
}
  