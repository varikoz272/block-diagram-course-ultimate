using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Block.user;
using Block.user.level;
using Block.manage.SQL;

namespace Block.manage
{
	public sealed class TopManager
	{
		public static TopManager instance = new TopManager();
		//DESKTOP-DAQPCTH\SQLEXPRESS ноут
		//DESKTOP-8UOLSK2\SQLEXPRESS комп
		private string dbConnectionQuery = @"Data Source=DESKTOP-8UOLSK2\SQLEXPRESS;Initial Catalog=kurs3;Integrated Security=True";
		
		private SqlTableManager SQLManager;
		
		private List<User> users;
		private List<Course> courses;
		
		private TopManager()
		{
			users = new List<User>();
			courses = new List<Course>();
			
			var connection = new SqlConnection(dbConnectionQuery);
			connection.Open();
			SQLManager = new SqlTableManager(connection);
			
			Update();
		}
		
		public void disconnectDatabase()
		{
			SQLManager.CloseConnection();
		}
		
		public void Update()
		{
			users = SQLManager.GetUsers();
			courses = SQLManager.GetCourses();
		}
		
		public string DbConnectionQuery
		{
			get {return dbConnectionQuery;}
			private set {dbConnectionQuery = value;}
		}
		
		public List<User> Users
		{
			get {return users;}
			private set {users = value;}
		}
		
		public List<Course> Courses
		{
			get {return courses;}
			private set {courses = value;}
		}
	}
	
	public enum AvaibleRoles
	{
		Student,
		Tutor,
		Admin,
	}
}
