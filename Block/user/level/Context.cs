using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;

using Block.user;
using System.Runtime.InteropServices;

namespace Block.user.level
{
	public abstract class Context
	{
		protected static readonly Size BUTTON_SIZE = new Size(40, 40);
		protected static readonly Size ELEMENT_SIZE = new Size(30, 30);
		protected static readonly int SCREEN_WIDTH = Screen.PrimaryScreen.Bounds.Width;
		protected static readonly int SCREEN_HEIGHT = Screen.PrimaryScreen.Bounds.Height;
	
		protected string title;
	
		protected Context(string title)
		{
			this.title = title;
		}
		
		public abstract void GetMessage();
		
		public string Title
		{
			get {return title;}
			private set{title = value;}
		}
	}
	
	public class StringContext : Context
	{
		private string text;
		
		public StringContext(string title, string text) : base(title)
		{
			this.text = text;
		}
		
		public override void GetMessage()
		{
			MessageBox.Show(text);
		}
		
		public string Text
		{
			get {return text;}
			private set {text = value;}
		}
	}
	
	public class FormContext : Context
	{
		private static readonly int FORM_WIDTH = 500;
		private static readonly int FORM_HEIGHT = 500;
		
		private Exam exam;
		private int curQuestionId;
		
		public FormContext(string title, Exam exam) : base(title)
		{
			this.exam = exam;
			curQuestionId = 0;
		}
		
		public override void GetMessage()
		{
			List<Answer> answers = exam.Questions[curQuestionId].Answers;
			Form questionForm = new Form();
			questionForm.Size = new Size(FORM_WIDTH, FORM_HEIGHT);
			questionForm.StartPosition = FormStartPosition.CenterScreen;
			questionForm.Visible = true;
			
			addQuestionLabel(questionForm.Controls, exam.Questions[curQuestionId].Text);
			
			for (int i = 0; i < answers.Count; i++)
				addAnswerLabel(questionForm.Controls, answers[i].Text, i);
			
			addControlButtons(questionForm.Controls, this, questionForm, curQuestionId, exam.Questions.Count);
		}
		
		private static void addControlButtons(Control.ControlCollection controls, FormContext formHolder, Form form, int curIndex, int maxIndex)
		{
			Button[] controlButtons = new Button[2];
			
			controlButtons[0] = new Button();
			controlButtons[0].Text = ">";
			controlButtons[0].Size = BUTTON_SIZE;
			controlButtons[0].Location = new Point(FORM_WIDTH - (int)(BUTTON_SIZE.Width * 1.5), FORM_HEIGHT - BUTTON_SIZE.Height * 2);
			if (curIndex < maxIndex - 1)
				controlButtons[0].Click += (sender, e) => {
				formHolder.curQuestionId++;
				form.Close();
				formHolder.GetMessage();
			};
			
			controlButtons[1] = new Button();
			controlButtons[1].Text = "<";
			controlButtons[1].Size = BUTTON_SIZE;
			controlButtons[1].Location = new Point(0, FORM_HEIGHT - BUTTON_SIZE.Height * 2);
			if (curIndex > 0)
			controlButtons[1].Click += (sender, e) => {
				formHolder.curQuestionId--;
				form.Close();
				formHolder.GetMessage();
			};
			
			
			foreach(var curControl in controlButtons)
				controls.Add(curControl);
		}
		
		private static void addQuestionLabel(Control.ControlCollection controls, string text)
		{
			Label questionLabel = new Label();
			questionLabel.Text = text;
			questionLabel.Location = new Point(ELEMENT_SIZE.Width / 2, ELEMENT_SIZE.Height / 2);
			questionLabel.Size = new Size(FORM_WIDTH, questionLabel.PreferredHeight);
			controls.Add(questionLabel);
		}
		
		private static void addAnswerLabel(Control.ControlCollection controls, string text, int id)
		{
			Label answerLabel = new Label();
			answerLabel.Text = text;
			answerLabel.Location = new Point(ELEMENT_SIZE.Width / 2, id * ELEMENT_SIZE.Height + ELEMENT_SIZE.Height * 2);
			answerLabel.Size = new Size(FORM_WIDTH, answerLabel.PreferredHeight);
			controls.Add(answerLabel);
		}
	}
}
