using System;
using System.Drawing;
using System.Windows.Forms;

using Block.manage;

namespace Block.form
{
	public partial class JoinForm : Form
	{
		public JoinForm()
		{
			InitializeComponent();
		}
		
		void EnterButtonClick(object sender, EventArgs e)
		{
			try
			{
				TopManager.instance.JoinCourse(
					TopManager.instance.activeUser,
					nameTextBox.Text,
					passwordTextBox.Text
				);
				
				Dispose();
			}
			
			catch (JoinException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void JoinFormFormClosed(object sender, FormClosedEventArgs e)
		{
			Hide();
		}
	}
}
