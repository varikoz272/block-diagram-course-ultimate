using System;
using System.Drawing;
using System.Windows.Forms;

namespace Block.form
{

	public partial class OpeningForm : Form
	{
		public OpeningForm()
		{
			InitializeComponent();
			prepareTimer.Start();
		}
		
		private void Prepare()
		{
			prepareTimer.Stop();
			new LoginForm().Show();
			Hide();
		}
		
		void PrepareTimerTick(object sender, EventArgs e)
		{
			Prepare();
		}
	}
}
