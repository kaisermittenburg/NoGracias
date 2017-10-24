namespace NoGracias
{
	partial class MainMenuServer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button2 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(57, 69);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(102, 37);
			this.button2.TabIndex = 26;
			this.button2.Text = "Player";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(266, 177);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(661, 17);
			this.label5.TabIndex = 24;
			this.label5.Text = "Welcome";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(317, 274);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 17);
			this.label2.TabIndex = 21;
			this.label2.Text = "Port";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(317, 229);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(20, 17);
			this.label1.TabIndex = 20;
			this.label1.Text = "IP";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(376, 345);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(427, 22);
			this.textBox8.TabIndex = 18;
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(403, 274);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(427, 22);
			this.textBox7.TabIndex = 17;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(403, 224);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(427, 22);
			this.textBox6.TabIndex = 16;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(373, 325);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 17);
			this.label3.TabIndex = 27;
			this.label3.Text = "Status";
			// 
			// MainMenuServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(985, 551);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox8);
			this.Controls.Add(this.textBox7);
			this.Controls.Add(this.textBox6);
			this.Name = "MainMenuServer";
			this.Text = "MainMenuServer";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label3;
	}
}