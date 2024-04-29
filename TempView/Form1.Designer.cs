namespace TempView
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			timer1 = new System.Windows.Forms.Timer(components);
			textBoxDebug = new TextBox();
			cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
			SuspendLayout();
			// 
			// timer1
			// 
			timer1.Interval = 1000;
			timer1.Tick += timer1_Tick;
			// 
			// textBoxDebug
			// 
			textBoxDebug.Location = new Point(489, 35);
			textBoxDebug.Multiline = true;
			textBoxDebug.Name = "textBoxDebug";
			textBoxDebug.Size = new Size(347, 457);
			textBoxDebug.TabIndex = 1;
			// 
			// cartesianChart1
			// 
			cartesianChart1.Location = new Point(12, 12);
			cartesianChart1.Name = "cartesianChart1";
			cartesianChart1.Size = new Size(471, 459);
			cartesianChart1.TabIndex = 2;
			cartesianChart1.Text = "cartesianChart1";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(888, 645);
			Controls.Add(cartesianChart1);
			Controls.Add(textBoxDebug);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Timer timer1;
		private TextBox textBoxDebug;
		private LiveCharts.WinForms.CartesianChart cartesianChart1;
	}
}
