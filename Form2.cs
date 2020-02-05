using GemAutomator.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GemAutomator
{
	public partial class Form2 : Form
	{
		private int time;
		private List<string> options = new List<string>();
		public Form2()
		{
			InitializeComponent();
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			
		}
		internal void obtainData(Form1 f1,Map m)
		{
			options = f1.getData();
			printData();
			label3.Text += m.Name;
			time = m.Timer;
		}
		private void printData()
		{
			foreach(string s in options)
			{
				label2.Text += s;
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer2.Enabled = false;
			if (time > 0)
				time--;
			else
				timer1.Enabled = false;
			label1.Text = time.ToString();
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			if (label1.Text.Contains("..."))
			{
				label1.Text = "Cargando";
			}
			else
			{
				label1.Text += '.';
			}
		}
	}
}
