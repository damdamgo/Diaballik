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
using DiaballikGame.Utils;
using DiaballikGame.Welcome;

namespace DiaballikGame.MenuDiaballik
{
    /// <summary>
    /// Logique d'interaction pour MenuDiaballik.xaml
    /// </summary>
    public partial class MenuDiaballik : UserControl, GameStateObserver
    {
        /// <summary>
        ///Constructeur <see cref="MenuDiaballik"/> class.
        /// </summary>
        /// <param name="mI">Acces à la fenetre principale.</param>
        public MenuDiaballik(MainInterface mI)
        {
            InitializeComponent();
            DataContext = new MenuDiaballikModel(mI);
        }

        /// <summary>
        /// Notifier changement de l'etat de la fenetre
        /// </summary>
        /// <param name="state">Etat de la fenetre</param>
        public void notify(Utils.Properties.STATE_GAME state)
        {
            switch (state)
            {
                case Utils.Properties.STATE_GAME.GAME:
                    menuItem.Visibility = Visibility.Visible;
                    saveItem.Visibility = Visibility.Visible;
                    break;
                case Utils.Properties.STATE_GAME.REPLAY:
                    menuItem.Visibility = Visibility.Visible;
                    saveItem.Visibility = Visibility.Collapsed;
                    break;
                case Utils.Properties.STATE_GAME.MENU:
                    menuItem.Visibility = Visibility.Collapsed;
                    saveItem.Visibility = Visibility.Collapsed;
                    break;

            }
        }


    }
}
