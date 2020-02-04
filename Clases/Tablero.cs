﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

		private int[] startBattle = { 1481, 884 };
		private string espacio = " ";
		private int velocidad = 81;
		private string backspace = "{BS}";

		public string Espacio { get => espacio;}
		public int Velocidad { get => velocidad;}

		public void comenzarJuego(Timer load, Timer gameTime,int loadTime,int secs)
		{
			Cursor.Position = new Point(startBattle[0], startBattle[1]); //Set cursor to location 100, 150
			mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
			//Cursor.Clip = new Rectangle(this.Location, this.Size);
			load.Interval = loadTime * 1000;
			gameTime.Interval = secs * 1000;
			load.Enabled = true;	
			
		}
		public void juegoIniciado(Map m)
		{
			map = m;
			ejecutarInstrucciones();
		}

		private void ejecutarInstrucciones()
			
		{
			Form1.ejecutar("q");
		}

		public void finalizarJuego()
		{
			Form1.ejecutar(backspace);
		}
	}
}