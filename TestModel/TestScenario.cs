using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diaballik;

namespace TestModel
{
    [TestClass]
    public class TestScenario
    {
        [TestMethod]
        public void R22_1_SCENARIO_STANDARD()
        {
            Game game = FactoryTest.getGameWithScenario(new Standart());
            int sizeBoard = Properties.DEFAULT_SIZE_BOARD;
            Board board = game.Board;
            for (int i = 0; i < sizeBoard; i++)
            {
                Assert.IsTrue(board.getTile(0, i).hasPiece());
                Assert.IsTrue(board.getTile(0, i).Piece.Player.Equals(game.P1));
                if (i == (sizeBoard / 2))
                {
                    Assert.IsTrue(board.getTile(0, i).Piece.Ball.Player.Equals(game.P1));
                    Assert.IsTrue(board.getTile(0, i).Piece.hasBall());
                }

            }
            for (int i = 0; i < sizeBoard; i++)
            {
                Assert.IsTrue(board.getTile(sizeBoard - 1, i).hasPiece());
                Assert.IsTrue(board.getTile(sizeBoard - 1, i).Piece.Player.Equals(game.P2));
                if (i == sizeBoard / 2)
                {
                    Assert.IsTrue(board.getTile(sizeBoard - 1, i).Piece.Ball.Player.Equals(game.P2));
                    Assert.IsTrue(board.getTile(sizeBoard - 1, i).Piece.hasBall());
                }

            }
        }

        [TestMethod]
        public void R22_2_SCENARIO_BALL_RANDOM()
        {
            Game game = FactoryTest.getGameWithScenario(new BallRandom());
            int sizeBoard = Properties.DEFAULT_SIZE_BOARD;
            Board board = game.Board;
            bool ball = false;
            for (int i = 0; i < sizeBoard; i++)
            {
                Assert.IsTrue(board.getTile(0, i).hasPiece());
                Assert.IsTrue(board.getTile(0, i).Piece.Player.Equals(game.P1));
                if (board.getTile(0, i).Piece.hasBall())
                {
                    Assert.IsTrue(board.getTile(0, i).Piece.Ball.Player.Equals(game.P1));
                    ball = true;
                }

            }
            Assert.IsTrue(ball);
            ball = false;
            for (int i = 0; i < sizeBoard; i++)
            {
                Assert.IsTrue(board.getTile(sizeBoard - 1, i).hasPiece());
                Assert.IsTrue(board.getTile(sizeBoard - 1, i).Piece.Player.Equals(game.P2));
                if (board.getTile(sizeBoard - 1, i).Piece.hasBall())
                {
                    Assert.IsTrue(board.getTile(sizeBoard - 1, i).Piece.Ball.Player.Equals(game.P2));
                    ball = true;
                }

            }
            Assert.IsTrue(ball);
        }

        [TestMethod]
        public void R22_3_SCENARIO_ENEMY_AMONG_US()
        {
            Game game = FactoryTest.getGameWithScenario(new EnemyAmongUs());
            int sizeBoard = Properties.DEFAULT_SIZE_BOARD;
            Board board = game.Board;

            int nbPieceP1 = 0;
            int nbPieceP2 = 0;

            for (int i = 0; i < sizeBoard; i++)
            {
                if(i== sizeBoard / 2)
                {
                    Assert.IsTrue(board.getTile(0, i).Piece.Ball.Player.Equals(game.P1));
                    nbPieceP1++;
                }
                else if(board.getTile(0, i).Piece.Player.Equals(game.P1)) nbPieceP1++;
                else if (board.getTile(0, i).Piece.Player.Equals(game.P2)) nbPieceP2++;
            }

            Assert.AreEqual(nbPieceP1, sizeBoard-2);
            Assert.AreEqual(nbPieceP2,  2);
            nbPieceP1 = 0;
            nbPieceP2 = 0;

            for (int i = 0; i < sizeBoard; i++)
            {
                if (i == sizeBoard / 2)
                {
                    Assert.IsTrue(board.getTile(sizeBoard - 1, i).Piece.Ball.Player.Equals(game.P2));
                    nbPieceP2++;
                }
                else if (board.getTile(sizeBoard - 1, i).Piece.Player.Equals(game.P1)) nbPieceP1++;
                else if (board.getTile(sizeBoard - 1, i).Piece.Player.Equals(game.P2)) nbPieceP2++;
            }

            Assert.AreEqual(nbPieceP2, sizeBoard - 2);
            Assert.AreEqual(nbPieceP1, 2);

        }
    }
}
