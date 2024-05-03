using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Block.user
{

	public enum Action
	{
		CreateUser,
		DeleteCreatedUser,
		DeleteUser,
		
		CreateGroup,
		DeleteCreatedGroup,
		DeleteGroup,
		
		Chat,
		DeleteMessage,
	}
}
