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
	
	class Program
	{

		static void Main(string[] args)
		{
			//DB Connection check
			//string tablenamelist;
			//for checking table list in Project_JJK database.
			Console.WriteLine("we will check table list using show tables command");
			Console.ReadLine();
			DB.Checktablelist();
			
			//creating table
			Console.Write("Please enter tablename to create table,excepting table list :");
			string tablename = Console.ReadLine();
			Console.WriteLine(tablename);
			DB.Addtable(tablename);


			
			Console.Write("please enter id :");
			string idvalue = Console.ReadLine();
			int Number = int.Parse(idvalue);
			Console.Write("please enter name :");
			string namevalue = Console.ReadLine();
			DB.Insertdata(Number, namevalue);
			Console.ReadLine();

						
	
		}
	}
}

			/*
			 * 0. 테이블 만든다.
			 * 1. 사용자의 입력을 받아. Console.ReadLine() 검색해봐
			 * 2. 값을 DB 에 쓴다.
			 * 3. 다시 1번으로 반복
			 * */
