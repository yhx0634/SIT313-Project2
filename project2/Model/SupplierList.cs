using System;
using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace project2
{
	public class SupplierList
	{

		public SupplierList()
		{ }

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string SupplierName{ get; set; }
		//public string ItemsID{ get; set; }

		//public SupplierList(int SupplierID, string SupplierName)
		//{
		//	this.SupplierID = SupplierID;
		//	this.SupplierName = SupplierName;
		//	//this.ItemsID = ItemsID;
		//}



	}

	//public class Data2
	//{
	//	public static ObservableCollection<SupplierList> slist = new ObservableCollection<SupplierList>
	//		{
	//			new SupplierList () {ID=0, SupplierName = "SupplierNamesssssssss"}
	//			new SupplierList () {ID=0, SupplierName = "SupplierNamesssssssss"}
	//		};
	//}
}
