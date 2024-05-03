using System;
using System.Collections.Generic;

namespace Block.user.level
{
	public class Course
	{
		private List<Exam> exams;
		
		public Course(List<Exam> exams)
		{
			this.exams = exams;
		}
		
		
		public static Course GetTestCourse() 
		{
			return null;
		}
		
		public List<Exam> Exams
		{
			get {return exams;}
			private set {exams = value;}
		}
	}
}
