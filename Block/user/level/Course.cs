using System;
using System.Collections.Generic;

using Block.Algorithm;
using Block.manage;

namespace Block.user.level
{
	public class Course : ISQLData
	{
		protected int id;
		protected string name;
		protected string password;
		protected List<Exam> exams;
		protected List<User> joinedUsers;
		
		public Course(int id, string name, string password, List<Exam> exams)
		{
			this.id = id;
			this.name = name;
			this.password = password;
			this.exams = exams;
			joinedUsers = new List<User>();
		}
		
		public List<Exam> Exams
		{
			get {return exams;}
			set {exams = value;}
		}
		
		public List<User> JoinedUsers
		{
			get {return joinedUsers;}
			private set {joinedUsers = value;}
		}
		
		public string Name
		{
			get {return name;}
			private set {name = value;}
		}
		
		public string Password
		{
			get {return password;}
			private set {password = value;}
		}
		
		public int GetId()
		{
			return id;
		}
	}
}
