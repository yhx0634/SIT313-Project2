using System;
using SQLite;

namespace project2
{
	public class LoginList
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public DateTime LoginDate{ get; set; }
		public string StaffID{ get; set; }
		public string OrderID{ get; set; }
		public string StockID{ get; set; }

		//public LoginList(DateTime LoginDate, string StaffID, string OrderID, string StockID, int AutoIncreaseID)
		//{
		//	this.LoginDate = LoginDate;
		//	this.StaffID = StaffID;
		//	this.OrderID = OrderID;
		//	this.StockID = StockID;
		//	this.AutoIncreaseID = AutoIncreaseID;
		//}

		public LoginList()
		{}
	}
}
