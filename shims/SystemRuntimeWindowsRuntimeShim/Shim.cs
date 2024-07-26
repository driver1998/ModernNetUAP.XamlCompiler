using System;
using System.Runtime.CompilerServices;
[assembly: TypeForwardedToAttribute(typeof(Windows.Foundation.Size))]
[assembly: TypeForwardedToAttribute(typeof(Windows.Foundation.Rect))]
[assembly: TypeForwardedToAttribute(typeof(Windows.Foundation.Point))]

namespace Windows.UI
{
    public struct Color : IFormattable
    {
        public byte A { get; set; }
        public byte B { get; set; }
        public byte G { get; set; }
        public byte R { get; set; }
        public static Color FromArgb(byte a, byte r, byte g, byte b) => throw new NotImplementedException();
        public override bool Equals(object o) => throw new NotImplementedException();
        public bool Equals(Color color) => throw new NotImplementedException();
        public override int GetHashCode() => throw new NotImplementedException();
        public override string ToString() => throw new NotImplementedException();
        public static bool operator ==(Color color1, Color color2) => throw new NotImplementedException();
        public static bool operator !=(Color color1, Color color2) => throw new NotImplementedException();
        string IFormattable.ToString(string format, IFormatProvider formatProvider) => throw new NotImplementedException();
        public string ToString(IFormatProvider formatProvider) => throw new NotImplementedException();
    }
}