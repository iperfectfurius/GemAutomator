using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemAutomator.Clases.Maps
{
	class W1 : Map
	{
		public W1()
		{
			Name = "W1";
			Default_towers = 5;
			Towers.Add(new Tower());
			Towers.Add(new Tower(750,792,2,"Tower"));
			Towers.Add(new Tower());
			Towers.Add(new Tower(834,261,4,"Tower"));
			Towers.Add(new Tower(1171,233,5,"Tower"));
			//Towers.Add(new Trap());
			Timer = 20;//40
			Finished = true;
			LoadTime = 11;
			Map_location = new int[]{960,540};		
		}
	}
}
