using System;
using System.Collections.Generic;

namespace Block.user.level
{
	public class Answer
	{
		private string text;
		
		public Answer(string text)
		{
			this.text = text;
		}
		
		public string Text
		{
			get {return text;}
			private set {text = value;}
		}
	}
}
