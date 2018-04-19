using System.Linq;
using System.Collections.Generic;
using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using TestLinq2DB.Models;


namespace TestLinq2DB.LinqToDB
{
	public class ConnectionStringSettings : IConnectionStringSettings
	{
		public string ConnectionString { get; set; }
		public string Name { get; set; }
		public string ProviderName { get; set; }
		public bool IsGlobal => false;
	}

	public class MySettings : ILinqToDBSettings
	{
		public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

		public string DefaultConfiguration => "TestLinq2DB";
		public string DefaultDataProvider => "MySql.Data.MySqlClient";

		public IEnumerable<IConnectionStringSettings> ConnectionStrings
		{
			get
			{
				yield return
					new ConnectionStringSettings
					{
						Name = "TestLinq2DB",
						ProviderName = "MySql.Data.MySqlClient",
						ConnectionString = "Server=localhost;Port=3306;Database=test;Uid=root;Pwd=NSM2448;charset=utf8;"
					};
			}
		}
	}

	public class DBTest : DataConnection
	{
		public DBTest() : base("TestLinq2DB") { }

		public ITable<TestItem> TestItems => GetTable<TestItem>();
	}
}