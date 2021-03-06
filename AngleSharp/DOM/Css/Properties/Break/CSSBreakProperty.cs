﻿namespace AngleSharp.DOM.Css.Properties
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Basis for break-before or break-after property.
    /// </summary>
    abstract class CSSBreakProperty : CSSProperty
    {
        #region Fields

        static readonly Dictionary<String, BreakMode> modes = new Dictionary<String, BreakMode>(StringComparer.OrdinalIgnoreCase);
        BreakMode _mode;

        #endregion

        #region ctor

        static CSSBreakProperty()
        {
            modes.Add("auto", new AutoBreakMode());
            modes.Add("always", new AlwaysBreakMode());
            modes.Add("avoid", new AvoidBreakMode());
            modes.Add("left", new LeftBreakMode());
            modes.Add("right", new RightBreakMode());
            modes.Add("page", new PageBreakMode());
            modes.Add("column", new ColumnBreakMode());
            modes.Add("avoid-page", new AvoidPageBreakMode());
            modes.Add("avoid-column", new AvoidColumnBreakMode());
        }

        public CSSBreakProperty(String name)
            : base(name)
        {
            _mode = modes["auto"];
            _inherited = false;
        }

        #endregion

        #region Methods

        protected override Boolean IsValid(CSSValue value)
        {
            if (value is CSSIdentifierValue)
            {
                var ident = (CSSIdentifierValue)value;
                BreakMode mode;

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

        abstract class BreakMode
        {
            //TODO Add members that make sense
        }
        
        /// <summary>
        /// Initial value. Allows, meaning neither forbid nor force, any break
        /// (either page, column or region) to be be inserted before the principle box.
        /// </summary>
        sealed class AutoBreakMode : BreakMode
        {
        }

        /// <summary>
        /// Always force page breaks before the principle box. This is a synonym of
        /// page, it has been kept to facilitate transition from page-break-before
        /// which is subset of this property.
        /// </summary>
        sealed class AlwaysBreakMode : BreakMode
        {
        }

        /// <summary>
        /// Prevent any break, either page, column or region, to be inserted right
        /// before the principle box.
        /// </summary>
        sealed class AvoidBreakMode : BreakMode
        {
        }
        
        /// <summary>
        /// Force one or two page breaks right before the principle box so that the
        /// next page is formatted as a left page.
        /// </summary>
        sealed class LeftBreakMode : BreakMode
        {
        }

        /// <summary>
        /// Force one or two page breaks right before the principle box so that the next
        /// page is formatted as a right page.
        /// </summary>
        sealed class RightBreakMode : BreakMode
        {
        }

        /// <summary>
        /// Always force one page break right before the principle box.
        /// </summary>
        sealed class PageBreakMode : BreakMode
        {
        }

        /// <summary>
        /// Always force one column break right before the principle box.
        /// </summary>
        sealed class ColumnBreakMode : BreakMode
        {
        }

        /// <summary>
        /// Avoid any page break right before the principle box.
        /// </summary>
        sealed class AvoidPageBreakMode : BreakMode
        {
        }

        /// <summary>
        /// Avoid any column break right before the principle box.
        /// </summary>
        sealed class AvoidColumnBreakMode : BreakMode
        {
        }
        
        #endregion
    }
}
