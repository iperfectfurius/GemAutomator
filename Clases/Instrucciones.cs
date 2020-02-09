using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace GemAutomator.Clases
{

	class Instrucciones
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
		//Mouse actions
		private const int MOUSEEVENTF_LEFTDOWN = 0x02;
		private const int MOUSEEVENTF_LEFTUP = 0x04;
		private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
		private const int MOUSEEVENTF_RIGHTUP = 0x10;
		private InputSimulator simu = new InputSimulator();

		private int velocidad;
		public void acelerar()
		{
			
		}
		public void pausar()
		{
			SendKeys.Send(" ");
		}
		public void finalizar()
		{

		}
		public void crearGema(Gem g)
		{
			simu.Keyboard.KeyPress(VirtualKeyCode.NUMPAD2);
		}
		public void colocarGema(Gem g,int[] pos)
		{

		}
		public void crearTorre(Tower t)
		{

		}
		public void crearTrampa(Trap t)
		{

		}
		public void vaciarTalisman()
		{
			Cursor.Position = new Point(1800, 168);
			Task.Delay(50).Wait();
			simu.Mouse.LeftButtonClick();
			Task.Delay(300).Wait();
			simu.Keyboard.KeyPress(VirtualKeyCode.VK_X);
			Task.Delay(40).Wait();
			Cursor.Position = new Point(1230, 750);
			for (int i = 0; i < 5; i++)
			{
				Task.Delay(50).Wait();
				simu.Mouse.LeftButtonClick();
				Task.Delay(50).Wait();
				Cursor.Position = new Point(Cursor.Position.X+110, 750);
				

			}
			Task.Delay(50).Wait();
			simu.Keyboard.KeyPress(VirtualKeyCode.BACK);
			Task.Delay(800).Wait();
		}
	}
}
