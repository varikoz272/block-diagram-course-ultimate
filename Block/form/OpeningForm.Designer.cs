/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 10.04.2024
 * Time: 11:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Block.form
{
	partial class OpeningForm
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
			this.components = new System.ComponentModel.Container();
			this.prepareTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// prepareTimer
			// 
			this.prepareTimer.Interval = 1000;
			this.prepareTimer.Tick += new System.EventHandler(this.PrepareTimerTick);
			// 
			// OpeningForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "OpeningForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "OpeningForm";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Timer prepareTimer;
	}
}
