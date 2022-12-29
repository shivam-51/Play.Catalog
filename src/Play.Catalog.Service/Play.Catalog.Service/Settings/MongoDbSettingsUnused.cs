using System;
namespace Play.Catalog.Service.Settings
{
	public class MongoDbSettingsUnused
	{
		private string Host { get; init; }

        private string Port { get; init; }

		public string ConnectionString => $"mongodb://{Host}:{Port}";
    }
}

