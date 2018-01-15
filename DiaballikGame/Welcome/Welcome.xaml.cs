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
using System.Windows.Shapes;
using DiaballikGame.Game;
using DiaballikGame.Utils;
using MaterialDesignThemes.Wpf;

namespace DiaballikGame.Welcome
{
    /// <summary>
    /// Logique d'interaction pour Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        /// <summary>
        /// Constructeur <see cref="Welcome"/> class.
        /// </summary>
        public Welcome()
        {
            //InitializeComponent();
            DataContext = new WelcomeModel(this);
        }
    }
}
