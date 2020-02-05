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
		private string type;

		public Tower(int x, int y, bool builded, int id, string type)
		{
			this.x = x;
			this.y = y;
			this.builded = builded;
			this.Id = id;
			this.type = type;
		}
		public Tower(int x, int y, int id, string type)
		{
			this.x = x;
			this.y = y;
			this.builded = false;
			this.Id = id;
			this.type = type;
		}
		public Tower()
		{
			Type = "Tower";
		}

		public int X { get => x; set => x = value; }
		public int Y { get => y; set => y = value; }
		public bool Builded { get => builded; set => builded = value; }
		public int Id { get => id; set => id = value; }
		public string Type { get => type; set => type = value; }
	}
}
