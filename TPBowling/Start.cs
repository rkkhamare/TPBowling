using System;

namespace TPBowling
{
    class Start
    {
        static void Main(string[] args)
        {
            Game _game = new Game();
            Scoring _score = new Scoring();

            Console.WriteLine("\n ************************************");
            Console.WriteLine("\n         TEN PIN BOWLING GAME        ");
            Console.WriteLine("\n ************************************");

            // Below input string as mentioned in exercise sheet.
            string strInput = "10,9,1,5,5,7,2,10,10,10,9,0,8,2,9,1,10";
            var rollsList = strInput.Split(",");

            Console.Write("\n List of rolls of the game:");
            Console.WriteLine(strInput);

            foreach (var roll in rollsList)
            {
                _game.Roll(Convert.ToInt32(roll));
            }

            //Get the total score of the game. 
            _score.Score = _score.TotalScore();

            // Format the output according to the exercise instructions. 
            var outputString = _game.OutputFormat(strInput, Settings.Spares);

            Console.WriteLine("\n| f1 | f2 | f3 | f4 | f5 | f6 | f7 | f8 | f9 | f10 | ");
            Console.WriteLine(outputString);
            Console.Write("score: " + _score.Score);
            Console.ReadKey();
        }
    }
}
