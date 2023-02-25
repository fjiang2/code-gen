using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencs.ClassBuilder
{
    public static class ByteCSharpCode
    {
        public static string ToByteArrayCode(this long d)
        {
            byte[] L = BitConverter.GetBytes(d);
            return ToByteArrayCode(L, 0, L.Length);
        }

        public static string ToByteArrayCode(this int d)
        {
            byte[] L = BitConverter.GetBytes(d);
            return ToByteArrayCode(L, 0, L.Length);
        }

        public static string ToByteArrayCode(this ushort d)
        {
            byte[] L = BitConverter.GetBytes(d);
            return ToByteArrayCode(L, 0, L.Length);
        }

        public static string ToByteArrayCode(this string text)
        {
            byte[] L = Encoding.UTF8.GetBytes(text);
            return ToByteArrayCode(L, 0, L.Length);
        }

        public static string ToByteArrayCode(this byte[] d, int offset, int count)
        {
            int index = 0;
            return toByteArrayCode(d, offset, count, x => $"0x{x:X2}", x => $"\t\t// [{index++:00}] = {x:000} \t" + toBinary1(x), 1);
        }

        public static string ToHexByteArrayCode(this byte[] d, int offset, int count)
        {
            return toByteArrayCode(d, offset, count, x => $"0x{x:X2}");
        }

        public static string ToDecByteArrayCode(this byte[] d, int offset, int count)
        {
            return toByteArrayCode(d, offset, count, x => $"{x}");
        }

        public static string ToBinaryByteArrayCode(this byte[] d, int offset, int count)
        {
            return toByteArrayCode(d, offset, count, toBinary2);
        }

        private static string toBinary1(byte b)
        {
            return Int32.Parse(Convert.ToString(b, 2)).ToString("0000 0000");
        }

        private static string toBinary2(byte b)
        {
            return Convert.ToString(b, 2).PadLeft(8, '0');
        }

        private static string toByteArrayCode(byte[] bytes, int offset, int count, Func<byte, string> fmt, Func<byte, string>? comment = null, int numberPerLine = 10)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"byte[] bytes = new byte[] \t\t// size = {bytes.Length}");
            builder.Append("{");
            int index = offset;
            while (index < bytes.Length && index + offset < count)
            {
                if (index % numberPerLine == 0)
                    builder.AppendLine().Append("\t");

                byte x = bytes[index];
                builder.Append(fmt(x));
                if (index < bytes.Length - 1)
                    builder.Append(", ");
                else
                    builder.Append("  ");

                if (comment != null)
                    builder.Append(comment(x));
                index++;
            }

            builder.AppendLine();
            builder.Append("};");
            builder.AppendLine();
            return builder.ToString();
        }
    }
}
