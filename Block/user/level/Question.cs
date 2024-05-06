using System;
using System.Collections.Generic;

namespace Block.user.level
{
	public class Question
	{
		private string text;
		private List<Answer> answers;
		private Answer correctAnswer;
		
		public Question(string text, List<Answer> answers, int correctAnswerId)
		{
			this.text = text;
			this.answers = answers;
			this.correctAnswer = answers[correctAnswerId];
		}
		
		public Question(string question, List<Answer> answers) : this(question, answers, 0) { }
		
		public string Text
		{
			get {return text;}
			private set{text = value;}
		}
		
		public List<Answer> Answers
		{
			get {return answers;}
			private set {answers = value;}
		}
	}
}
