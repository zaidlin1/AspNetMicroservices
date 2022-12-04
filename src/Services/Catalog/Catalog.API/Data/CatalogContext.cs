﻿using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSetting:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSetting:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSetting:CollectionName"));

            //CatalogContextSeet.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; } 
    }
}
