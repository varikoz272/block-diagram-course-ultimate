/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 10.04.2024
 * Time: 11:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Block.form
{
	partial class LoginForm
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
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.nameLabel = new System.Windows.Forms.Label();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.loginButton = new System.Windows.Forms.Button();
			this.registrationButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(12, 42);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(260, 20);
			this.nameTextBox.TabIndex = 0;
			// 
			// nameLabel
			// 
			this.nameLabel.Location = new System.Drawing.Point(12, 16);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(100, 23);
			this.nameLabel.TabIndex = 1;
			this.nameLabel.Text = "Имя";
			this.nameLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// passwordLabel
			// 
			this.passwordLabel.Location = new System.Drawing.Point(12, 65);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(100, 23);
			this.passwordLabel.TabIndex = 3;
			this.passwordLabel.Text = "Пороль";
			this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Location = new System.Drawing.Point(12, 91);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.Size = new System.Drawing.Size(260, 20);
			this.passwordTextBox.TabIndex = 2;
			// 
			// loginButton
			// 
			this.loginButton.Location = new System.Drawing.Point(12, 117);
			this.loginButton.Name = "loginButton";
			this.loginButton.Size = new System.Drawing.Size(260, 23);
			this.loginButton.TabIndex = 4;
			this.loginButton.Text = "Вход";
			this.loginButton.UseVisualStyleBackColor = true;
			this.loginButton.Click += new System.EventHandler(this.LoginButtonClick);
			// 
			// registrationButton
			// 
			this.registrationButton.Location = new System.Drawing.Point(12, 146);
			this.registrationButton.Name = "registrationButton";
			this.registrationButton.Size = new System.Drawing.Size(260, 23);
			this.registrationButton.TabIndex = 5;
			this.registrationButton.Text = "Регистрация";
			this.registrationButton.UseVisualStyleBackColor = true;
			this.registrationButton.Click += new System.EventHandler(this.RegistrationButtonClick);
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 180);
			this.Controls.Add(this.registrationButton);
			this.Controls.Add(this.loginButton);
			this.Controls.Add(this.passwordLabel);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.nameTextBox);
			this.Name = "LoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LoginForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginFormFormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginFormFormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button registrationButton;
		private System.Windows.Forms.Button loginButton;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.Label passwordLabel;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.TextBox nameTextBox;
	}
}
