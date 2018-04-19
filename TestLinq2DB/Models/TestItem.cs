using System;
using LinqToDB.Mapping;

namespace TestLinq2DB.Models
{
	[Table(Name = "TestTbl")]
	public class TestItem
    {		
		[PrimaryKey, Identity]
		public int ID { get; set; }

		[Column(Name = "Text"), NotNull]
		public string Text { get; set; }
	}
}
