using System;
using SQLite;


namespace project2
{
	public class FeedBack
	{
		public FeedBack()
		{

		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string Feedback { get; set; }
		public DateTime time { get; set;}




		//public ItemsList(int ItemsID, string ItemsName, string ItemsUnit, string SupplierID, string ItemsImage)
		//{
		//	this.ItemsID = ItemsID;
		//	this.ItemsName = ItemsName;
		//	this.ItemsUnit = ItemsUnit;
		//	this.SupplierID = SupplierID;
		//	this.ItemsImage = ItemsImage;
		//}


	}
}
