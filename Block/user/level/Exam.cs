using System;
using System.Collections.Generic;

using Block.Algorithm;

namespace Block.user.level
{
	public class Exam : ISQLData
	{
		private int id;
		private string name;
		private List<Theory> theoryNeeded;
		private List<Question> questions;
		
		public Exam(List<Theory> theoryNeeded,  List<Question> questions) : this (0, "Тест", theoryNeeded, questions) { }
		
		public Exam(int id, string name, List<Theory> theoryNeeded,  List<Question> questions)
		{
			this.id = id;
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
		
		public int GetId()
		{
			return id;
		}
	}
}
