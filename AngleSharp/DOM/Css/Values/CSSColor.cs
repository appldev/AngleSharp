﻿namespace AngleSharp.DOM.Css
{
    using System;

    sealed class CSSColor : CSSPrimitiveValue
    {
        #region Fields

        Color _value;

        #endregion

        #region ctor

        public CSSColor(Color value)
            : base(CssUnit.Rgbcolor)
        {
            _text = value.ToString();
            _value = value;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the value of the CSS color.
        /// </summary>
        public Color Color
        {
            get { return _value; }
        }

        #endregion
    }
}