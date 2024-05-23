/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 18.05.2024
 * Time: 16:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Block.form
{
	partial class JoinForm
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
			this.enterButton = new System.Windows.Forms.Button();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.nameLabel = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// enterButton
			// 
			this.enterButton.Location = new System.Drawing.Point(12, 109);
			this.enterButton.Name = "enterButton";
			this.enterButton.Size = new System.Drawing.Size(260, 23);
			this.enterButton.TabIndex = 9;
			this.enterButton.Text = "Вход";
			this.enterButton.UseVisualStyleBackColor = true;
			this.enterButton.Click += new System.EventHandler(this.EnterButtonClick);
			// 
			// passwordLabel
			// 
			this.passwordLabel.Location = new System.Drawing.Point(12, 57);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(100, 23);
			this.passwordLabel.TabIndex = 8;
			this.passwordLabel.Text = "Пороль";
			this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Location = new System.Drawing.Point(12, 83);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.Size = new System.Drawing.Size(260, 20);
			this.passwordTextBox.TabIndex = 7;
			// 
			// nameLabel
			// 
			this.nameLabel.Location = new System.Drawing.Point(12, 8);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(100, 23);
			this.nameLabel.TabIndex = 6;
			this.nameLabel.Text = "Имя";
			this.nameLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(12, 34);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(260, 20);
			this.nameTextBox.TabIndex = 5;
			// 
			// JoinForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 141);
			this.Controls.Add(this.enterButton);
			this.Controls.Add(this.passwordLabel);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.nameTextBox);
			this.Name = "JoinForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "JoinForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JoinFormFormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.Label passwordLabel;
		private System.Windows.Forms.Button enterButton;
	}
}
