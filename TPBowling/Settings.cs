using System;
using System.Collections.Generic;
using System.Text;

namespace TPBowling
{
    static class Settings
    {
        /// <summary>
        /// Array that contains the number of pinFalls for each Roll.
        /// </summary>
        public static int[] PinFalls = new int[21];

        /// <summary>
        /// Array that marks the Strike in the corresponding Frame.
        /// </summary>
        public static int[] Strikes = new int[10];

        /// <summary>
        /// Array that marks the Spare in the corresponding Frame.
        /// </summary>
        public static int[] Spares = new int[10];
    }
}
