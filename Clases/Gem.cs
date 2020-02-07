using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemAutomator.Clases
{
	class Gem
	{
		private string name;
		private int[] pos;
		private int level;
		private string num;
		public Gem(string name, int[] pos, int level)
		{
			this.name = name;
			this.pos = pos;
			this.Level = level;
		}
		public Gem()
		{}
		public string Name { get => name; set => name = value; }
		public int[] Pos { get => pos; set => pos = value; }
		public int Level { get => level; set => level = value; }
		public string Num { get => num; set => num = value; }
	}
}
