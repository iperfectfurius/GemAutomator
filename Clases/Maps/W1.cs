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
			Towers.Add(new Tower());
			Towers.Add(new Tower());
			Towers.Add(new Tower());
			Towers.Add(new Tower());
			Timer = 40;//40
			Finished = true;
			LoadTime = 11;
		}
	}
}
