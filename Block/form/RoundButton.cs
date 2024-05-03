using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using Block.user.level;

namespace Block.form
{
	public class RoundButton : Button
	{
		protected override void OnPaint(PaintEventArgs pevent)
		{
			GraphicsPath gp = new GraphicsPath();
			gp.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
			Region = new System.Drawing.Region(gp);
			base.OnPaint(pevent);
		}
	}
	
	public class RoundButtonContext : RoundButton
	{
		private Context context;
		
		public RoundButtonContext(Context context)
		{
			this.context = context;
			Click += OnClick;
		}
		
		public Context Context
		{
			get {return context;}
			private set {context = value;}
		}
		
		public void OnClick(object sender, EventArgs e)
		{
			context.GetMessage();
		}
	}
}
