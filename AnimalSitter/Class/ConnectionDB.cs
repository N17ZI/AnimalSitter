using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSitter.Class
{
	public class ConnectionDB
	{
		public static int current_id;
		public static AnimalSitterDBEntities2 AnimalSittersEntities = new AnimalSitterDBEntities2();
	}
}
