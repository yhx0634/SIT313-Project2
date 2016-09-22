using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite.Net.Attributes;
using SQLite;
using Xamarin.Forms;

namespace project2
{
	public class DataBaseFunction
	{
		static object locker = new object();

		SQLiteConnection database;


		/// <summary>
		/// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
		/// 
		public DataBaseFunction()
		{
			database = DependencyService.Get<ISQLite>().GetConnection();

			// create the tables
			database.CreateTable<ItemsList>();
			database.CreateTable<LoginList>();
			database.CreateTable<OrderList>();
			database.CreateTable<StaffList>();
			database.CreateTable<StockList>();
			database.CreateTable<SupplierList>();
			database.CreateTable<ListofItemList>();
			database.CreateTable<FeedBack>();
		}

		//public IEnumerable<MyList> GetItems()
		//{
		//	lock (locker)
		//	{
		//		return (from i in database.Table<ItemsList>() select i).ToList();
		//	}
		//}

		//public IEnumerable<MyList> GetItemsNotDone(string opition)
		//{
		//	lock (locker)
		//	{
		//		return database.Query<MyList>("SELECT * FROM [MyList] WHERE [Done] = 0");
		//	}
		//}

		//public MyList GetItem(int id)
		//{
		//	lock (locker)
		//	{
		//		return database.Table<MyList>().FirstOrDefault(x => x.ID == id);
		//	}
		//}

		public int firstSaveSupplier(SupplierList item)
		{
			return database.Insert(item);


		}

		public void SaveSupplierTest()
		{
			foreach (SupplierList s in Data.SupplierList)
			{
				if (s.ID != 0)
					database.Update(s);
				else
					database.Insert(s);
			}

		}

		public void SaveStockTest()
		{
			foreach (StockList s in Data.StockList)
			{
				if (s.ID != 0)
					database.Update(s);
				else
					database.Insert(s);
			}

		}


		public void UpdateStockTest()
		{
			foreach (StockList s in Data.StockList)
			{
				database.Update(s);

			}

		}


		public void SaveOrderTest()
		{
			foreach (OrderList s in Data.OrderList)
			{
				if (s.ID != 0)
					database.Update(s);
				else
					database.Insert(s);
			}

		}

		public void UpdateOrderTest()
		{
			foreach (OrderList s in Data.OrderList)
			{
				database.Update(s);

			}

		}




		public void SaveListTest()
		{
			foreach (ListofItemList s in Data.ListofItemList)
			{
				if (s.ID != 0)
					database.Update(s);
				else
					database.Insert(s);
			}

		}

		public void SaveItemTest()
		{
			int id = Functions.setID();
			foreach (ItemsList s in Data.ItemList)
			{
				s.ListID = id;

				if (s.ID != 0)
					database.Update(s);
				else
					database.Insert(s);
			}
		}



		public int SaveSupplier(SupplierList item)
		{
			lock (locker)
			{
				
				if (item.ID != 0)
				{
					
					database.Update(item);
					return item.ID;
				}
				else {
					return database.Insert(item);
				}
			}
		}

		public int SaveItem(ItemsList item)
		{
			lock (locker)
			{
				if (item.ID != 0)
				{
					database.Update(item);
					return item.ID;
				}
				else {
					return database.Insert(item);
				}
			}
		}

		public int SaveStock(StockList stock)
		{
			lock (locker)
			{
				if (stock.ID != 0)
				{
					database.Update(stock);
					return stock.ID;
				}
				else {
					return database.Insert(stock);
				}
			}
		}

		public int DeleteItemsItem(int id)
		{
			lock (locker)
			{
				return database.Delete<ItemsList>(id);
			}
		}

		public int DeleteSupplierItem(int id)
		{
			lock (locker)
			{
				return database.Delete<SupplierList>(id);
			}
		}

		//public List<ItemsList> GetItemsList()
		//{
		//	lock (locker)
		//	{
		//		return (from i in database.Table<ItemsList>() select i).ToList();
		//	}
		//}

		public IEnumerable<ItemsList> GetItemsList()
		{
			lock (locker)
			{
				return (from i in database.Table<ItemsList>() select i).ToList();
			}
		}

		public IEnumerable<ItemsList> GetItemsListById(int id)
		{
			
			Data.ItemList.Clear();
			foreach (ItemsList s in database.Table<ItemsList>())
			{
				if(s.ListID == id)
					Data.ItemList.Add(s);
			}

			return Data.ItemList;

		}


		//public IEnumerable<ItemsList> GetItemsListBy(int id)
		//{

		//	Data.ItemList.Clear();
		//	foreach (ItemsList s in database.Table<ItemsList>())
		//	{
		//		if (s.ListID == id)
		//			Data.ItemList.Add(s);
		//	}

		//	return Data.ItemList;

		//}


		public IEnumerable<ItemsList> GetItemsListByDate(DateTime date)
		{

			Data.ItemList.Clear();

			foreach (StockList s in database.Table<StockList>())
			{
				if (s.StockDate == date)
				{
					foreach (ItemsList i in database.Table<ItemsList>())
					{
						
						if (s.ItemsID == i.ID)
						{
							i.Count = s.Quality;
							Data.ItemList.Add(i);
							break;
						}
					}
				}

			}


			return Data.ItemList;

		}


		public IEnumerable<ItemsList> GetItemsListByOrderDate(DateTime date)
		{

			Data.ItemList.Clear();

			foreach (OrderList s in database.Table<OrderList>())
			{
				if (s.OrderTime == date)
				{
					foreach (ItemsList i in database.Table<ItemsList>())
					{

						if (s.ItemsID == i.ID)
						{
							i.Count = s.Quality;
							Data.ItemList.Add(i);
							break;
						}
					}
				}

			}


			return Data.ItemList;

		}





		public IEnumerable<DynamLists> GetDynamListByStockDate()
		{
			Data.DynamList.Clear();

			DateTime temp = System.DateTime.Now;

			foreach (StockList s in database.Table<StockList>().OrderByDescending(i=>i.StockDate))
			{

				if (s.StockDate != temp)
				{
					Data.DynamList.Add(new DynamLists() { Date = s.StockDate });
					temp = s.StockDate;
				}
					
				else
					temp = s.StockDate;
			}

			return Data.DynamList;
		}


		public IEnumerable<DynamListForOrder> GetDynamListByOrderTime()
		{
			Data.DynamListForOrder.Clear();

			DateTime temp = System.DateTime.Now;

			foreach (OrderList s in database.Table<OrderList>().OrderByDescending(i => i.OrderTime))
			{

				if (s.OrderTime != temp)
				{
					Data.DynamListForOrder.Add(new DynamListForOrder() { Date = s.OrderTime, StockDate = s.StockTime });
					temp = s.OrderTime;
				}

				else
					temp = s.OrderTime;
			}

			return Data.DynamListForOrder;
		}

		public IEnumerable<SupplierList> GetSuppilerToItemsList()
		{
			lock (locker)
			{
				return (from i in database.Table<SupplierList>() select i).ToList();
			}
		}

		public List<StockList> GetStockList()
		{
			lock (locker)
			{
				return (from i in database.Table<StockList>() select i).ToList();
			}
		}

		public List<StockList> GetOrderList()
		{
			lock (locker)
			{
				return (from i in database.Table<StockList>() select i).ToList();
			}
		}

		public IEnumerable<SupplierList> GetSupplierList()
		{
			lock (locker)
			{
				return (from i in database.Table<SupplierList>() select i).ToList();
			}
		}

		public IEnumerable<StockList> GetStockListTest()
		{
			Data.StockList.Clear();
			foreach (StockList s in database.Table<StockList>())
			{
				Data.StockList.Add(s);
			}

			return Data.StockList;
		}

		public IEnumerable<SupplierList> GetSupplierListTest()
		{
			Data.SupplierList.Clear();
			foreach (SupplierList s in database.Table<SupplierList>())
			{
				Data.SupplierList.Add(s);
			}
				

			return Data.SupplierList;
			//lock (locker)
			//{
			//	return (from i in database.Table<SupplierList>() select i).ToList();
			//}
		}


		public IEnumerable<ItemsList> GetItemsListTest()
		{
			Data.ItemList.Clear();
			foreach (ItemsList s in database.Table<ItemsList>())
			{
				Data.ItemList.Add(s);
			}

			return Data.ItemList;
		}

		public IEnumerable<ListofItemList> GetListofItemsListTest()
		{
			Data.ListofItemList.Clear();
			foreach (ListofItemList s in database.Table<ListofItemList>())
			{
				Data.ListofItemList.Add(s);
			}

			return Data.ListofItemList;
		}

		public IEnumerable<OrderList> GetOrderListTest()
		{
			Data.OrderList.Clear();
			foreach (OrderList s in database.Table<OrderList>())
			{
				Data.OrderList.Add(s);
			}

			return Data.OrderList;
		}


		public IEnumerable<StockList> DeleteStock(DateTime date)
		{
			foreach (StockList s in database.Table<StockList>())
			{
				if (s.StockDate == date)
				{
					database.Delete(s); 
				}
			}

			return Data.StockList;
		}


		public IEnumerable<OrderList> DeleteOrder(DateTime date)
		{
			foreach (OrderList s in database.Table<OrderList>())
			{
				if (s.OrderTime == date)
				{
					database.Delete(s);
				}
			}

			return Data.OrderList;
		}

		public IEnumerable<ItemsList> DeleteItemList(int id)
		{
			foreach (ItemsList s in database.Table<ItemsList>())
			{
				if (s.ListID == id)
				{
					database.Delete(s);
				}
			}

			return Data.ItemList;
		}

		public IEnumerable<ListofItemList> DeleteListOfItemList(int id)
		{
			foreach (ListofItemList s in database.Table<ListofItemList>())
			{
				if (s.ID == id)
				{
					database.Delete(s);
				}
			}

			return Data.ListofItemList;
		}


		public IEnumerable<FeedBack> SaveFeedback()
		{
			foreach (FeedBack s in Data.feedBack)
			{
					database.Insert(s);
			}
			Data.feedBack.Clear();
			return Data.feedBack;

		}
	}
}
