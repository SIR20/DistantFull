using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistantFull
{
    public static class Extension
    {
        public static byte[] GetBytes(this string self) => Encoding.UTF8.GetBytes(self);
        public static string GetString(this byte[] self) => Encoding.UTF8.GetString(self);
        public static int Parse(this string self) => int.Parse(self);
    }
}
