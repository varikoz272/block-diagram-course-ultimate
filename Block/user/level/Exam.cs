using System;
using System.Collections.Generic;

namespace Block.user.level
{
	public class Exam
	{
		private string name;
		private List<Theory> theoryNeeded;
		private List<Question> questions;
		
		public Exam(List<Theory> theoryNeeded,  List<Question> questions) : this ("Тест", theoryNeeded, questions) { }
		
		public Exam(string name, List<Theory> theoryNeeded,  List<Question> questions)
		{
			this.name = name;
			this.theoryNeeded = theoryNeeded;
			this.questions = questions;
		}
		
		public string Name
		{
			get {return name;}
			private set {name = value;}
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
