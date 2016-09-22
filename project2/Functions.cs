using System;
using System.Security;
using System.Text;

namespace project2
{
	public class Functions
	{

		public static int IndexofSupplier(int value)
		{
			int index = -1;
			for (int i = 0; i < Data.SupplierList.Count; i++)
			{
				if (Data.SupplierList[i].ID == value)
				{
					index = i;
					break;
				}
			}

			return index;

		}

		public static void removeList(int index)
		{
			Data.SupplierList.RemoveAt(index);

		}


		public static int setID()
		{
			App.Database.GetListofItemsListTest();

			int max = int.MinValue;
			foreach (var s in Data.ListofItemList)
			{
				if (s.ID > max)
				{
					max = s.ID;
				}
			}
			//max++;
			return max;
		}


		public static int plusButton_Clicked(string value)
		{

			int count = -1;
			if (Int32.TryParse(value, out count))
				count++;
			
			return count;
		}

		public static int minButton_Clicked(string value)
		{

			int count = -1;
			if (Int32.TryParse(value, out count) && count > 0)
				count--;

			return count;
		}

		public static void getItemList(DateTime id)
		{
			App.Database.GetItemsListByDate(id);
		}

		public static void getItemListbyid(int id)
		{
			App.Database.GetItemsListById(id);
		}


		public static void getItemListbyDate(DateTime date)
		{
			App.Database.GetItemsListByDate(date);
		}

		public static void getItemListbyOrderDate(DateTime date)
		{
			App.Database.GetItemsListByOrderDate(date);
		}


		public static void setStockList()
		{
			DateTime time = System.DateTime.Now;

				foreach (var s in Data.ItemList)
				{
					Data.StockList.Add(new StockList() { StockDate = time, ItemsID = s.ID, Quality = s.Count, ListId = s.ListID });
				}
		}

		public static void setOrderList()
		{
			DateTime time = System.DateTime.Now;

			foreach (var s in Data.ItemList)
			{
				Data.OrderList.Add(new OrderList() { OrderTime = time, ItemsID = s.ID, Quality = s.Count, StockTime = StockListForOrderPage.oederdynmdate });
			}
		}



		public static void updateStockList(DateTime date)
		{
			
				foreach (var i in Data.ItemList)
				{
					
						foreach (var s in Data.StockList)
						{
							if (s.ItemsID == i.ID && s.StockDate == date)
								s.Quality = i.Count;
						}

						//Data.StockList(new StockList() { StockDate = time, ItemsID = s.ID, Quality = s.Count, ListId = s.ListID });

					
				}

		}

		public static void updateOrderList(DateTime date)
		{

			App.Database.GetOrderListTest();

			foreach (var i in Data.ItemList)
			{

				foreach (var s in Data.OrderList)
				{
					if (s.ItemsID == i.ID && s.OrderTime == date)
						s.Quality = i.Count;
				}

				//Data.StockList(new StockList() { StockDate = time, ItemsID = s.ID, Quality = s.Count, ListId = s.ListID });


			}

		}



		public static void setQuality()
		{
			App.Database.GetStockListTest();
			foreach (var s in Data.StockList)
			{
				foreach (var i in Data.ItemList)
				{
					if (s.ItemsID == i.ID)
					{
						i.Count = s.Quality;
						break;
					}
				}
			}

			Data.StockList.Clear();


		}
	}
}

