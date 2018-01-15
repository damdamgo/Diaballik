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
    /// Logique d'interaction pour Board.xaml
    /// </summary>
    public partial class Board : UserControl
    {
        /// <summary>
        ///  Constructor <see cref="Board"/> class.
        /// </summary>
        /// <param name="board">Modele du plateau</param>
        /// <param name="game">Modele du jeu</param>
        public Board(Diaballik.Board board , Diaballik.Game game)
        {
            InitializeComponent();
            DataContext = new BoardModel(board, this.GridBoard,game);
        }
    }
}
