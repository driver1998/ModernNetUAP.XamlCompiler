using System;

namespace Windows.UI.Xaml
{
    public struct Thickness
    {
        public double Left { get; set; }
        public double Top { get; set; }
        public double Right { get; set; }
        public double Bottom { get; set; }
        public Thickness(double uniformLength) => throw new NotImplementedException();
        public Thickness(double left, double top, double right, double bottom) => throw new NotImplementedException();
        public override string ToString() => throw new NotImplementedException();
        public override bool Equals(object obj) => throw new NotImplementedException();
        public bool Equals(Thickness thickness) => throw new NotImplementedException();
        public override int GetHashCode() => throw new NotImplementedException();
        public static bool operator ==(Thickness t1, Thickness t2) => throw new NotImplementedException();
        public static bool operator !=(Thickness t1, Thickness t2) => throw new NotImplementedException();
    }
    public struct GridLength
    {
        public double Value { get; }
        public GridUnitType GridUnitType { get; }
        public bool IsAbsolute { get; }
        public bool IsAuto { get; }
        public bool IsStar { get; }
        public static GridLength Auto { get; }
        public GridLength(double pixels) => throw new NotImplementedException();
        public GridLength(double value, GridUnitType type) => throw new NotImplementedException();
        public static bool operator ==(GridLength gl1, GridLength gl2) => throw new NotImplementedException();
        public static bool operator !=(GridLength gl1, GridLength gl2) => throw new NotImplementedException();
        public override bool Equals(object oCompare) => throw new NotImplementedException();
        public bool Equals(GridLength gridLength) => throw new NotImplementedException();
        public override int GetHashCode() => throw new NotImplementedException();
        public override string ToString() => throw new NotImplementedException();
    }
    public enum GridUnitType
    {
        Auto,
        Pixel,
        Star
    }
    public struct CornerRadius
    {
        public double TopLeft { get; set; }
        public double TopRightt { get; set; }
        public double BottomRightt { get; set; }
        public double BottomLeftt { get; set; }
        public CornerRadius(double uniformRadius) => throw new NotImplementedException();
        public CornerRadius(double topLeft, double topRight, double bottomRight, double bottomLeft) => throw new NotImplementedException();
        public override string ToString() => throw new NotImplementedException();
        public override bool Equals(object obj) => throw new NotImplementedException();
        public bool Equals(CornerRadius cornerRadius) => throw new NotImplementedException();
        public override int GetHashCode() => throw new NotImplementedException();
        public static bool operator ==(CornerRadius cr1, CornerRadius cr2) => throw new NotImplementedException();
        public static bool operator !=(CornerRadius cr1, CornerRadius cr2) => throw new NotImplementedException();
    }
    public struct Duration
    {
        public bool HasTimeSpan { get; }
        public static Duration Automatic { get; }
        public static Duration Forever { get; }
        public TimeSpan TimeSpan { get; }
        public Duration(TimeSpan timeSpan) => throw new NotImplementedException();
        public static implicit operator Duration(TimeSpan timeSpan) => throw new NotImplementedException();
        public static Duration operator +(Duration t1, Duration t2) => throw new NotImplementedException();
        public static Duration operator -(Duration t1, Duration t2) => throw new NotImplementedException();
        public static bool operator ==(Duration t1, Duration t2) => throw new NotImplementedException();
        public static bool operator !=(Duration t1, Duration t2) => throw new NotImplementedException();
        public static bool operator >(Duration t1, Duration t2) => throw new NotImplementedException();
        public static bool operator >=(Duration t1, Duration t2) => throw new NotImplementedException();
        public static bool operator <(Duration t1, Duration t2) => throw new NotImplementedException();
        public static bool operator <=(Duration t1, Duration t2) => throw new NotImplementedException();
        public static int Compare(Duration t1, Duration t2) => throw new NotImplementedException();
        public static Duration operator +(Duration duration) => throw new NotImplementedException();
        public Duration Add(Duration duration) => throw new NotImplementedException();
        public override bool Equals(object value) => throw new NotImplementedException();
        public bool Equals(Duration duration) => throw new NotImplementedException();
        public static bool Equals(Duration t1, Duration t2) => throw new NotImplementedException();
        public override int GetHashCode() => throw new NotImplementedException();
        public Duration Subtract(Duration duration) => throw new NotImplementedException();
        public override string ToString() => throw new NotImplementedException();
    }
    public enum DurationType
    {
        Automatic,
        TimeSpan,
        Forever
    }
    namespace Media
    {
        public struct Matrix : IFormattable
        {
            public double M11 { get; set; }
            public double M12 { get; set; }
            public double M21 { get; set; }
            public double M22 { get; set; }
            public double OffsetX { get; set; }
            public double OffsetY { get; set; }
            public static Matrix Identity { get; }
            public bool IsIdentity { get; }
            public Matrix(double m11, double m12, double m21, double m22, double offsetX, double offsetY) => throw new NotImplementedException();
            public override string ToString() => throw new NotImplementedException();
            public string ToString(IFormatProvider provider) => throw new NotImplementedException();
            string IFormattable.ToString(string format, IFormatProvider provider) => throw new NotImplementedException();
            public object Transform(object point) => throw new NotImplementedException();
            public T Transform<T>(T point) => throw new NotImplementedException();
            public override int GetHashCode() => throw new NotImplementedException();
            public override bool Equals(object o) => throw new NotImplementedException();
            public bool Equals(Matrix value) => throw new NotImplementedException();
            public static bool operator ==(Matrix matrix1, Matrix matrix2) => throw new NotImplementedException();
            public static bool operator !=(Matrix matrix1, Matrix matrix2) => throw new NotImplementedException();
        }
        namespace Animation
        {
            public struct KeyTime
            {
                public TimeSpan TimeSpan { get; }
                public static KeyTime FromTimeSpan(TimeSpan timeSpan) => throw new NotImplementedException();
                public static bool Equals(KeyTime keyTime1, KeyTime keyTime2) => throw new NotImplementedException();
                public static bool operator ==(KeyTime keyTime1, KeyTime keyTime2) => throw new NotImplementedException();
                public static bool operator !=(KeyTime keyTime1, KeyTime keyTime2) => throw new NotImplementedException();
                public bool Equals(KeyTime value) => throw new NotImplementedException();
                public override bool Equals(object value) => throw new NotImplementedException();
                public override int GetHashCode() => throw new NotImplementedException();
                public override string ToString() => throw new NotImplementedException();
                public static implicit operator KeyTime(TimeSpan timeSpan) => throw new NotImplementedException();
            }
            public struct RepeatBehavior : IFormattable
            {
                public static RepeatBehavior Forever { get; }
                public bool HasCount { get; }
                public bool HasDuration { get; }
                public double Count { get; set; }
                public TimeSpan Duration { get; set; }
                public RepeatBehaviorType Type { get; set; }
                public RepeatBehavior(double count) => throw new NotImplementedException();
                public RepeatBehavior(TimeSpan duration) => throw new NotImplementedException();
                public override string ToString() => throw new NotImplementedException();
                public string ToString(IFormatProvider formatProvider) => throw new NotImplementedException();
                string IFormattable.ToString(string format, IFormatProvider formatProvider) => throw new NotImplementedException();
                public override bool Equals(object value) => throw new NotImplementedException();
                public bool Equals(RepeatBehavior repeatBehavior) => throw new NotImplementedException();
                public static bool Equals(RepeatBehavior repeatBehavior1, RepeatBehavior repeatBehavior2) => throw new NotImplementedException();
                public override int GetHashCode() => throw new NotImplementedException();
                public static bool operator ==(RepeatBehavior repeatBehavior1, RepeatBehavior repeatBehavior2) => throw new NotImplementedException();
                public static bool operator !=(RepeatBehavior repeatBehavior1, RepeatBehavior repeatBehavior2) => throw new NotImplementedException();
            }
            public enum RepeatBehaviorType
            {
                Count,
                Duration,
                Forever
            }
        }
        namespace Media3D
        {
            public struct Matrix3D : IFormattable
            {
                public double M11 { get; set; }
                public double M12 { get; set; }
                public double M13 { get; set; }
                public double M14 { get; set; }
                public double M21 { get; set; }
                public double M22 { get; set; }
                public double M23 { get; set; }
                public double M24 { get; set; }
                public double M31 { get; set; }
                public double M32 { get; set; }
                public double M33 { get; set; }
                public double M34 { get; set; }
                public double OffsetX { get; set; }
                public double OffsetY { get; set; }
                public double OffsetZ { get; set; }
                public double M44 { get; set; }
                public static Matrix3D Identity { get; }
                public bool IsIdentity { get; }
                public bool HasInverse { get; }
                public Matrix3D(double m11, double m12, double m13, double m14, double m21, double m22, double m23, double m24, double m31, double m32, double m33, double m34, double offsetX, double offsetY, double offsetZ, double m44)
                    => throw new NotImplementedException();
                public override string ToString() => throw new NotImplementedException();
                public string ToString(IFormatProvider provider) => throw new NotImplementedException();
                string IFormattable.ToString(string format, IFormatProvider provider) => throw new NotImplementedException();
                public override int GetHashCode() => throw new NotImplementedException();
                public override bool Equals(object o) => throw new NotImplementedException();
                public bool Equals(Matrix3D value) => throw new NotImplementedException();
                public static bool operator ==(Matrix3D matrix1, Matrix3D matrix2) => throw new NotImplementedException();
                public static bool operator !=(Matrix3D matrix1, Matrix3D matrix2) => throw new NotImplementedException();
                public static Matrix3D operator *(Matrix3D matrix1, Matrix3D matrix2) => throw new NotImplementedException();
                public void Invert() => throw new NotImplementedException();
            }
        }
    }
}