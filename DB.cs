using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace MysqlDBTest
{
	public static class DB
	{
		static string _connectionString;
		static MySqlConnection Conn; 
		static DB()
		{
			
			MySqlConnectionStringBuilder connBuilder = new MySqlConnectionStringBuilder();
			connBuilder.Add("Database", "Project_JJK");
			connBuilder.Add("Data Source", "hellojkw.com");
			connBuilder.Add("User Id", "uj7380");
			connBuilder.Add("Password", "uj7380");

			_connectionString = connBuilder.ToString();
			Conn = new MySqlConnection(_connectionString);
		}
		

		public static void Addtable(string tablename)
		{
			int a=0;
			try
			{
				Conn.Open();
				string create = string.Format("CREATE TABLE {0} (myId INT PRIMARY KEY, myName CHAR(50))", tablename);
				MySqlCommand cmd = new MySqlCommand(create, Conn);
				cmd.Parameters.AddWithValue("@tablename", tablename);
				cmd.ExecuteNonQuery();
				Console.WriteLine("success for create + {0}", tablename);
				Console.ReadLine();
				Console.WriteLine("press enter key to continue ");
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				Conn.Close();
			}
		}

		  public static void Insertdata(int id,string name)
		{
		try	  
		{
			Conn.Open();
			string insertsql = string.Format("INSERT INTO eunjin VALUES (@id, @name)",id, name);
			MySqlCommand myCommand = new MySqlCommand(insertsql,Conn);
			myCommand.Parameters.AddWithValue("@id", id);
			myCommand.Parameters.AddWithValue("@name", name);
			myCommand.ExecuteNonQuery();
		  }
			  catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				Conn.Close();
			}
		}

		
		  public static void Checktablelist()
		  {
			try	  
				{
				
					Conn.Open();
					string showcm = string.Format("SHOW TABLES");
					MySqlCommand showtable = new MySqlCommand(showcm, Conn);
					MySqlDataReader Reader;
					Reader = showtable.ExecuteReader();
				while (Reader.Read())
						{
							int i = 0;
							string row;
							row=Reader.GetValue(0).ToString();
							
				    //row = Reader.GetValue(i).ToString();
							Console.WriteLine(row);
							i++;				  
						}
				}
			catch(Exception e)
				{
					Console.WriteLine(e.Message);
				}
			finally
				{	
					Conn.Close();
				}
			
}


		}

	}



