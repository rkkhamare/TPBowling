using System;
using System.Collections.Generic;
using System.Text;

namespace TPBowling
{
    public class Game
    {
        /// <summary>
        /// Rolls counter increasing by one when a Roll action is performed.
        /// </summary>
        public int RollsCounter;

        /// <summary>
        /// Read a file containing a comma separated list of rolls, taking the reference to the file as a command line argument
        /// </summary>
        /// <param name="rollsList"></param>
        /// <returns></returns>
        private static string RollsFromFile(out string[] rollsList)
        {
            var path = Console.ReadLine();
            string rollsFromFile = System.IO.File.ReadAllText(path);
            rollsList = rollsFromFile.Split(",");
            return rollsFromFile;
        }

        /// <summary>
        /// Fill the PinFalls Array for one Roll. 
        /// </summary>
        /// <param name="pins"></param>
        public void Roll(int pins)
        {
            Settings.PinFalls[RollsCounter] = pins;
            RollsCounter++;
        }

        /// <summary>
        /// Format the output according to the exercise specifications. 
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="spares"></param>
        /// <returns></returns>
        public string OutputFormat(string strInput, int[] spares)
        {
            // 1.-  Replace the Strikes with symbol 'X'
            var strikesAndGutterFormat = strInput.Replace("10", "X,*");
            
            // 2.-  Replace the Gutter balls with symbol '-'
            strikesAndGutterFormat = strikesAndGutterFormat.Replace("0,", "-,");

            //3.- Check the Spares Array and format the string with the '/' symbol. 
            var sparesFormat = strikesAndGutterFormat.Split(",");
            for (int s = 0; s < spares.Length; s++)
            {
                if (spares[s] == 1) sparesFormat[((s + 1) * 2) - 1] = "/";
            }

            //4-. Insert the fisrt '|' of the output. 
            sparesFormat[0] = "| " + sparesFormat[0];

            for (int s = 0; s < sparesFormat.Length; s++)
            {
                switch (s % 2)
                {
                    case 0 when (sparesFormat[s] == "X"):
                        sparesFormat[s] = sparesFormat[s] + " |";
                        sparesFormat[s + 1] = sparesFormat[s + 1] + ", ";
                        s++;
                        break;
                    case 0:
                        sparesFormat[s] = sparesFormat[s] + ", ";
                        break;
                    default:
                            sparesFormat[s] = sparesFormat[s] + "|";
                        break;
                }
            }
            string outputString = string.Empty;

            foreach (var s in sparesFormat)
                outputString += s;
            return outputString.Replace("*,", "").Replace("*|", "|");
        }
    }
}
