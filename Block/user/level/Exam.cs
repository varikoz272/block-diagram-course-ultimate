using System;
using System.Collections.Generic;

namespace Block.user.level
{
	public class Exam
	{
		public string title = "ТЕСТ";
		private List<Theory> theoryNeeded;
		private List<Question> questions;
		
		public Exam(List<Theory> theoryNeeded,  List<Question> questions)
		{
			this.theoryNeeded = theoryNeeded;
			this.questions = questions;
		}
		
		public List<Theory> TheoryNeeded
		{
			get {return theoryNeeded;}
			private set {theoryNeeded = value;}
		}
		
		public List<Question> Questions
		{
			get {return questions;}
			private set {questions = value;}
		}
	}
}
