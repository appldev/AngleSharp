﻿namespace AngleSharp
{
    using AngleSharp.DOM.Css;
    using System;

    /// <summary>
    /// A bunch of useful extension methods.
    /// </summary>
    static class ValueExtensions
    {
        public static Uri ToUri(this CSSValue value)
        {
            if (value is CSSUriValue)
                return ((CSSUriValue)value).Uri;

            return null;
        }

        public static String ToContent(this CSSValue value)
        {
            if (value is CSSStringValue)
                return ((CSSStringValue)value).Value;

            return null;
        }

        public static CSSCalcValue ToCalc(this CSSValue value)
        {
            if (value is CSSPercentValue)
                return CSSCalcValue.FromPercent(((CSSPercentValue)value).Value);
            else if (value is CSSLengthValue)
                return CSSCalcValue.FromLength(((CSSLengthValue)value).Length);
            else if (value == CSSNumberValue.Zero)
                return CSSCalcValue.FromLength(Length.Zero);

            return null;
        }

        public static Single? ToNumber(this CSSValue value)
        {
            if (value is CSSNumberValue)
                return ((CSSNumberValue)value).Value;

            return null;
        }

        public static Int32? ToInteger(this CSSValue value)
        {
            if (value is CSSNumberValue)
                return (Byte)((CSSNumberValue)value).Value;

            return null;
        }

        public static Byte? ToByte(this CSSValue value)
        {
            if (value is CSSNumberValue)
                return (Byte)Math.Min(Math.Max(((CSSNumberValue)value).Value, 0), 255);

            return null;
        }

        public static Angle? ToAngle(this CSSValue value)
        {
            if (value is CSSAngleValue)
                return ((CSSAngleValue)value).Angle;

            return null;
        }

        public static Length? ToLength(this CSSValue value)
        {
            if (value is CSSLengthValue)
                return ((CSSLengthValue)value).Length;
            else if (value == CSSNumberValue.Zero)
                return Length.Zero;

            return null;
        }

        public static Color? ToColor(this CSSValue value)
        {
            if (value is CSSColorValue)
                return ((CSSColorValue)value).Color;
            else if (value is CSSIdentifierValue)
                return Color.FromName(((CSSIdentifierValue)value).Value);

            return null;
        }
    }
}
