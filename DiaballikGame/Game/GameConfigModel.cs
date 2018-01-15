using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaballikGame.Utils;
using DiaballikGame.Welcome;
using Diaballik;
using System.Windows.Media;
using System.Windows;

namespace DiaballikGame.Game
{
    /// <summary>
    /// Modele de la vue ConfigGame
    /// </summary>
    /// <seealso cref="DiaballikGame.Utils.ViewModelBase" />
    class GameConfigModel : ViewModelBase
    {
        /// <summary>
        /// Visibilite du bouton création
        /// </summary>
        private Visibility accessButtonPlay = Visibility.Hidden;
        /// <summary>
        /// Acces à l'interface de la fenetre
        /// </summary>
        private MainInterface mI;
        /// <summary>
        /// Builder d'une partie
        /// </summary>
        private GameBuilder gameBuilder;
        /// <summary>
        /// Builder des joueurs
        /// </summary>
        private PlayerBuilder playerBuilder1, playerBuilder2;

        /// <summary>
        /// Constructor <see cref="GameConfigModel"/> class.
        /// </summary>
        /// <param name="mI">Interface de la fenetre principale.</param>
        public GameConfigModel(MainInterface mI)
        {
            this.mI = mI;
            gameBuilder = new GameBuilder();
            playerBuilder1 = new PlayerHumanBuilder();
        }

        /// <summary>
        /// Création d'une partie
        /// </summary>
        /// <param name="namePlayer1">Nom joueur 1</param>
        /// <param name="colorPlayer1">Couleur du joueur 1</param>
        /// <param name="namePlayer2">Nom du joueur 2</param>
        /// <param name="colorPlayer2">Couleur du joueur 2</param>
        /// <param name="playerBuild">Builder du second joueur</param>
        /// <param name="scenario">Builder du scenario</param>
        internal void play(String namePlayer1, Color colorPlayer1, String namePlayer2, Color colorPlayer2, Func<PlayerBuilder> playerBuild, Func<Scenario> scenario)
        {
            playerBuilder1.Name = namePlayer1;
            playerBuilder1.Color = System.Drawing.Color.FromArgb(colorPlayer1.A, colorPlayer1.R, colorPlayer1.G, colorPlayer1.B);

            playerBuilder2 = playerBuild();

            playerBuilder2.Name = namePlayer2;
            playerBuilder2.Color = System.Drawing.Color.FromArgb(colorPlayer2.A, colorPlayer2.R, colorPlayer2.G, colorPlayer2.B);

            gameBuilder.Scenario = scenario();

            gameBuilder.Player1 = playerBuilder1;
            gameBuilder.Player2 = playerBuilder2;

            mI.createGame(gameBuilder.build());
        }

        /// <summary>
        /// Getter de la visibilite
        /// </summary>
        public Visibility AccessButtonPlay
        {
            get
            {
                return this.accessButtonPlay;
            }
            set
            {
                this.accessButtonPlay = value;
                RaisePropertyChanged("AccessButtonPlay");
            }
        }
    }
}
