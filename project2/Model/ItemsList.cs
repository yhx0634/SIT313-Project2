using System;
using SQLite;


namespace project2
{
	public class ItemsList
	{
		public ItemsList()
		{
			
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public DateTime StockDate { get; set; }

		public string ItemsName{ get; set; }

		public string ItemsUnit{ get; set; }

		public string SupplierName { get; set; }

		public string ItemsImage { get; set;}

		public int Count { get; set; }

		public int ListID { get; set; }




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
