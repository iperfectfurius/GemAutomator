using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemAutomator.Clases
{
	class Tower
	{
		private int id;
		private int x;
		private int y;
		private bool builded;

		public Tower(int x, int y, bool builded, int id)
		{
			this.x = x;
			this.y = y;
			this.builded = builded;
			this.Id = id;
		}
		public Tower(int x, int y, int id)
		{
			this.x = x;
			this.y = y;
			this.builded = false;
			this.Id = id;
		}
		public Tower()
		{}

		public int X { get => x; set => x = value; }
		public int Y { get => y; set => y = value; }
		public bool Builded { get => builded; set => builded = value; }
		public int Id { get => id; set => id = value; }
	}
}
