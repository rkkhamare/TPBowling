using System;
using System.Collections.Generic;
using System.Text;

namespace TPBowling
{
    class Scorer
    {
        /// <summary>
        /// Check if it is a Strike.
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        public bool IsStrike(int frame) => Settings.PinFalls[frame] == 10;

        /// <summary>
        /// Check if it is a Spare.
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        public bool IsSpare(int frame) => (Settings.PinFalls[frame] + Settings.PinFalls[frame + 1]) == 10;

        /// <summary>
        /// Calculate the Strike Bonus. 
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        public int StrikeBonus(int frame) => Settings.PinFalls[frame + 1] + Settings.PinFalls[frame + 2];

        /// <summary>
        /// Calculate the Spare Bonus. 
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        public int SpareBonus(int frame) => Settings.PinFalls[frame + 2];
    }
}
