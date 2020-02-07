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
		private int[] map_location;
		public string Name { get => name; set => name = value; }
		public int Default_towers { get => default_towers; set => default_towers = value; }
		public int Timer { get => timer; set => timer = value; }
		public bool Finished { get => finished; set => finished = value; }
		public int LoadTime { get => loadTime; set => loadTime = value; }
		public int[] Map_location { get => map_location; set => map_location = value; }
		internal List<Tower> Towers { get => towers; set => towers = value; }
		public List<Tower> getAllTowers()
		{
			List<Tower> temp = new List<Tower>();
			int count = 0;
			foreach(Tower t in towers)
			{
				temp.Add(t);
			}
			return temp;

		}
	}
}
