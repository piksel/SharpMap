using System;
using System.Collections.Generic;
using System.Drawing;

namespace SharpMap.Rendering.Symbolizer
{
    /// <summary>
    /// Utility class to Symbolizers, mainly used for pleasant setup;
    /// </summary>
    public static class Utility
    {
        private static readonly Random RNG = new Random(998762);

        static Utility()
        {
        }

        /// <summary>
        /// Method to get a random <see cref="Color"/> 
        /// </summary>
        /// <returns>A random color</returns>
        public static Color RandomKnownColor()
        => Color.FromArgb(RNG.Next());

        /// <summary>
        /// Scales sizes to device units
        /// </summary>
        /// <param name="size"></param>
        /// <param name="unit"></param>
        /// <param name="g"></param>
        /// <returns></returns>
        public static float ScaleSizeToDeviceUnits(float size, GraphicsUnit unit, Graphics g)
        {
            if (unit == g.PageUnit)
                return size;

            switch (unit)
            {
                case GraphicsUnit.Point:
                    size *= g.DpiY / 72f;
                    break;
                case GraphicsUnit.Display:
                    //Heuristic for printer or display needed!
                    size *= g.DpiY / (g.DpiY < 100 ? 72f : 100f) ;
                    break;
                case GraphicsUnit.Document:
                    size *= g.DpiY / 300;
                    break;
                case GraphicsUnit.Inch:
                    size *= g.DpiY;
                    break;
                case GraphicsUnit.Millimeter:
                    size *= g.DpiY / 25.4f;
                    break;
                case GraphicsUnit.World:
                    size *= g.DpiY / g.PageScale;
                    break;
                    /*
                case GraphicsUnit.Pixel:
                default:
                    //do nothing
                    break;
                 */
            }
            return (float) Math.Round(size, MidpointRounding.AwayFromZero);
            
        }
    }
}
