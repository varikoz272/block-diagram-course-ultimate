using System;

namespace Block.user.level
{
	public class Theory
	{
		private string title;
		private string text;
		
		public Theory(string title, string text)
		{
			this.title = title;
			this.text = text;
		}
		
		public string Title
		{
			get {return title;}
			private set {title = value;}
		}
		
		public string Text
		{
			get {return text;}
			private set {text = value;}
		}
	}
}
