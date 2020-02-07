using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GemAutomator.Clases.Gems;
using WindowsInput.Native;
using WindowsInput;

namespace GemAutomator.Clases
{
	 class Tablero
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
		//Mouse actions
		private const int MOUSEEVENTF_LEFTDOWN = 0x02;
		private const int MOUSEEVENTF_LEFTUP = 0x04;
		private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
		private const int MOUSEEVENTF_RIGHTUP = 0x10;
		private Map map = new Map();
		private Instrucciones ins = new Instrucciones();

		private int[] startBattle = { 1481, 884 };
		private string espacio = " ";
		private int velocidad = 81;
		private string backspace = "{BS}";
		private int[,] gemTable = new int[,]
		//------1-------------2-------------3-------
		{ { 1768, 490 },{ 1825, 597 }, {1884, 602 },
		//------4----------5------------6-----------
		{ 1772,538 },{ 1825,538 },{ 1884,538 },
		//----7------------8------------9------------
		{ 1772,490 },{ 1825,490 },{ 1884,490 } };

		public string Espacio { get => espacio;}
		public int Velocidad { get => velocidad;}
		public int[,] GemTable { get => gemTable;}

		public void comenzarJuego(Timer load, Timer gameTime,int loadTime,int secs)
		{
			Cursor.Position = new Point(startBattle[0], startBattle[1]); //Set cursor to location 100, 150
			load.Interval = loadTime * 1000;
			gameTime.Interval = secs * 1000;
			load.Start();                                                //Thread.Sleep(20);
			Task.Delay(30).Wait();
			mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
			//Cursor.Clip = new Rectangle(this.Location, this.Size);
			
			Console.WriteLine("juego comenzado");
			
		}
		public void juegoIniciado(Map m)
		{
			Console.WriteLine("juego iniciado");
			map = m;
			ejecutarInstrucciones();
			//ins = new Instrucciones();
		}

		private void ejecutarInstrucciones()
		{

			Form1.ejecutar("q");
			Form1.ejecutar("q");
			Console.WriteLine("partida empezada velocidad");
			var simu = new InputSimulator();
			int rondas = 6;
			
			foreach (Tower t in map.getAllTowers())
			{

				//Cursor.Position = new Point(t.X, t.Y); //Set cursor to location 100, 150
				if (t.Y != 0)
				{
					ins.crearGema(new Poison(new int[] { GemTable[0, 0], GemTable[0, 1] }));
					Task.Delay(40).Wait();
					Cursor.Position = new Point(t.X, t.Y);
					Task.Delay(40).Wait();
					 simu.Mouse.LeftButtonClick();
					Task.Delay(40).Wait();
					simu.Keyboard.KeyPress(VirtualKeyCode.VK_U);
					Task.Delay(40).Wait();
					simu.Keyboard.KeyPress(VirtualKeyCode.VK_U);
					Task.Delay(40).Wait();	
					
					
					
					//mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
					Console.WriteLine("click");
				}
			}

			for (int i = 0; i < rondas; i++)
			{
				Task.Delay(300).Wait();
				simu.Keyboard.KeyPress(VirtualKeyCode.VK_N);
			}
		}

		public void finalizarJuego()
		{
			Form1.ejecutar(backspace);
		}
		public void seleccionarMapa()
		{

			Cursor.Position = new Point(map.Map_location[0], map.Map_location[1]);
			mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);


			
		}
	}
}
