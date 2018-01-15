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
using Diaballik;

namespace DiaballikGame.Board
{
    /// <summary>
    /// Logique d'interaction pour TileView.xaml
    /// </summary>
    public partial class TileView : UserControl
    {
        private TileModel tileModel;

        /// <summary>
        /// Constructor <see cref="TileView"/> class.
        /// </summary>
        /// <param name="tile">Modele de la case</param>
        /// <param name="game">The game.</param>
        public TileView(Tile tile, Diaballik.Game game)
        {
            InitializeComponent();
            tileModel = new TileModel(tile, game);
            DataContext = tileModel;
        }

        /// <summary>
        /// Gestion du click
        /// </summary>
        /// <param name="sender">Objet de l'evenement</param>
        /// <param name="e">Donnees</param>
        private void clickAction(object sender, RoutedEventArgs e)
        {
            tileModel.click();
        }
    }
}
