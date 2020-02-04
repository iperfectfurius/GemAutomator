using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemAutomator.Clases
{
	class Map
	{
		private string name;
		private int default_towers;
		private int timer;
		private List<Tower> towers = new List<Tower>();
		private bool finished;
		private int loadTime;
		public string Name { get => name; set => name = value; }
		public int Default_towers { get => default_towers; set => default_towers = value; }
		public int Timer { get => timer; set => timer = value; }
		public bool Finished { get => finished; set => finished = value; }
		public int LoadTime { get => loadTime; set => loadTime = value; }
		internal List<Tower> Towers { get => towers; set => towers = value; }
		public string[][] getAllTowers()
		{
			string[][] temp = new string[towers.Count][];
			int count = 0;
			foreach(Tower t in towers)
			{
				//temp[count][0] = t.X;
			}
			return temp;

		}
	}
}
