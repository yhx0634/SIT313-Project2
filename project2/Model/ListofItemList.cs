using System;
using SQLite;
namespace project2
{
	public class ListofItemList
	{
		public ListofItemList()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string ListName { get; set; }

	}
}

