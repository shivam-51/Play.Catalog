using System;

namespace Play.Catalog.Service.Entities
{
    public class MongoDbSettings
    {
        public string Host { get; set; }

        public string Port { get; set; }

        public string DatabaseName => "Catalog";

        public string ConnectionString => $"mongodb://{this.Host}:{Port}";
        //public string ConnectionString { get; set; } = null!;
    }
}

