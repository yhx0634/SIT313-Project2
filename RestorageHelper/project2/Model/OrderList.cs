using System;
using SQLite;

namespace project2
{
	public class OrderList
	{
		[PrimaryKey, AutoIncrement]
		public int ID{ get; set; }

		public DateTime OrderTime{ get; set; }
		public int ItemsID{ get; set; }
		public int SupplierName{ get; set; }
		public int Quality{ get; set; }
		public DateTime StockTime { get; set; }

		//public OrderList(int OrderID, string OrderName, string ItemsID, string SupplierID, int Quality)
		//{
		//	this.OrderID = OrderID;
		//	this.OrderName = OrderName;
		//	this.ItemsID = ItemsID;
		//	this.SupplierID = SupplierID;
		//	this.Quality = Quality;		
		//}

		public OrderList()
		{ }
	}
}
