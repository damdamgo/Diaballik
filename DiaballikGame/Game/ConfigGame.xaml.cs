using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DiaballikGame.Welcome;
using Diaballik;

namespace DiaballikGame.Game
{
    /// <summary>
    /// Logique d'interaction pour ConfigGame.xaml
    /// </summary>
    public partial class ConfigGame : UserControl
    {
        /// <summary>
        /// Lambda du scenario
        /// </summary>
        private Func<Scenario> scenario = null;
        /// <summary>
        /// Lambda pour la construction du second joueur
        /// </summary>
        private Func<PlayerBuilder> playerBuild = null;
        /// <summary>
        /// Modele de la vue
        /// </summary>
        private GameConfigModel gameConfig= null;

        /// <summary>
        ///Constructeur <see cref="ConfigGame"/> class.
        /// </summary>
        /// <param name="mI">Lien vers l'interface de la fenetre</param>
        public ConfigGame(MainInterface mI)
        {
            InitializeComponent();
            gameConfig = new GameConfigModel(mI);
            DataContext = gameConfig;
        }


        /// <summary>
        /// Selection du type humain
        /// </summary>
        private void IsHuman(object sender, RoutedEventArgs e)
        {
            playerBuild = () => { return new PlayerHumanBuilder(); };
            updatePlayButton();
        }

        /// <summary>
        /// Le second joueur sera de type IA
        /// </summary>
        private void IsAI(object sender, RoutedEventArgs e)
        {
            playerBuild = null;
            updatePlayButton();
            Level_AI.IsEnabled = true;
        }

        /// <summary>
        /// Le second joueur ne sera pas de type IA
        /// </summary>
        private void IsNotAI(object sender, RoutedEventArgs e)
        {
            Level_AI.IsEnabled = false;
        }

        /// <summary>
        /// L'IA sera de type noob
        /// </summary>
        private void IsNoob(object sender, RoutedEventArgs e)
        {
            playerBuild = () => {
                PlayerIABuilder p = new PlayerIABuilder();
                p.IaStrategy = new Noob();
                return p;
            };
            updatePlayButton();
        }


        /// <summary>
        /// L'IA sera de type starting
        /// </summary>
        private void IsStarting(object sender, RoutedEventArgs e)
        {
            playerBuild = () => {
                PlayerIABuilder p = new PlayerIABuilder();
                p.IaStrategy = new Starting();
                return p;
            };
            updatePlayButton();
        }

        /// <summary>
        /// L'IA sera de type progressive
        /// </summary>
        private void IsProgressive(object sender, RoutedEventArgs e)
        { 
            playerBuild = () => {
                PlayerIABuilder p = new PlayerIABuilder();
                p.IaStrategy = new Progressive();
                return p;
            };
            updatePlayButton();
        }

        /// <summary>
        /// Selection du scenario standart
        /// </summary>
        private void IsStandart(object sender, RoutedEventArgs e)
        {
            scenario = () => { return new Standart(); };
            updatePlayButton();
        }

        /// <summary>
        /// Selection du scenario ball random
        /// </summary>
        private void IsBallRandom(object sender, RoutedEventArgs e)
        {
            scenario = () => { return new BallRandom(); };
            updatePlayButton();
        }

        /// <summary>
        /// Selection du scenario enemy among us
        /// </summary>
        private void IsEnemyAmongUs(object sender, RoutedEventArgs e)
        {
            scenario = () => { return new EnemyAmongUs(); };
            updatePlayButton();
        }

        /// <summary>
        /// Creation de la partie
        /// </summary>
        private void Play(object sender, RoutedEventArgs e)
        {
            gameConfig.play(this.namePlayer1.Text.ToString(), colorPlayer1.SelectedColor,this.namePlayer2.Text.ToString(),colorPlayer2.SelectedColor,playerBuild,scenario);
        }

        /// <summary>
        /// Affichage du bouton pour la création de la partie
        /// </summary>
        public void updatePlayButton(object sender = null, TextChangedEventArgs e = null)
        {
            if(scenario != null && playerBuild != null && !this.namePlayer1.Text.ToString().Equals(this.namePlayer2.Text.ToString()) && !colorPlayer1.SelectedColor.Equals(colorPlayer2.SelectedColor))
            {
                gameConfig.AccessButtonPlay = Visibility.Visible;
            }
            else if(gameConfig!= null) gameConfig.AccessButtonPlay = Visibility.Hidden;
        }

        /// <summary>
        /// Event de la mise à jour de la couleur
        /// </summary>
        private void colorPlayer_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            updatePlayButton();
        }
    }
}
