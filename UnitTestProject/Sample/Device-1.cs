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
            this.Time = obj.Time;
            this.Exists = obj.Exists;
            this.Length = obj.Length;
            this.Weight = obj.Weight;
        }

        public Device Clone()
        {
            var obj = new Device();

            obj.Id = this.Id;
            obj.Name = this.Name;
            obj.Time = this.Time;
            obj.Exists = this.Exists;
            obj.Length = this.Length;
            obj.Weight = this.Weight;

            return obj;
        }

        public bool Compare(Device obj)
        {
            return this.Id.Equals(obj.Id)
            && this.Name.Equals(obj.Name)
            && this.Time.Equals(obj.Time)
            && this.Exists.Equals(obj.Exists)
            && this.Length.Equals(obj.Length)
            && this.Weight.Equals(obj.Weight);
        }

        public override bool Equals(object obj)
        {
            var x = (Device)obj;

            return this.Id.Equals(x.Id)
            && this.Name.Equals(x.Name)
            && this.Time.Equals(x.Time)
            && this.Exists.Equals(x.Exists)
            && this.Length.Equals(x.Length)
            && this.Weight.Equals(x.Weight);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public void Map(Device obj)
        {
            this.Id = obj.Id;
            this.Name = obj.Name;
            this.Time = obj.Time;
            this.Exists = obj.Exists;
            this.Length = obj.Length;
            this.Weight = obj.Weight;
        }

        public IDictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>()
            {
                ["Id"] = this.Id,
                ["Name"] = this.Name,
                ["Time"] = this.Time,
                ["Exists"] = this.Exists,
                ["Length"] = this.Length,
                ["Weight"] = this.Weight,
            };
        }

        public void FromDictionary(IDictionary<string, object> dictionary)
        {
            this.Id = (int)dictionary["Id"];
            this.Name = (string)dictionary["Name"];
            this.Time = (DateTime)dictionary["Time"];
            this.Exists = (bool)dictionary["Exists"];
            this.Length = (int)dictionary["Length"];
            this.Weight = (double)dictionary["Weight"];
        }

        public string ToJson()
        {
            return "{"
            + $"\"Id\":{Id}"
            + ","
            + $"\"Name\":\"{Name}\""
            + ","
            + $"\"Time\":\"{Time.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\""
            + ","
            + $"\"Exists\":{Exists.ToString().ToLower()}"
            + ","
            + $"\"Length\":{Length}"
            + ","
            + $"\"Weight\":{Weight}"
            + "}";
        }

        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Time:{Time}, Exists:{Exists}, Length:{Length}, Weight:{Weight}";
        }

        public static Device Clone(Device from)
        {
            var obj = new Device();

            obj.Id = from.Id;
            obj.Name = from.Name;
            obj.Time = from.Time;
            obj.Exists = from.Exists;
            obj.Length = from.Length;
            obj.Weight = from.Weight;

            return obj;
        }

        public static bool CompareTo(Device a, Device b)
        {
            return a.Id == b.Id
            && a.Name == b.Name
            && a.Time == b.Time
            && a.Exists == b.Exists
            && a.Length == b.Length
            && a.Weight == b.Weight;
        }

        public static void CopyTo(Device from, Device to)
        {
            to.Id = from.Id;
            to.Name = from.Name;
            to.Time = from.Time;
            to.Exists = from.Exists;
            to.Length = from.Length;
            to.Weight = from.Weight;
        }

        public static string ToSimpleString(Device obj)
        {
            return string.Format("{{Id:{0}, Name:{1}, Time:{2}, Exists:{3}, Length:{4}, Weight:{5}}}",
            obj.Id,
            obj.Name,
            obj.Time,
            obj.Exists,
            obj.Length,
            obj.Weight);
        }
    }
}