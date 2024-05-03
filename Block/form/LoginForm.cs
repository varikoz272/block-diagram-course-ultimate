using System;
using System.Drawing;
using System.Windows.Forms;
using Block.manage;

namespace Block.form
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}
		
		private void LoginFormFormClosed(object sender, FormClosedEventArgs e)
		{
			Hide();
		}
		
		private LoginInfo GetInput(Button pressed)
		{
			string name = nameTextBox.Text;
			string password = passwordTextBox.Text;
			
			if (pressed == loginButton)
				return new LoginInfo(name, password, Input.Login);
			
			if (pressed == registrationButton)
				return new LoginInfo(name, password, Input.Registration);
			
			return null;
		}
		
		private void ComeBack(LoginInfo info)
		{
			if (info.name.Equals("")) return;
			if (info.password.Equals("")) return;
			Dispose();
			new BlockForm().Show();
		}
		
		private void LoginButtonClick(object sender, EventArgs e)
		{
			ComeBack(GetInput((Button) sender));
		}
		
		private void RegistrationButtonClick(object sender, EventArgs e)
		{
			ComeBack(GetInput((Button) sender));
		}
		
		void LoginFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason.Equals(CloseReason.UserClosing))
				Application.Exit();
		}
	}
	
	internal enum Input
	{
		Login,
		Registration,
	}
	
	internal class LoginInfo
	{
		public string name;
		public string password;
		public Input input;
		
		public LoginInfo(string name, string password, Input input)
		{
			this.name = name;
			this.password = password;
			this.input = input;
		}
	}
}
