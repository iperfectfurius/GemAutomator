using GemAutomator.Clases;
using GemAutomator.Clases.Maps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GemAutomator
{
	public partial class Form1 : Form
	{
		
		private Tablero tablero = new Tablero();
		private List<Map> maps = new List<Map>();
		private Map map_selected;
		private Form2 f2 = new Form2();
		public Form1()
		{	
			InitializeComponent();
			addAllMaps();
			showMaps();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
		//-----------------------Carga de formulario---------------------//
		private void addAllMaps()//Añadimos todos los mapas en nuestra lista
		{
			maps.Add(new W1());
			maps.Add(new W2());
		}
		private void showMaps()//Mostramos los mapas disponibles 
		{
			foreach (Map m in maps)
			{
				if (m.Finished)
					comboBox1.Items.Add(m.Name);
			}
			comboBox1.SelectedIndex = 0;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			//this.TopMost = true;
			//this.WindowState = FormWindowState.Minimized;
			f2.Show();
			f2.obtainData(this,map_selected);		
			tablero.comenzarJuego(timer2,timer1, map_selected.LoadTime,map_selected.Timer);
		}
		

		private void selected(object sender, EventArgs e)
		{
			foreach (Map m in maps)
			{
				if (m.Finished && m.Name == comboBox1.SelectedItem.ToString())
					map_selected = m;
			}
		}

		//----------------------Juego-------------------------//
		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Enabled = false;
			tablero.finalizarJuego();
			finalizar();
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			timer1.Enabled = true;
			timer2.Enabled = false;
			tablero.juegoIniciado(map_selected);
			f2.timer1.Enabled = true;
			//this.WindowState = FormWindowState.Normal;
			

		}
		public  static void ejecutar(string comando)
		{
			SendKeys.Send(comando);
		}
		public static void ejecutar(string[] comando)
		{
			foreach(string s in comando)
				SendKeys.Send(s);
		}
		private void finalizar()
		{
			this.WindowState = FormWindowState.Normal;
		}
		//-----------------------Data----------------------//
		public List<string> getData()
		{
			List<string> temp = new List<string>();
			foreach(Control c in this.Controls)
			{
				Console.WriteLine(c);
				if(c is GroupBox)
				{
					foreach(Control c2 in c.Controls)
					{
						if(c2 is CheckBox)
						{
							temp.Add(c2.Text);
						}
					}
				}
			}
			return temp;
		}
	}
}
