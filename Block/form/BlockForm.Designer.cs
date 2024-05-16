using System.Windows.Forms;
namespace Block.form
{
	partial class BlockForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.pageControl = new System.Windows.Forms.TabControl();
			this.coursePage = new System.Windows.Forms.TabPage();
			this.button1 = new System.Windows.Forms.Button();
			this.trackBar = new System.Windows.Forms.TrackBar();
			this.roundButton1 = new Block.form.RoundButton();
			this.profilePage = new System.Windows.Forms.TabPage();
			this.settingsPage = new System.Windows.Forms.TabPage();
			this.pageControl.SuspendLayout();
			this.coursePage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
			this.SuspendLayout();
			// 
			// pageControl
			// 
			this.pageControl.Controls.Add(this.coursePage);
			this.pageControl.Controls.Add(this.profilePage);
			this.pageControl.Controls.Add(this.settingsPage);
			this.pageControl.Location = new System.Drawing.Point(0, 0);
			this.pageControl.Name = "pageControl";
			this.pageControl.SelectedIndex = 0;
			this.pageControl.Size = new System.Drawing.Size(585, 561);
			this.pageControl.TabIndex = 1;
			// 
			// coursePage
			// 
			this.coursePage.Controls.Add(this.button1);
			this.coursePage.Controls.Add(this.trackBar);
			this.coursePage.Controls.Add(this.roundButton1);
			this.coursePage.Location = new System.Drawing.Point(4, 22);
			this.coursePage.Name = "coursePage";
			this.coursePage.Padding = new System.Windows.Forms.Padding(3);
			this.coursePage.Size = new System.Drawing.Size(577, 535);
			this.coursePage.TabIndex = 1;
			this.coursePage.Text = "Курс";
			this.coursePage.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(48, 110);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(249, 225);
			this.button1.TabIndex = 3;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// trackBar
			// 
			this.trackBar.LargeChange = 1;
			this.trackBar.Location = new System.Drawing.Point(532, 0);
			this.trackBar.Maximum = 9;
			this.trackBar.Name = "trackBar";
			this.trackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBar.Size = new System.Drawing.Size(45, 535);
			this.trackBar.TabIndex = 2;
			this.trackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.trackBar.Value = 9;
			this.trackBar.Scroll += new System.EventHandler(this.TrackBarScroll);
			// 
			// roundButton1
			// 
			this.roundButton1.Location = new System.Drawing.Point(8, 6);
			this.roundButton1.Name = "roundButton1";
			this.roundButton1.Size = new System.Drawing.Size(72, 58);
			this.roundButton1.TabIndex = 0;
			this.roundButton1.Text = "roundButton1";
			this.roundButton1.UseVisualStyleBackColor = true;
			this.roundButton1.Click += new System.EventHandler(this.RoundButton1Click);
			// 
			// profilePage
			// 
			this.profilePage.Location = new System.Drawing.Point(4, 22);
			this.profilePage.Name = "profilePage";
			this.profilePage.Padding = new System.Windows.Forms.Padding(3);
			this.profilePage.Size = new System.Drawing.Size(577, 535);
			this.profilePage.TabIndex = 0;
			this.profilePage.Text = "Профиль";
			this.profilePage.UseVisualStyleBackColor = true;
			// 
			// settingsPage
			// 
			this.settingsPage.Location = new System.Drawing.Point(4, 22);
			this.settingsPage.Name = "settingsPage";
			this.settingsPage.Size = new System.Drawing.Size(577, 535);
			this.settingsPage.TabIndex = 2;
			this.settingsPage.Text = "Настройки";
			this.settingsPage.UseVisualStyleBackColor = true;
			// 
			// BlockForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 561);
			this.Controls.Add(this.pageControl);
			this.Name = "BlockForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BlockForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BlockFormFormClosed);
			this.pageControl.ResumeLayout(false);
			this.coursePage.ResumeLayout(false);
			this.coursePage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
			this.ResumeLayout(false);

		}
		private Block.form.RoundButton roundButton1;
		private System.Windows.Forms.TabPage settingsPage;
		private System.Windows.Forms.TabPage coursePage;
		private System.Windows.Forms.TabPage profilePage;
		private System.Windows.Forms.TabControl pageControl;
		private System.Windows.Forms.TrackBar trackBar;
		private System.Windows.Forms.Button button1;
	}
}
