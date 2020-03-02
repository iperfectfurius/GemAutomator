using GemAutomator.Clases;
using GemAutomator.Clases.Maps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace GemAutomator
{
	public partial class Form1 : Form
	{

		private Tablero tablero = new Tablero();
		private List<Map> maps = new List<Map>();
		private Map map_selected;
		private static Form2 f2;
		public Form1()
		{
			InitializeComponent();
			addAllMaps();
			showMaps();
			actualizaciones();
		}

		private void actualizaciones()
		{
			var client = new RestClient("http://81.203.8.151/GemAutomator/version.php");
			var request = new RestRequest();
			string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			request.AddParameter("version", version);
			var response = client.Post(request);
			dynamic s = JObject.Parse(response.Content);
			if (s.message != "Actualizado")
				label2.Text = "Actualización disponible!";
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
			iniciar();

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
		public void iniciar()
		{
			Thread thread = new Thread(() =>
			{
				f2 = new Form2();
				f2.Show();
				f2.TopMost = true;
				f2.obtainData(this, map_selected);
				Application.Run(f2);
			});
			thread.ApartmentState = ApartmentState.STA;
			thread.Start();
			tablero.comenzarJuego(timer2, timer1, map_selected.LoadTime, map_selected.Timer);
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			Console.WriteLine("juego finalizado");
			timer1.Stop();
			tablero.finalizarJuego();
			finalizar();
			Task.Delay(5000).Wait();
			if (checkBox1.Checked)
			{
				if (CaptureMyScreen())
				{
					tablero.emptyTalisman();
					//f2.timer4.Start();
				}

				//Task.Delay(3000).Wait();
				//Task.Delay(8000).ContinueWith(t => f2.obtainData(this, map_selected));
				tablero.seleccionarMapa();
				//Thread.Sleep(1000);
				Task.Delay(1000).Wait();
				tablero.comenzarJuego(timer2, timer1, map_selected.LoadTime, map_selected.Timer - 5);
				/*Task.Delay(8000).ContinueWith(t => tablero.seleccionarMapa());
				Task.Delay(9000).ContinueWith(t => tablero.comenzarJuego(timer2, timer1, map_selected.LoadTime, map_selected.Timer));*/
			}
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			timer1.Start();
			timer2.Stop();
			tablero.juegoIniciado(map_selected);
			//Console.WriteLine("segundo timer t2");
			//this.WindowState = FormWindowState.Normal;


		}
		public static void ejecutar(string comando)
		{
			SendKeys.Send(comando);
		}
		public static void ejecutar(string[] comando)
		{
			foreach (string s in comando)
				SendKeys.Send(s);
		}
		public static void juegoIniciado(string comando)
		{

		}
		private void finalizar()
		{
			this.WindowState = FormWindowState.Normal;
		}
		//-----------------------Data----------------------//
		public List<string> getData()
		{
			List<string> temp = new List<string>();
			foreach (Control c in this.Controls)
			{
				Console.WriteLine(c);
				if (c is GroupBox)
				{
					foreach (Control c2 in c.Controls)
					{
						if (c2 is CheckBox)
						{
							if (checkBox1.Checked)
								temp.Add(c2.Text);
						}
					}
				}
			}
			return temp;
		}

		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private bool CaptureMyScreen()
		{
			bool fullFrags = false;
			try
			{
				Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format24bppRgb);
				Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
				Graphics captureGraphics = Graphics.FromImage(captureBitmap);
				captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

				Bitmap shadowCores = new Bitmap(245, 50, PixelFormat.Format24bppRgb);
				if (checkBox2.Checked)
				{	
					shadowCores = captureBitmap.Clone(new Rectangle(1646, 970, 230, 40), shadowCores.PixelFormat);
					//shadow_cores.Save("prueba.png",ImageFormat.Png);
					sendShadowCores(shadowCores);
				}

				Color pixel = captureBitmap.GetPixel(1652, 165);
				Console.WriteLine(pixel);
				if (pixel.R > 220)
					fullFrags = true;
				captureBitmap.Dispose();
				captureGraphics.Dispose();
				shadowCores.Dispose();
			}

			catch (Exception ex)
			{
				MessageBox.Show("Algo falla... " + ex);
				Console.WriteLine(ex);
			}
			return fullFrags;
		}
		private void sendShadowCores(Bitmap img)
		{
			MemoryStream imageInMemory = new MemoryStream();
			img.Save(imageInMemory, ImageFormat.Png);
			

			var client = new RestClient("http://81.203.8.151/GemAutomator/");
			var request = new RestRequest();

			imageInMemory.Position = 0;
			request.AddFile("img", imageInMemory.ToArray(), "a.png");
	

			client.PostAsync(request, (a, b) => {});
			imageInMemory.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			//sendShadowCores();
			CaptureMyScreen();
		}
	}
}
