﻿using System;
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
		private string dbConnectionQuery = @"Data Source=DESKTOP-DAQPCTH\SQLEXPRESS;Initial Catalog=kurs3;Integrated Security=True";
		
		private SqlTableManager SQLManager;
		
		public User activeUser;
		private List<User> users;
		private List<Course> courses;
		private int curCourseId;
		
		private TopManager()
		{
			users = new List<User>();
			courses = new List<Course>();
			curCourseId = 0;
			
			var connection = new SqlConnection(dbConnectionQuery);
			connection.Open();
			SQLManager = new SqlTableManager(connection);
		}
		
		public void disconnectDatabase()
		{
			SQLManager.CloseConnection();
		}
		
		public Course CurrentCourse
		{
			get
			{
				List<Course> userCourses = GetCoursesWithUser(TopManager.instance.activeUser);
				return (userCourses.Count == 0) ? null : userCourses[curCourseId % userCourses.Count];
			}
		}
		
		public Course NextCourse
		{
			get
			{
				curCourseId++;
				List<Course> userCourses = GetCoursesWithUser(TopManager.instance.activeUser);
				return (userCourses.Count == 0) ? null : userCourses[curCourseId % userCourses.Count];
			}
		}
		
		public void JoinCourse(User user, string courseName, string coursePassword)
		{
			SQLManager.JoinCourse(user, courseName, coursePassword);
		}
		
		public void LeaveCourse(User user, Course course)
		{
			SQLManager.LeaveCourse(user, course);
		}
		
		public void RegisterUser(string name, string password)
		{
			SQLManager.AddRow(
				SqlTableManager.USER_TABLE,
				new string[] { "id", "name", "role_name", "password" },
				new string[] { SQLManager.GetFreeId(SqlTableManager.USER_TABLE).ToString(), name, "Student", password }
			);
		}
		
		public void Update()
		{
			users = SQLManager.GetUsers();
			courses = SQLManager.GetCourses(users);
		}
		
		public string DbConnectionQuery
		{
			get {return dbConnectionQuery;}
			private set {dbConnectionQuery = value;}
		}
		
		public User GetUserByName(string name)
		{
			foreach (User curUser in users)
				if (curUser.Name.Equals(name)) return curUser;
			return null;
		}
		
		public List<Course> GetCoursesWithUser(User user)
		{
			List<Course> userCourses = new List<Course>();
			foreach (Course curCourse in courses)
				if (curCourse.JoinedUsers.Contains(activeUser))
					userCourses.Add(curCourse);
			
			return userCourses;
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
	
	public class JoinException : Exception
	{
		public JoinException(string message) : base(message) {}
	}
	
	public class LeaveException : Exception
	{
		public LeaveException(string message) : base(message) {}
	}
}
