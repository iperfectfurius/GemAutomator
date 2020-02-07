using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemAutomator.Clases.Gems
{
	class Poison : Gem
	{
		public Poison(int[] pos)
		{
			Name = "Poison";
			Pos = pos;
			Level = 0;
			Num = "{NUM3}";	
		}
	}
}
