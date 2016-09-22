using System;
using SQLite;

namespace project2
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}
