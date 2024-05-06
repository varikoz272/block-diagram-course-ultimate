using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Block.user;
using Block.user.level;
using Block.manage;
using Block.Algorithm;

namespace Block.form
{
	public partial class BlockForm : Form
	{
		private CourseVisualizer visualizer;
		private int prevY = 9;
		
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
			trackBar.Value = trackBar.Maximum;
			prevY = trackBar.Maximum;
		}

		void TrackBarScroll(object sender, EventArgs e)
		{
			int offset = visualizer.GetMinMaxY().s / 10;
			visualizer.MoveAllY((trackBar.Value - prevY) * offset);
			prevY = trackBar.Value;
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
		
		private IntPairCache maxMinYCache;
		
		public CourseVisualizer(TabPage page)
		{
			field = page;
			MIDDLE_X = page.Width / 2;
			MIDDLE_Y = page.Height / 2;
			OFFSET_X = MIDDLE_X / 4 + ELEMENT_D;
			START_Y = page.Height - (int) (ELEMENT_D * 1.5);
		}
		
		public IntPairCache GetMinMaxY()
		{
			if (maxMinYCache != null) return maxMinYCache;
			
			maxMinYCache = new IntPairCache(field.Controls[0].Location.Y, field.Controls[0].Location.Y);
			
			foreach(Control curControl in field.Controls)
			{
				if (curControl.Location.Y < maxMinYCache.f) maxMinYCache.f = curControl.Location.Y;
				if (curControl.Location.Y > maxMinYCache.s) maxMinYCache.s = curControl.Location.Y;
			}
			
			return maxMinYCache;
		}
		
		public void MoveAllY(int yOffset)
		{
			foreach(Control curControl in field.Controls)
				if (!(curControl.Name.Equals("trackBar")))
					curControl.Top += yOffset;
		}
		
		public void Print(Course course)
		{
			List<RoundButton> visualized = new List<RoundButton>();
			
			int startUnwrapPosition = 0;
			
			foreach (Exam curExam in course.Exams)
			{
				List<RoundButton> unwrapedTheory = UnwrapExam(curExam, startUnwrapPosition);
				RoundButton examButton = GetExamRoundButton(
					GetButtonMiddlePlacement(curExam.TheoryNeeded.Count + 2 + startUnwrapPosition, MIDDLE_X),
					curExam
				);
				
				foreach(var curControl in unwrapedTheory)
					field.Controls.Add(curControl);
				field.Controls.Add(examButton);
				
				startUnwrapPosition += curExam.TheoryNeeded.Count + 5;
				startUnwrapPosition -= startUnwrapPosition % 2;
			}
			
			maxMinYCache = null;
		}
		
		private List<RoundButton> UnwrapExam(Exam exam, int startUnwrapPosition)
		{
			List<RoundButton> unwraped = new List<RoundButton>();
			
			for (int i = 0; i < exam.TheoryNeeded.Count; i++)
				unwraped.Add(GetBasicRoundButton(
					exam.TheoryNeeded[i].Title,
					GetButtonPlacement(i + startUnwrapPosition, MIDDLE_X, exam.TheoryNeeded.Count + startUnwrapPosition),
					exam.TheoryNeeded[i].Text
				));
			
			return unwraped;
		}
		
		
		private static Point GetButtonPlacement(int id, int middleX, int maxId)
		{
			if (id + 1 >= maxId && id % 2 == (maxId - 1) % 2) return GetButtonMiddlePlacement(id, middleX);
			return new Point(((id % 2) * 2 - 1) * ELEMENT_D + middleX - ELEMENT_R, id / 2 * ELEMENT_D + id / 2 * ELEMENT_R / 4);
		}
		
		private static Point GetButtonMiddlePlacement(int id, int middleX)
		{
			return new Point(middleX - ELEMENT_R, id / 2 * ELEMENT_D + id / 2 * ELEMENT_R / 4);
		}
		
		private static RoundButtonContext GetBasicRoundButton(string name, Point location, string context)
		{
			var button = new RoundButtonContext(new StringContext(name, context));
			
			button.Location = location;
			button.Name = name;
			button.Size = new System.Drawing.Size(ELEMENT_D, ELEMENT_D);
			button.TabIndex = 0;
			button.Text = name;
			button.UseVisualStyleBackColor = true;
			button.Visible = true;
			
			return button;
		}
		
		private static RoundButtonContext GetExamRoundButton(Point location, Exam exam)
		{
			var button = new RoundButtonContext(new FormContext(exam.Name, exam));
			button.Location = location;
			button.Name = exam.Name;
			button.Size = new System.Drawing.Size(ELEMENT_D, ELEMENT_D);
			button.TabIndex = 0;
			button.Text = exam.Name;
			button.UseVisualStyleBackColor = true;
			button.Visible = true;
			
			return button;
		}
		
	}
}
