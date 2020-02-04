using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemAutomator.Clases.Maps
{
	class W2 : Map
	{

		public W2()
		{
			Name = "W2";
			Default_towers = 6;
			Towers.Add(new Tower());
			Towers.Add(new Tower());
			Towers.Add(new Tower());
			Towers.Add(new Tower());
			Towers.Add(new Tower());
			Timer = 60;
			Finished = false;
		}
	}
}
