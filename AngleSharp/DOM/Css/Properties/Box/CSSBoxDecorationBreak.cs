﻿namespace AngleSharp.DOM.Css.Properties
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// More infos can be found on the W3C homepage or
    /// in condensed form at 
    /// http://css-infos.net/property/box-decoration-break
    /// </summary>
    sealed class CSSBoxDecorationBreak : CSSProperty
    {
        #region Fields

        static readonly Dictionary<String, BoxDecorationBreakMode> modes = new Dictionary<String, BoxDecorationBreakMode>(StringComparer.OrdinalIgnoreCase);
        BoxDecorationBreakMode _mode;

        #endregion

        #region ctor

        static CSSBoxDecorationBreak()
        {
            modes.Add("slice", new SliceBoxDecorationBreakMode());
            modes.Add("clone", new CloneBoxDecorationBreakMode());
        }

        public CSSBoxDecorationBreak()
            : base(PropertyNames.BoxDecorationBreak)
        {
            _mode = modes["slice"];
            _inherited = false;
        }

        #endregion

        #region Methods

        protected override Boolean IsValid(CSSValue value)
        {
            if (value is CSSIdentifierValue)
            {
                var ident = (CSSIdentifierValue)value;
                BoxDecorationBreakMode mode;

                if (modes.TryGetValue(ident.Value, out mode))
                {
                    _mode = mode;
                    return true;
                }
            }
            else if (value == CSSValue.Inherit)
                return true;

            return false;
        }

        #endregion

        #region Modes

        abstract class BoxDecorationBreakMode
        {
            //TODO Add members that make sense
        }

        /// <summary>
        /// No border and no padding are inserted at the break.
        /// </summary>
        sealed class SliceBoxDecorationBreakMode : BoxDecorationBreakMode
        {
        }

        /// <summary>
        /// Each box is independently wrapped with the border and padding.
        /// </summary>
        sealed class CloneBoxDecorationBreakMode : BoxDecorationBreakMode
        {
        }

        #endregion
    }
}
