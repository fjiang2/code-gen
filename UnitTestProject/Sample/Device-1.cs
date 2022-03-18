
namespace UnitTestProject.Sample
{
	public partial class Device
	{
		public bool Compare(Device obj)
		{
			return this.Id.Equals(obj.Id)
			&& this.Name.Equals(obj.Name)
			&& this.Upper.Equals(obj.Upper)
			&& this.Lower.Equals(obj.Lower);
		}
		
		public void Copy(Device obj)
		{
			this.Id = obj.Id;
			this.Name = obj.Name;
			this.Upper = obj.Upper;
			this.Lower = obj.Lower;
		}
		
		public override string ToString()
		{
			return $"Id:{Id}, Name:{Name}, Upper:{Upper}, Lower:{Lower}";
		}
	}
}