using NUnit.Framework;

namespace TPBowling.Tests
{
    public class ScoringTest
    {
        Game _game;
        Scoring _score;

        [SetUp]
        public void Setup()
        {
            _game = new Game();
            _score = new Scoring();
        }

        void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                _game.Roll(pins);
            }

        }

        [Test]
        public void RollGameAllGutterBalls()
        {
            RollMany(20, 0);
            Assert.That(_score.TotalScore(), Is.EqualTo(0));
        }

        [Test]
        public void RollOnes()
        {
            RollMany(20, 1);
            Assert.That(_score.TotalScore(), Is.EqualTo(20));
        }

        [Test]
        public void RollSpareFirstFrame()
        {
            _game.Roll(9);
            _game.Roll(1);
            RollMany(18, 1);

            Assert.That(_score.TotalScore(), Is.EqualTo(29));
        }

        [Test]
        public void RollSparesAllFrame()
        {
            RollMany(21, 5);

            Assert.That(_score.TotalScore(), Is.EqualTo(150));
        }

        [Test]
        public void RollNineOneSpares()
        {
            for (int i = 0; i < 10; i++)
            {
                _game.Roll(9); _game.Roll(1);
            }
            _game.Roll(9);

            Assert.That(_score.TotalScore(), Is.EqualTo(190));
        }

        [Test]
        public void RollPerfectGame()
        {
            RollMany(12, 10);

            Assert.That(_score.TotalScore(), Is.EqualTo(300));
        }

        [Test]
        public void TaskGameExampleOutput1()
        {
            //| f1 | f2 | f3 | f4 | f5 | f6 | f7 | f8 | f9 | f10 |
            //| -, 3 | 5, -| 9, /| 2, 5 | 3, 2 | 4, 2 | 3, 3 | 4, /| X | X, 2, 5 |
            //Score: 103
            _game.Roll(0); _game.Roll(3);
            _game.Roll(5); _game.Roll(0);
            _game.Roll(9); _game.Roll(1);
            _game.Roll(2); _game.Roll(5);
            _game.Roll(3); _game.Roll(2);
            _game.Roll(4); _game.Roll(2);
            _game.Roll(3); _game.Roll(3);
            _game.Roll(4); _game.Roll(6);
            _game.Roll(10);
            _game.Roll(10); _game.Roll(2); _game.Roll(5);


            Assert.That(_score.TotalScore(), Is.EqualTo(103));
        }


        [Test]
        public void TaskGameExampleOutput2()
        {
            //| f1 | f2 | f3 | f4 | f5 | f6 | f7 | f8 | f9 | f10 |
            //| 7, 1 | 5, /| 2, 7 | 4, /| -, 5 | 8, /| 8, 1 | 4, 3 | 2, 4 | 5, 2 |
            //  Score: 91            

            _game.Roll(7); _game.Roll(1);
            _game.Roll(5); _game.Roll(5);
            _game.Roll(2); _game.Roll(7);
            _game.Roll(4); _game.Roll(6);
            _game.Roll(0); _game.Roll(5);
            _game.Roll(8); _game.Roll(2);
            _game.Roll(8); _game.Roll(1);
            _game.Roll(4); _game.Roll(3);
            _game.Roll(2); _game.Roll(4);
            _game.Roll(5); _game.Roll(2);

            Assert.That(_score.TotalScore(), Is.EqualTo(91));
        }

        [Test]
        public void GameExampleOutput3()
        {
            _game.Roll(10);
            _game.Roll(9); _game.Roll(1);
            _game.Roll(5); _game.Roll(5);
            _game.Roll(7); _game.Roll(2);
            _game.Roll(10);
            _game.Roll(10);
            _game.Roll(10);
            _game.Roll(9); _game.Roll(0);
            _game.Roll(8); _game.Roll(2);
            _game.Roll(9); _game.Roll(1); _game.Roll(10);

            Assert.That(_score.TotalScore(), Is.EqualTo(187));
        }
    }
}