using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Block.user
{
	public abstract class User
	{
		private string name;
		private string password;
		
		public User(string name, string password)
		{
			this.name = name;
			this.password = password;
		}
		
		public string Name
		{
			get { return name; }
			protected set { name = value; }
		}
		
		public string Password
		{
			get { return password; }
			protected set { password = value; }
		}
		
		protected abstract bool IsAvaibleToChat();
		
		protected abstract bool IsAvaibleToMakeGroups();
		
		protected abstract bool IsAvaibleToKickMembers();
		protected abstract bool IsAvaibleToAddMembers();
		
		protected abstract bool IsAvaibleToCreateUsers();
		protected abstract bool IsAvaibleToDeleteUsers();
	}
}
