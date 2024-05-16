using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Collections;

using System.Windows.Forms;

using Block.user;
using Block.manage;
using Block.user.level;
using Block.Algorithm;

namespace Block.manage.SQL
{
	public class SqlTableManager
	{
		private SqlConnection connection;
		
		private static readonly string USER_TABLE = "users";
		private static readonly string USER_COURSES_TABLE = "user_courses";
		private static readonly string COURSE_TABLE = "course";
		private static readonly string COURSE_EXAMS_TABLE = "course_exams";
		private static readonly string EXAM_TABLE = "exam";
		private static readonly string NEEDED_THEORY_TABLE = "needed_theory";
		private static readonly string THEORY_TABLE = "theory";
		private static readonly string EXAM_QUESTIONS_TABLE = "exam_questions";
		private static readonly string QUESTION_TABLE = "question";
		private static readonly string QUESTION_ANSWERS_TABLE = "question_answers";
		private static readonly string ANSWER_TABLE = "answer";

		public List<User> GetUsers()
		{
			DataTable userTable = new DataTable();
			new SqlDataAdapter("SELECT * FROM " + USER_TABLE, connection).Fill(userTable);
			
			List<User> users = new List<User>();
			foreach (DataRow curRow in userTable.Rows)
				users.Add(GetUser(curRow));
			
			return users;
		}
		
		private User GetUser(DataRow row)
		{
			if (row["role_name"].Equals("Student"))
				return new Student(row["name"].ToString(), row["password"].ToString());
			if (row["role_name"].Equals("Tutor"))
				return new Tutor(row["name"].ToString(), row["password"].ToString());
			if (row["role_name"].Equals("Admin"))
				return new Admin(row["name"].ToString(), row["password"].ToString());
			return null;
		}
		
		public List<Course> GetCourses()
		{
			DataTable courseTable = new DataTable();
			new SqlDataAdapter("SELECT * FROM " + COURSE_TABLE, connection).Fill(courseTable);
			List<Course> courses = new List<Course>();
			
			DataTable courseExamsTable = new DataTable();
			new SqlDataAdapter("SELECT * FROM " + COURSE_EXAMS_TABLE, connection).Fill(courseExamsTable);
			
			DataTable examTable = new DataTable();
			new SqlDataAdapter("SELECT * FROM " + EXAM_TABLE, connection).Fill(examTable);
			List<Exam> exams = new List<Exam>();
			
			DataTable theoryTable = new DataTable();
			new SqlDataAdapter("SELECT * FROM " + THEORY_TABLE, connection).Fill(theoryTable);
			List<Theory> theory= new List<Theory>();
			
			DataTable neededTheoryTable = new DataTable();
			new SqlDataAdapter("SELECT * FROM " + NEEDED_THEORY_TABLE, connection).Fill(neededTheoryTable);
			
			
			foreach (DataRow curExam in examTable.Rows)
				exams.Add(new Exam((int) curExam["id"], curExam["name"].ToString(), new List<Theory>(), new List<Question>()));
			
			foreach (DataRow curCourse in courseTable.Rows)
				courses.Add(new Course((int) curCourse["id"], curCourse["name"].ToString(), curCourse["password"].ToString(), new List<Exam>()));
			
			foreach (DataRow curConnect in courseExamsTable.Rows)
			{
				Course curCourse = (Course) GetObjectById((int) curConnect["course_id"], courses);
				Exam curExam = (Exam) GetObjectById((int) curConnect["exam_id"], exams);
				curCourse.Exams.Add(curExam);
			}
			
			foreach (DataRow curTheory in theoryTable.Rows)
				theory.Add(new Theory((int) curTheory["id"], curTheory["name"].ToString(), curTheory["text"].ToString()));
			
			foreach (DataRow curConnect in neededTheoryTable.Rows)
			{
				Exam curExam = (Exam) GetObjectById((int) curConnect["exam_id"], exams);
				Theory curTheory = (Theory) GetObjectById((int) curConnect["theory_id"], theory);
				MessageBox.Show(curExam.Name + " " + curTheory.Name); //
				curExam.TheoryNeeded.Add(curTheory);
			}
			
			return courses;
		}
		
		private static object GetObjectById(int id, List<Course> list) // List<ISQLData>
		{
			foreach (var el in list)
				if (el.GetId() == id) return el;
			return null;
		}
		
		private static object GetObjectById(int id, List<Exam> list) // List<ISQLData>
		{
			foreach (var el in list)
				if (el.GetId() == id) return el;
			return null;
		}
		
		private static object GetObjectById(int id, List<Theory> list) // List<ISQLData>
		{
			foreach (var el in list)
				if (el.GetId() == id) return el;
			return null;
		}
		
		public SqlTableManager(SqlConnection connection)
		{
			this.connection = connection;
		}
		
		
		public DataTable GetTable(string tableName)
		{
			string query = "SELECT * FROM " + tableName;
			SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
			DataTable table = new DataTable();
			dataAdapter.Fill(table);

			return table;
		}
		
		

		public void CloseConnection()
		{
			connection.Close();
		}
	}

}
