using System;
using SQLite;

namespace project2
{
	public class StockList
	{
		[PrimaryKey, AutoIncrement]
		public int ID{ get; set; }

		public DateTime StockDate{ get; set; }
		public int ItemsID{ get; set; }
		public int Quality{ get; set; }
		public int ListId{ get; set; }


		//public StockList(int StockID, DateTime StockDate, string ItemsID, int Quality)
		//{
		//	this.StockID = StockID;
		//	this.StockDate = StockDate;
		//	this.ItemsID = ItemsID;
		//	this.Quality = Quality;
		//}

		public StockList()
		{ }
	}
}
