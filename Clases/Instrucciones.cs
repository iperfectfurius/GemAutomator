using System;
using System.Collections.Generic;
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
			var simu = new InputSimulator();
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
	}
}
