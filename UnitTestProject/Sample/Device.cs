using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Sample
{
	public partial class Device
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Time { get; set; }
		public bool Exists { get; set; }
		public int Length { get; set; }
		public double Weight { get; set; }
	}
}
