using System;
using System.Collections.Generic;

namespace UnitTestProject.Sample
{
	public partial class Device
	{
		public void Copy(Device obj)
		{
			this.Id = obj.Id;
			this.Name = obj.Name;
			this.Upper = obj.Upper;
			this.Lower = obj.Lower;
		}
		
		public Device Clone()
		{
			var obj = new Device();
			
			obj.Id = this.Id;
			obj.Name = this.Name;
			obj.Upper = this.Upper;
			obj.Lower = this.Lower;
			
			return obj;
		}
		
		public bool Compare(Device obj)
		{
			return this.Id.Equals(obj.Id)
			&& this.Name.Equals(obj.Name)
			&& this.Upper.Equals(obj.Upper)
			&& this.Lower.Equals(obj.Lower);
		}
		
		public override bool Equals(object obj)
		{
			var x = (Device)obj;
			
			return this.Id.Equals(x.Id)
			&& this.Name.Equals(x.Name)
			&& this.Upper.Equals(x.Upper)
			&& this.Lower.Equals(x.Lower);
		}
		
		public override int GetHashCode()
		{
			return 0;
		}
		
		public void Map(Device obj)
		{
			this.Id = obj.Id;
			this.Name = obj.Name;
			this.Upper = obj.Upper;
			this.Lower = obj.Lower;
		}
		
		public IDictionary<string, object> ToDictionary()
		{
			return new Dictionary<string, object>() 
			{
				["Id"] = this.Id,
				["Name"] = this.Name,
				["Upper"] = this.Upper,
				["Lower"] = this.Lower,
			};
		}
		
		public void FromDictinary(IDictionary<string, object> dictionary)
		{
			this.Id = (string)dictionary["Id"];
			this.Name = (string)dictionary["Name"];
			this.Upper = (int)dictionary["Upper"];
			this.Lower = (int)dictionary["Lower"];
		}
		
		public override string ToString()
		{
			return $"Id:{Id}, Name:{Name}, Upper:{Upper}, Lower:{Lower}";
		}
		
		public static Device Clone(Device from)
		{
			var obj = new Device();
			
			obj.Id = from.Id;
			obj.Name = from.Name;
			obj.Upper = from.Upper;
			obj.Lower = from.Lower;
			
			return obj;
		}
		
		public static bool Compare(Device a, Device b)
		{
			return a.Id == b.Id
			&& a.Name == b.Name
			&& a.Upper == b.Upper
			&& a.Lower == b.Lower;
		}
		
		public static void Copy(Device from, Device to)
		{
			to.Id = from.Id;
			to.Name = from.Name;
			to.Upper = from.Upper;
			to.Lower = from.Lower;
		}
		
		public static string ToString(Device obj)
		{
			return string.Format("{{Id:{0}, Name:{1}, Upper:{2}, Lower:{3}}}", 
			obj.Id, 
			obj.Name, 
			obj.Upper, 
			obj.Lower);
		}
	}
}