using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace project2
{
	//public class Item
	//{
	//	public int ID { get; set; }
	//	public string ItemName { get; set; }
	//	public string Company { get; set; }
	//	public string Image { get; set; }
	//	public string Unit { get; set; }
	//	public string Count { get; set; }

	//}

	//public class Stock_List
	//{
	//	public string Date { get; set; }
	//	public string OpearteTime { get; set; }
	//	public string StaffName { get; set; }

	//}

	//public class Order
	//{
	//	public string Date { get; set; }
	//	public string OpearteTime { get; set; }
	//	public string StaffName { get; set; }

	//}

	//public class Supplier_list
	//{
	//	public int ID { get; set; }
	//	public string SupplierName { get; set; }

	//}

	//public class ItemLists
	//{
	//	public string ItemName { get; set; }
	//	public string Company { get; set; }
	//	public string Image { get; set; }
	//	public string Unit { get; set; }
	//	public string Count { get; set; }

	//}

	public class DynamLists
	{
		public DateTime Date { get; set; }


	}

	public class DynamListForOrder
	{
		public DateTime Date { get; set; }

		public DateTime StockDate { get; set; }


	}


	public class Data
	{
		public static ObservableCollection<ItemsList> ItemList = new ObservableCollection<ItemsList>
		{
			//new ItemsList () {ID=1, ItemName = "ItemName", Company="Company", Image="chips.jpg", Unit="kg", Count="12"},


		};


		public static ObservableCollection<OrderList> OrderList = new ObservableCollection<OrderList>
		{
			//new Order () {OpearteTime = "09:38", StaffName="Randy", Date="10-09-2016"},
		};

		public static ObservableCollection<SupplierList> SupplierList = new ObservableCollection<SupplierList>
		{
			//new SupplierList () {ID=0, SupplierName = "SupplierNamesssssssss"},
		};

		public static ObservableCollection<ListofItemList> ListofItemList = new ObservableCollection<ListofItemList>
		{
			//new SupplierList () {ID=0, SupplierName = "SupplierNamesssssssss"},
			//new SupplierList () {ID=0, SupplierName = "mmmmmmmmmmmmmmmmmmmmm"}
		};

		public static ObservableCollection<StockList> StockList = new ObservableCollection<StockList>
		{
			//new SupplierList () {ID=0, SupplierName = "SupplierNamesssssssss"},
			//new SupplierList () {ID=0, SupplierName = "mmmmmmmmmmmmmmmmmmmmm"}
		};

		public static ObservableCollection<DynamLists> DynamList = new ObservableCollection<DynamLists>
		{
			//new SupplierList () {ID=0, SupplierName = "SupplierNamesssssssss"},
			//new SupplierList () {ID=0, SupplierName = "mmmmmmmmmmmmmmmmmmmmm"}
		};

		public static ObservableCollection<DynamListForOrder> DynamListForOrder = new ObservableCollection<DynamListForOrder>
		{
			//new SupplierList () {ID=0, SupplierName = "SupplierNamesssssssss"},
			//new SupplierList () {ID=0, SupplierName = "mmmmmmmmmmmmmmmmmmmmm"}
		};
	}
}

