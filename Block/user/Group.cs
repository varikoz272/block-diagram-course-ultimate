using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Block.user.level;

namespace Block.user
{
	public sealed class Group
	{
		protected string name;
		protected string password;
		protected List<Course> courses;
		protected List<User> joinedUsers;
		
		public Group(string name, string password) : this(name, password, new List<Course>()) { }
		
		
		public Group(string name, string password, Course course) : this(name, password)
		{
			courses.Add(course);
		}
		
		
		public Group(string name, string password, List<Course> courses)
		{
			this.name = name;
			this.password = password;
			this.courses = courses;
			joinedUsers = new List<User>();
		}
		
		public static Group GetTestGroup()
		{
			return new Group("Тест на как никак", "1488", Course.GetTestCourse());
		}
		
		public List<User> JoinedUsers
		{
			get {return joinedUsers;}
			set {joinedUsers = value;}
		}
	}
}
