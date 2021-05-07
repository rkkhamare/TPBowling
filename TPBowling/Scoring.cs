using System;
using System.Collections.Generic;
using System.Text;

namespace TPBowling
{
     public class Scoring
    {
        /// <summary>
        /// Total score of the game.
        /// </summary>
        public int Score { get;  set; }

        /// <summary>
        /// Calculate the total score of the game. 
        /// </summary>
        /// <returns></returns>
        public int TotalScore()
        {
            int score = 0;
            int frameNumber = 0;
            Scorer _scorer = new Scorer();

            for (int frame = 0; frame < 10; frame++)
            {
                //If on his first try in the frame he knocks down all the pins, this is called a “strike”.
                if (_scorer.IsStrike(frameNumber))
                {
                    score += 10 + _scorer.StrikeBonus(frameNumber);
                    Settings.Strikes[frame] = 1;
                    frameNumber++;
                }//If in two tries he knocks them all down, this is called a “spare”.
                else if (_scorer.IsSpare(frameNumber))
                {
                    score += 10 + _scorer.SpareBonus(frameNumber);
                    Settings.Spares[frame] = 1;
                    frameNumber += 2;
                }
                else
                {
                    //If in two tries, he fails to knock them all down, his score for that frame is the total number of
                    //pins knocked down in his two tries.
                    score += Settings.PinFalls[frameNumber] + Settings.PinFalls[frameNumber + 1];
                    frameNumber += 2;
                }
            }
            return score;
        }
    }
}
