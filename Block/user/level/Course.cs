using System;
using System.Collections.Generic;

namespace Block.user.level
{
	public class Course
	{
		protected string title;
		protected string password;
		protected List<Exam> exams;
		protected List<User> joinedUsers;
		
		public Course(List<Exam> exams)
		{
			this.exams = exams;
		}
		
		public List<Exam> Exams
		{
			get {return exams;}
			private set {exams = value;}
		}
		
		public List<User> JoinedUsers
		{
			get {return joinedUsers;}
			private set {joinedUsers = value;}
		}
		
		public string Title
		{
			get {return title;}
			private set {title = value;}
		}
		
		public string Password
		{
			get {return password;}
			private set {password = value;}
		}
		
		public static Course GetTestCourse()
		{
			List<Theory> theory = new List<Theory>();
			theory.Add(new Theory("урок первый", "чтобы открыть пеинт нажмине на пеинт"));
			theory.Add(new Theory("урок ворой", "чтобы закрыть закройте"));
			theory.Add(new Theory("финальный урок", "чконец"));
			
			List<Answer> answers = new List<Answer>();
			answers.Add(new Answer("никак"));
			answers.Add(new Answer("открыть"));
			answers.Add(new Answer("закрыть"));
			
			List<Question> questions = new List<Question>();
			questions.Add(new Question("как закрыть пеинт", answers, 2));
			questions.Add(new Question("как закрыть пеинт", answers, 1));
			
			List<Exam> exams = new List<Exam>();
			exams.Add(new Exam(theory, questions));
			exams.Add(new Exam(theory, questions));
			exams.Add(new Exam(theory, questions));
			exams.Add(new Exam(theory, questions));
			exams.Add(new Exam(theory, questions));
			exams.Add(new Exam(theory, questions));
			
			return new Course(exams);
		}
	}
}
