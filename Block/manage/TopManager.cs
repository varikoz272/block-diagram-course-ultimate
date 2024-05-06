using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Block.user;
using Block.user.level;

namespace Block.manage
{
	public sealed class TopManager
	{
		
		
		public static TopManager instance = new TopManager();
		
		private string dbConnectionQuery = @"Data Source=DESKTOP-DAQPCTH\SQLEXPRESS;Initial Catalog=database_306;Integrated Security=True";
		private static readonly string USER_TABLE_NAME = "user_";
		private static readonly string ROLE_TABLE_NAME = "role";
		private static readonly string COURSE_TABLE_NAME = "course";
		private static readonly string EXAM_TABLE_NAME = "exam";
		private static readonly string QUESTION_TABLE_NAME = "question";
		private static readonly string ANSWER_TABLE_NAME = "answer";
		private static readonly string THEORY_TABLE_NAME = "theory";
		
		private SqlConnection connection;
		
		private List<User> users;
		private List<Course> courses;
		
		private TopManager()
		{
			users = new List<User>();
			courses = new List<Course>();
//			connection = new SqlConnection(dbConnectionQuery);
		}
		
		public void disconnectDatabase()
		{
			//connection.Close();
		}
		
		public string DbConnectionQuery
		{
			get {return dbConnectionQuery;}
			private set {dbConnectionQuery = value;}
		}
		
	}
}
