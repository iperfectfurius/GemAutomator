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
		private bool autofarming;
		private List<string> options = new List<string>();
		private Map map;

		public int Time { get => time; set => time = value; }

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
			Time = m.Timer;
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
			if (Time > 0)
			{
				Time--;
				label1.Text = Time.ToString();
			}
			else if (Time > -7&&autofarming)
			{
				label1.Text = "Reiniciando Partida....";
			}
			else
			{
				timer1.Enabled = false;
				timer2.Start();
				timer3.Start();
				time = map.Timer;
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
	}
}
