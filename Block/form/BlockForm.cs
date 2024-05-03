using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Block.user;
using Block.user.level;
using Block.manage;

namespace Block.form
{
	public partial class BlockForm : Form
	{
		private CourseVisualizer visualizer;
		
		public BlockForm()
		{
			InitializeComponent();
			visualizer = new CourseVisualizer(coursePage);
		}
		
		private void BlockFormFormClosed(object sender, FormClosedEventArgs e)
		{
			TopManager.instance.disconnectDatabase();
			Application.ExitThread();
		}
		
		void RoundButton1Click(object sender, EventArgs e)
		{
			visualizer.Print(Course.GetTestCourse());
		}
	}
	
	internal sealed class CourseVisualizer
	{
		private static readonly int ELEMENT_D = 70;
		private static readonly int ELEMENT_R = ELEMENT_D / 2;
		
		private readonly TabPage field;
		private readonly int MIDDLE_X;
		private readonly int MIDDLE_Y;
		private readonly int OFFSET_X;
		private readonly int START_Y;
		
		public CourseVisualizer(TabPage page)
		{
			field = page;
			MIDDLE_X = page.Width / 2;
			MIDDLE_Y = page.Height / 2;
			OFFSET_X = MIDDLE_X / 4 + ELEMENT_D;
			START_Y = page.Height - (int) (ELEMENT_D * 1.5);
		}
		
		public void Print(Course course)
		{
			List<RoundButton> visualized = new List<RoundButton>();
			
			List<Exam> usedExams = new List<Exam>();
			List<Exam> unusedExams = new List<Exam>();
			foreach(var curExam in course.Exams)
				unusedExams.Add(curExam);
						
			List<Theory> theory = course.Theory;
			int i = 0;
			int layer = 0;
			while(i < theory.Count)
			{
				Exam examToPass = ExamToPass(unusedExams, theory, theory[i]);
				if (examToPass != null)
				{
					layer += 2;
					visualized.Add(GetExamRoundButton(
						examToPass.title,
						MIDDLE_X - ELEMENT_R,
						START_Y - (int) (ELEMENT_D * 1.2) * (layer / 2),
						examToPass
					));
					unusedExams.Remove(examToPass);
					usedExams.Add(examToPass);
					
					if (layer % 2 == 1) layer++;
					continue;
				}
				
				var curTheory = theory[i];
				
				visualized.Add(GetBasicRoundButton(
					curTheory.Title,
					MIDDLE_X + ((i % 2 == 0) ? OFFSET_X : -OFFSET_X) - ELEMENT_R,
					START_Y - (int) (ELEMENT_D * 1.2) * (layer++ / 2),
					curTheory.Text
				));
				
				i++;
			}
			i = 0;
			while (i < unusedExams.Count)
			{
				Exam examToPass = ExamToPass(unusedExams, theory, null);
				if (examToPass != null)
				{
					layer += 2;
					visualized.Add(GetExamRoundButton(
						examToPass.title,
						MIDDLE_X - ELEMENT_R,
						START_Y - (int) (ELEMENT_D * 1.2) * (layer / 2),
						examToPass
					));
					
					unusedExams.Remove(examToPass);
				}
				else i++;
			}
			
			foreach(var cur in visualized)
				field.Controls.Add(cur);
		}
		
		private static Exam ExamToPass(List<Exam> unusedExams, List<Theory> theory, Theory curTheory)
		{
			List<Theory> knownTheory = new List<Theory>();
			foreach(var cur in theory)
			{
				if (cur == curTheory) break;
				knownTheory.Add(cur);
			}
			
			foreach(var curUnusedExam in unusedExams)
			{
				bool allTheoryNeededIsRead = true;
				foreach(var cur in curUnusedExam.TheoryNeeded)
					if (!knownTheory.Contains(cur) || knownTheory.Count == 0)
					{
						allTheoryNeededIsRead = false;
						break;
					}
				
				if (allTheoryNeededIsRead)
					return curUnusedExam;
			}
			return null;
		}
		
		private static RoundButtonContext GetBasicRoundButton(string name, int x, int y, string context)
		{
			var button = new RoundButtonContext(new StringContext(context));
			
			button.Location = new System.Drawing.Point(x, y);
			button.Name = name;
			button.Size = new System.Drawing.Size(ELEMENT_D, ELEMENT_D);
			button.TabIndex = 0;
			button.Text = name;
			button.UseVisualStyleBackColor = true;
			button.Visible = true;
			
			return button;
		}
		
		private static RoundButtonContext GetExamRoundButton(string name, int x, int y, Exam exam)
		{
			var button = new RoundButtonContext(new FormContext(exam));
			button.Location = new System.Drawing.Point(x, y);
			button.Name = name;
			button.Size = new System.Drawing.Size(ELEMENT_D, ELEMENT_D);
			button.TabIndex = 0;
			button.Text = name;
			button.UseVisualStyleBackColor = true;
			button.Visible = true;
			
			return button;
		}
	}
}
