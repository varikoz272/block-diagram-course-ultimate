using System;
using System.Collections.Generic;

namespace Block.user.level
{
	public class Question
	{
		private string text;
		private List<Answer> answers;
		private QuestionAnswering type;
		
		public Question(string text, List<Answer> answers, QuestionAnswering type)
		{
			this.text = text;
			this.answers = answers;
			this.type = type;
		}
		
		public Question(string question, List<Answer> answers) : this(question, answers, QuestionAnswering.Single)
		{
			
		}
		
		public string Text
		{
			get {return text;}
			private set{text = value;}
		}
		
		public List<Answer> Answers
		{
			get {return answers;}
			set{answers = value;}
		}
	}
	
	public enum QuestionAnswering
	{
		Single,
		Multiple,
	}
}
