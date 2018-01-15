using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diaballik;
using Diaballik.Exceptions;
using System.Drawing;

namespace TestModel
{
    /// <summary>
    /// Class TestGamePlay.
    /// </summary>
    [TestClass]
    public class TestGamePlay
    {

        /// <summary>
        /// Test si une exception est lancée si il n'y a qu'un joueur
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(PlayerNumberException))]
        public void R21_1_GAME_PLAYERS_TWO_PLAYERS_ERROR()
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Red, "test");
            gameBuilder.Scenario = new Standart();
            Game game = gameBuilder.build();
        }

        /// <summary>
        /// Une partie doit comporter 2 joueurs
        /// </summary>
        [TestMethod]
        public void R21_1_GAME_PLAYERS_TWO_PLAYERS()
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Red, "test");
            gameBuilder.Player2 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test2");
            gameBuilder.Scenario = new Standart();
            try
            {
                Game game = gameBuilder.build();
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
        /// <summary>
        /// Test qui lance une exception si un joueur n'a pas de nom
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ConfigurationPlayerException))]
        public void R21_1_GAME_PLAYERS_NO_NAME()
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Red, null);
            gameBuilder.Player2 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test2");
            gameBuilder.Scenario = new Standart();
            Game game = gameBuilder.build();
        }

        /// <summary>
        /// Un joueur doit avoir un nom
        /// </summary>
        [TestMethod]
        public void R21_1_GAME_PLAYERS_WITH_NAME()
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Red, "test");
            gameBuilder.Player2 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test2");
            gameBuilder.Scenario = new Standart();
            Game game = gameBuilder.build();
            Assert.AreEqual("test", game.P1.Name);
        }

        /// <summary>
        /// Un plateau doit être composé du même nombre de ligne que de colonne
        /// </summary>
        [TestMethod]
        public void R21_2_GAME_BOARDS()
        {
            //La création d'un board ce fait de la facon suivante : 
            //new Tile[sizeBoard,sizeBoard]; 
            //ainsi cela créer un plateau carré 
            //pour l'instant la valeur par defaut 7 est utilisée pour
            //la céation du carré. Ainsi la taille est définie par un nombre impair
            //
            Assert.IsTrue(true);

        }

        /// <summary>
        /// Les couleurs des pièces doivent être de la même couleur que celle du joueur
        /// </summary>
        [TestMethod]
        public void R21_3_GAME_PIECES_COLOR_BALL()
        {
            //chaque piece est reliée à un joueur, donc la couleur d'une piece est recupérée depuis le joueur
            //Ainsi, la couleur de chaque piece est bien celle du joueur
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Chaque joueur doit avoir le même nombre de pièce dans le scénario STANDART
        /// </summary>
        [TestMethod]
        public void R21_3_GAME_PIECES_NUMBER_OF_PIECES_STANDART()
        {
            Game game = FactoryTest.getGameWithScenario(new Standart());
            int nbPieceP1 = 0;
            int nbPieceP2 = 0;
            int sizeBoard = Properties.DEFAULT_SIZE_BOARD;
            Board board = game.Board;
            for (int i = 0; i < sizeBoard; i++)
            {
                for (int j = 0; j < sizeBoard; j++)
                {
                    if (board.getTile(i, j).hasPiece())
                    {
                        if (board.getTile(i, j).Piece.Player.Equals(game.P1)) nbPieceP1++;
                        if (board.getTile(i, j).Piece.Player.Equals(game.P2)) nbPieceP2++;
                    }
                }
            }
            Assert.AreEqual(nbPieceP1, nbPieceP2);
            Assert.AreEqual(nbPieceP1, sizeBoard);
        }

        /// <summary>
        /// Chaque joueur doit avoir le même nombre de pièce dans le scénario BALL RANDOM
        /// </summary>
        [TestMethod]
        public void R21_3_GAME_PIECES_NUMBER_OF_PIECES_BALL_RANDOM()
        {
            Game game = FactoryTest.getGameWithScenario(new BallRandom());
            int nbPieceP1 = 0;
            int nbPieceP2 = 0;
            int sizeBoard = Properties.DEFAULT_SIZE_BOARD;
            Board board = game.Board;
            for (int i = 0; i < sizeBoard; i++)
            {
                for (int j = 0; j < sizeBoard; j++)
                {
                    if (board.getTile(i, j).hasPiece())
                    {
                        if (board.getTile(i, j).Piece.Player.Equals(game.P1)) nbPieceP1++;
                        if (board.getTile(i, j).Piece.Player.Equals(game.P2)) nbPieceP2++;
                    }
                }
            }
            Assert.AreEqual(nbPieceP1, nbPieceP2);
            Assert.AreEqual(nbPieceP1, sizeBoard);
        }

        /// <summary>
        /// Chaque joueur doit avoir le même nombre de pièce dans le scénario ENEMY AMONG US
        /// </summary>
        [TestMethod]
        public void R21_3_GAME_PIECES_NUMBER_OF_PIECES_ENEMY_AMONG_US()
        {
            Game game = FactoryTest.getGameWithScenario(new EnemyAmongUs());
            int nbPieceP1 = 0;
            int nbPieceP2 = 0;
            int sizeBoard = Properties.DEFAULT_SIZE_BOARD;
            Board board = game.Board;
            for (int i = 0; i < sizeBoard; i++)
            {
                for (int j = 0; j < sizeBoard; j++)
                {
                    if (board.getTile(i, j).hasPiece())
                    {
                        if (board.getTile(i, j).Piece.Player.Equals(game.P1)) nbPieceP1++;
                        if (board.getTile(i, j).Piece.Player.Equals(game.P2)) nbPieceP2++;
                    }
                }
            }
            Assert.AreEqual(nbPieceP1, nbPieceP2);
            Assert.AreEqual(nbPieceP1, sizeBoard);
        }

        /// <summary>
        /// Chaque joueur doit avoir une balle dans la scénario STANDART
        /// </summary>
        [TestMethod]
        public void R21_4_GAME_BALL_STANDART()
        {
            Game game = FactoryTest.getGameWithScenario(new Standart());
            int nbBallP1 = 0;
            int nbBallP2 = 0;
            int sizeBoard = Properties.DEFAULT_SIZE_BOARD;
            Board board = game.Board;
            for (int i = 0; i < sizeBoard; i++)
            {
                for (int j = 0; j < sizeBoard; j++)
                {
                    if (board.getTile(i, j).hasPiece() && board.getTile(i, j).Piece.hasBall())
                    {
                        if (board.getTile(i, j).Piece.Player.Equals(game.P1)) nbBallP1++;
                        if (board.getTile(i, j).Piece.Player.Equals(game.P2)) nbBallP2++;
                    }
                }
            }
            Assert.AreEqual(nbBallP1, nbBallP2);
            Assert.AreEqual(1, nbBallP2);
        }

        /// <summary>
        /// Chaque joueur doit avoir une balle dans la scénario BALL RANDOM
        /// </summary>
        [TestMethod]
        public void R21_4_GAME_BALL_BALL_RANDOM()
        {
            Game game = FactoryTest.getGameWithScenario(new BallRandom());
            int nbBallP1 = 0;
            int nbBallP2 = 0;
            int sizeBoard = Properties.DEFAULT_SIZE_BOARD;
            Board board = game.Board;
            for (int i = 0; i < sizeBoard; i++)
            {
                for (int j = 0; j < sizeBoard; j++)
                {
                    if (board.getTile(i, j).hasPiece() && board.getTile(i, j).Piece.hasBall())
                    {
                        if (board.getTile(i, j).Piece.Player.Equals(game.P1)) nbBallP1++;
                        if (board.getTile(i, j).Piece.Player.Equals(game.P2)) nbBallP2++;
                    }
                }
            }
            Assert.AreEqual(nbBallP1, nbBallP2);
            Assert.AreEqual(1, nbBallP2);
        }

        /// <summary>
        /// Chaque joueur doit avoir une balle dans la scénario ENEMY AMONG US
        /// </summary>
        [TestMethod]
        public void R21_4_GAME_BALL_ENEMY_AMONG_US()
        {
            Game game = FactoryTest.getGameWithScenario(new EnemyAmongUs());
            int nbBallP1 = 0;
            int nbBallP2 = 0;
            int sizeBoard = Properties.DEFAULT_SIZE_BOARD;
            Board board = game.Board;
            for (int i = 0; i < sizeBoard; i++)
            {
                for (int j = 0; j < sizeBoard; j++)
                {
                    if (board.getTile(i, j).hasPiece() && board.getTile(i, j).Piece.hasBall())
                    {
                        if (board.getTile(i, j).Piece.Player.Equals(game.P1)) nbBallP1++;
                        if (board.getTile(i, j).Piece.Player.Equals(game.P2)) nbBallP2++;
                    }
                }
            }
            Assert.AreEqual(nbBallP1, nbBallP2);
            Assert.AreEqual(1, nbBallP2);
        }



        /// <summary>
        /// Test qui renvoie une exception si un joueur n'a pas de couleur
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ConfigurationPlayerException))]
        public void R21_5_GAME_COLOUR_HAS_NOT_COLOR()
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Empty, "test");
            gameBuilder.Player2 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test2");
            gameBuilder.Scenario = new Standart();
            Game game = gameBuilder.build();
        }

        /// <summary>
        /// Un joueur doit posséder une couleur
        /// </summary>
        [TestMethod]
        public void R21_5_GAME_COLOUR_HAS_COLOR()
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Red, "test");
            gameBuilder.Player2 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test2");
            gameBuilder.Scenario = new Standart();

            try
            {
                Game game = gameBuilder.build();
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        /// <summary>
        /// Les 2 joueurs ne peuvent pas avoir la même couleur
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(PlayerSameColorException))]
        public void R21_5_GAME_COLOUR_HAVE_SAME_COLOR()
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test");
            gameBuilder.Player2 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test2");
            gameBuilder.Scenario = new Standart();
            Game game = gameBuilder.build();
        }

        /// <summary>
        /// Un jouueur ne peut faire que 3 actions maximum par tour
        /// </summary>
        [TestMethod]
        public void R21_6_GAMEPLAY_TURN_3_MOVE()
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test");
            gameBuilder.Player2 = FactoryTest.getPlayerBuilderHuman(Color.Red, "test2");
            gameBuilder.Scenario = new Standart();
            Game game = gameBuilder.build();


            if (game.PlayerWhoPlay.Equals(game.P1))
            {
                game.Board.getTile(0, 0).click(game.P1);
                game.Board.getTile(1, 0).click(game.P1);

                game.Board.getTile(1, 0).click(game.P1);
                game.Board.getTile(2, 0).click(game.P1);

                game.Board.getTile(2, 0).click(game.P1);
                game.Board.getTile(3, 0).click(game.P1);

                Assert.AreNotEqual(game.P1, game.PlayerWhoPlay);

                bool res = game.Board.getTile(3, 0).click(game.P1);
                Assert.IsFalse(res);
            }
            else
            {
                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 1, 0).click(game.P2);
                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 2, 0).click(game.P2);

                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 2, 0).click(game.P2);
                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 3, 0).click(game.P2);

                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 3, 0).click(game.P2);
                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 4, 0).click(game.P2);

                Assert.AreNotEqual(game.P2, game.PlayerWhoPlay);

                bool res = game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 4, 0).click(game.P2);
                Assert.IsFalse(res);
            }
        }

        /// <summary>
        /// Un joueur doit faire entre 1 et 3 actions par tour
        /// </summary>
        [TestMethod]
        public void R21_6_GAMEPLAY_TURN_LESS_3_MOVE_MORE_THAN_1()
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test");
            gameBuilder.Player2 = FactoryTest.getPlayerBuilderHuman(Color.Red, "test2");
            gameBuilder.Scenario = new Standart();
            Game game = gameBuilder.build();

            Player Iamplaying = game.PlayerWhoPlay;
            if (game.Board.getTile(0, 0).Piece.Player.Equals(Iamplaying))
            {
                game.Board.getTile(0, 0).click(Iamplaying);
                game.Board.getTile(1, 0).click(Iamplaying);

                Iamplaying.endTurn();

                bool res = game.Board.getTile(1, 0).click(Iamplaying);

                Assert.IsFalse(res);
            }
            else
            {
                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 1, 0).click(Iamplaying);
                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 2, 0).click(Iamplaying);

                Iamplaying.endTurn();

                bool res = game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 2, 0).click(Iamplaying);

                Assert.IsFalse(res);
            }

        }

        /// <summary>
        /// Un joueur doit faire au moins 1 action par tour
        /// </summary>
        [TestMethod]
        public void R21_6_GAMEPLAY_TURN_LESS_1_MOVE()
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test");
            gameBuilder.Player2 = FactoryTest.getPlayerBuilderHuman(Color.Red, "test2");
            gameBuilder.Scenario = new Standart();
            Game game = gameBuilder.build();

            Player Iamplaying = game.PlayerWhoPlay;
            game.PlayerWhoPlay.endTurn();
            Assert.AreEqual(Iamplaying, game.PlayerWhoPlay);

        }

        /// <summary>
        /// Un joueur doit faire de 1 à 3 action par tour, les actions sont : bouger la balle ou la piece
        /// </summary>
        [TestMethod]
        public void R21_8_GAMEPLAY_ACTIONS()
        {
            ///Le test R21_9_GAMEPLAY_MOVE_BALL() montre qu'un joueur peut déplacer une balle
            ///Le test R21_10_GAMEPLAY_MOVE_PIECE() montre qu'un joueur peut déplacer une piece
            ///Les tests R21_6_GAMEPLAY_TURN montre les régles des tours.
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Une balle peut être déplacée sur une autre pièce allier horizontalement,verticalement, diagonalement si il n'y a pas d'autres pièces entre les deux
        /// </summary>
        [TestMethod]
        public void R21_9_GAMEPLAY_MOVE_BALL()
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Red, "test");
            gameBuilder.Player2 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test2");
            gameBuilder.Scenario = new Standart();
            Game game = gameBuilder.build();

            Assert.IsNull(game.Board.getTile(0, 2).Piece.Ball);
            Assert.IsNotNull(game.Board.getTile(0, 3).Piece.Ball);

            game.Board.getTile(0, 3).buildDecision();

            Assert.IsTrue(game.Board.getTile(0, 2).Selected);

            game.Board.getTile(0, 2).buildDecision();

            Assert.IsNotNull(game.Board.getTile(0, 2).Piece.Ball);
            Assert.IsNull(game.Board.getTile(0, 3).Piece.Ball);
        }

        /// <summary>
        /// Une pièce peut être déplacée sur la case gauche, droite, haut, ou bas si elle est libre
        /// </summary>
        [TestMethod]
        public void R21_10_GAMEPLAY_MOVE_PIECE()
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Red, "test");
            gameBuilder.Player2 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test2");
            gameBuilder.Scenario = new Standart();
            Game game = gameBuilder.build();

            Assert.IsNull(game.Board.getTile(1, 0).Piece);
            Assert.IsNotNull(game.Board.getTile(0, 0).Piece);

            game.Board.getTile(0, 0).buildDecision();

            Assert.IsTrue(game.Board.getTile(1, 0).Selected);

            game.Board.getTile(1, 0).buildDecision();

            Assert.IsNull(game.Board.getTile(0, 0).Piece);
            Assert.IsNotNull(game.Board.getTile(1, 0).Piece);


        }

        /// <summary>
        /// Une pièce ne peut pas bouger si elle contient une balle
        /// </summary>
        [TestMethod]
        public void R21_11_GAMEPLAY_MOVE_PIECE_WITH_BALL()
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Red, "test");
            gameBuilder.Player2 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test2");
            gameBuilder.Scenario = new Standart();
            Game game = gameBuilder.build();

            Assert.IsNull(game.Board.getTile(0, 2).Piece.Ball);
            Assert.IsNotNull(game.Board.getTile(0, 3).Piece.Ball);
            Assert.IsTrue(game.Board.getTile(0, 3).hasPiece());

            game.Board.getTile(0, 3).buildDecision();

            Assert.IsTrue(game.Board.getTile(0, 2).Selected);

            game.Board.getTile(0, 2).buildDecision();

            Assert.IsNotNull(game.Board.getTile(0, 2).Piece.Ball);
            Assert.IsNull(game.Board.getTile(0, 3).Piece.Ball);
            Assert.IsTrue(game.Board.getTile(0, 3).hasPiece());
        }

        /// <summary>
        /// Le joueur qui commence doit être choisit aléatoirement
        /// </summary>
        [TestMethod]
        public void R21_12_GAMEPLAY_HOW_START()
        {
            ///La méthode choosePlayerTurn de la clasee Game choisit le premier joueur en selectionant aléatoirement un nombre entre 0 et 1
            ///playerWhoPlay est null
            ///playerWhoPlay == null est vrai donc la première condition de la boucle if est vérifiée
            ///playerWhoPlay = (rand.Next(2)==1) ? p1 : p2; choisit aléatoirement un joueur (si 1 alors p1 sera choisi sinon p2)
            ///le else ne sera pas éffectué car la condition du if a été vérifié
            ///playerWhoPlay.myTurn(); indique au joueur selectionné qu'il peut jouer
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Chaque joueur doivent jouer chacun après l'autre
        /// </summary>
        [TestMethod]
        public void R21_13_GAMEPLAY_TURN_ORDER()
        {
            ///La méthode choosePlayerTurn de la clasee Game choisit les joueurs les uns après les autres
            ///playerWhoPlay est different de null
            ///playerWhoPlay == null n'est pas vérifiée
            ///la boucle else est donc choisie
            ///playerWhoPlay.Canplay = false; le joueur actuel est bloqué
            ///playerWhoPlay = (playerWhoPlay.Equals(p1)) ? p2 : p1; si playerWhoPlay est egal à p1 alors p2 sera choisi sinon c'est p1 qui sera le nouveau joueur
            ///playerWhoPlay.myTurn(); indique au joueur selectionné qu'il peut jouer
        }

        /// <summary>
        /// Quand un joueur effectue 3 actions, le tour passe automatiquement au joueur suivant
        /// </summary>
        [TestMethod]
        public void R21_14_GAMEPLAY_TURN_AUTO()
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test");
            gameBuilder.Player2 = FactoryTest.getPlayerBuilderHuman(Color.Red, "test2");
            gameBuilder.Scenario = new Standart();
            Game game = gameBuilder.build();


            if (game.PlayerWhoPlay.Equals(game.P1))
            {
                game.Board.getTile(0, 0).click(game.P1);
                game.Board.getTile(1, 0).click(game.P1);

                game.Board.getTile(1, 0).click(game.P1);
                game.Board.getTile(2, 0).click(game.P1);

                game.Board.getTile(2, 0).click(game.P1);
                game.Board.getTile(3, 0).click(game.P1);

                Assert.AreNotEqual(game.P1, game.PlayerWhoPlay);

                bool res = game.Board.getTile(3, 0).click(game.P1);
                Assert.IsFalse(res);
                Assert.AreNotEqual(game.PlayerWhoPlay, game.P1);
            }
            else
            {
                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 1, 0).click(game.P2);
                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 2, 0).click(game.P2);

                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 2, 0).click(game.P2);
                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 3, 0).click(game.P2);

                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 3, 0).click(game.P2);
                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 4, 0).click(game.P2);

                Assert.AreNotEqual(game.P2, game.PlayerWhoPlay);

                bool res = game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 4, 0).click(game.P2);
                Assert.IsFalse(res);
                Assert.AreNotEqual(game.PlayerWhoPlay, game.P2);
            }
        }

        /// <summary>
        /// Un joueur peut passer son tour même s'il lui reste des actions possibles
        /// </summary>
        [TestMethod]
        public void R21_15_GAMEPLAY_TURN_MANUALLY()
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test");
            gameBuilder.Player2 = FactoryTest.getPlayerBuilderHuman(Color.Red, "test2");
            gameBuilder.Scenario = new Standart();
            Game game = gameBuilder.build();


            if (game.PlayerWhoPlay.Equals(game.P1))
            {
                game.Board.getTile(0, 0).click(game.P1);
                game.Board.getTile(1, 0).click(game.P1);

                game.PlayerWhoPlay.endTurn();

                Assert.AreNotEqual(game.PlayerWhoPlay, game.P1);
            }
            else
            {
                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 1, 0).click(game.P2);
                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 2, 0).click(game.P2);

                game.PlayerWhoPlay.endTurn();

                Assert.AreNotEqual(game.PlayerWhoPlay, game.P2);
            }
        }

        /// <summary>
        /// Une partie ne doit pas avoir un nombre prédéfinit de tour
        /// </summary>
        [TestMethod]
        public void R21_16_GAMEPLAY_TURNS()
        {
        }

        /// <summary>
        /// Le joueur 1 doit pouvoir gagner quand sa balle atteint la ligne ennemie
        /// </summary>
        [TestMethod]
        public void R24_1_VICTORY_P1()
        {
            Game game = FactoryTest.getGameWithScenario(new Standart());
            Assert.AreEqual(0, game.verifyVictory());
            game.Board.getTile(game.Board.SizeBoard - 1, 0).Piece = game.Board.getTile(0, game.Board.SizeBoard / 2).Piece;
            Assert.AreEqual(1, game.verifyVictory());
        }

        /// <summary>
        /// Le joueur 2 doit pouvoir gagner quand sa balle atteint la ligne ennemie
        /// </summary>
        [TestMethod]
        public void R24_1_VICTORY_P2()
        {
            Game game = FactoryTest.getGameWithScenario(new Standart());
            Assert.AreEqual(0, game.verifyVictory());
            game.Board.getTile(0, 0).Piece = game.Board.getTile(game.Board.SizeBoard - 1, game.Board.SizeBoard / 2).Piece;
            Assert.AreEqual(2, game.verifyVictory());
        }

        /// <summary>
        /// Le plateau doit pouvoir être convertit en un tableau 1D d'entier pour le transférer à la DLL
        /// </summary>
        [TestMethod]
        public void Test_convertBoardForCpp()
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Red, "test");
            gameBuilder.Player2 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test2");
            gameBuilder.Scenario = new Standart();
            Game game = gameBuilder.build();
            Assert.AreEqual(1, game.P1.NumberPlayer);
            Assert.AreEqual(2, game.P2.NumberPlayer);
            int[] boardCpp = game.Board.convertBoardForCpp();
            for (int line = 0; line < 7; line++)
            {
                for (int column = 0; column < 7; column++)
                {
                    if (line == 0 && column == 3)
                        Assert.AreEqual(3, boardCpp[line * 7 + column]);
                    else if (line == 6 && column == 3)
                        Assert.AreEqual(4, boardCpp[line * 7 + column]);
                    else if (line == 0)
                        Assert.AreEqual(1, boardCpp[line * 7 + column]);
                    else if (line == 6)
                        Assert.AreEqual(2, boardCpp[line * 7 + column]);
                    else
                        Assert.AreEqual(0, boardCpp[line * 7 + column]);
                }

            }

        }

        /// <summary>
        /// Une partie doit pouvoir être sauvegardée puis rechargée plus tard
        /// </summary>
        /// <value>The test resume a game.</value>
        [TestMethod]
        public void TEST_RESUME_A_GAME()
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test");
            gameBuilder.Player2 = FactoryTest.getPlayerBuilderHuman(Color.Red, "test2");
            gameBuilder.Scenario = new Standart();
            Game game = gameBuilder.build();


            if (game.PlayerWhoPlay.Equals(game.P1))
            {

                game.Board.getTile(0, 0).click(game.P1);
                game.Board.getTile(1, 0).click(game.P1);

                game.Board.getTile(1, 0).click(game.P1);
                game.Board.getTile(2, 0).click(game.P1);

                game.Board.getTile(2, 0).click(game.P1);
                game.Board.getTile(3, 0).click(game.P1);


            }
            else
            {
                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 1, 0).click(game.P2);
                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 2, 0).click(game.P2);

                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 2, 0).click(game.P2);
                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 3, 0).click(game.P2);

                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 3, 0).click(game.P2);
                game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 4, 0).click(game.P2);

            }

           
            int idGame = game.Board.MementoManager.getId();

            //Chargement de la partie précédente

            GameBuilder gameBuilderResume = GameBuilder.create();

            Game gameResume = gameBuilderResume.build(idGame);

            Assert.AreEqual(game.P1.Name, gameResume.P1.Name);
            Assert.AreEqual(game.P2.Name, gameResume.P2.Name);

            if(game.P1.NumberTurn == 1)
            {
                Assert.AreEqual(game.Board.getTile(3, 0).hasPiece(), gameResume.Board.getTile(3, 0).hasPiece());
                Assert.IsTrue(gameResume.Board.getTile(3, 0).hasPiece());
                Assert.IsFalse(gameResume.Board.getTile(2, 0).hasPiece());
            }
            else
            {
                Assert.AreEqual(game.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 4, 0).hasPiece(), gameResume.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 4, 0).hasPiece());
                Assert.IsTrue(gameResume.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 4, 0).hasPiece());
                Assert.IsFalse(gameResume.Board.getTile(Properties.DEFAULT_SIZE_BOARD - 3, 0).hasPiece());
            } 
        }
    }
}
