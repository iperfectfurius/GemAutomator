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
		private int gameTime;
		private int loadTime;
		private bool autofarming;
		private List<string> options = new List<string>();
		private Map map;

		public int GameTime { get => gameTime; set => gameTime = value; }

		public Form2()
		{
			InitializeComponent();
		}

		private void Form2_Load(object sender, EventArgs e)
		{

		}
		internal void obtainData(Form1 f1, Map m)
		{
			options = f1.getData();
			map = m;
			if (f1.checkBox1.Checked)
				autofarming = true;
			printData();
			label3.Text += m.Name;
			gameTime = m.Timer;
			loadTime = m.LoadTime;
			timer3.Interval = (m.LoadTime*1000)-1500;
			timer3.Start();
		}
		private void printData()
		{
			foreach (string s in options)
			{
				label2.Text += s;
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer2.Enabled = false;
			if (gameTime > 0)
			{
				gameTime--;
				label1.Text = gameTime.ToString();
			}
			else if (gameTime > -7&&autofarming)
			{
				label1.Text = "Reiniciando Partida....";
				gameTime--;
			}
			else
			{
				timer1.Enabled = false;
				timer2.Start();
				timer3.Interval = (loadTime-7) * 1000;
				timer3.Start();
				gameTime = map.Timer;
			}
			
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

		private void timer3_Tick(object sender, EventArgs e)
		{
			timer3.Stop();
			timer1.Start();
		}

		private void timer4_Tick(object sender, EventArgs e)
		{
			Console.WriteLine("se me ha activado bro");
		}
	}
}
