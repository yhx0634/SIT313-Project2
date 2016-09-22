using System;
using SQLite;

namespace project2
{
	public class StaffList
	{
		[PrimaryKey, AutoIncrement]
		public int ID{ get; set; }

		public string StaffName{ get; set; }
		public string Password{ get; set; }
		public DateTime CreateDate{ get; set; }

		//public StaffList(int StaffID, string StaffName, string Password, DateTime CreateDate)
		//{
		//	this.StaffID = StaffID;
		//	this.StaffName = StaffName;
		//	this.Password = Password;
		//	this.CreateDate = CreateDate;
		//}

		public StaffList()
		{ }
	}
}
