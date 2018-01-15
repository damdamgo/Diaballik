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
using DiaballikGame.Game;
using DiaballikGame.Utils;

namespace DiaballikGame.Welcome
{
    /// <summary>
    /// Logique d'interaction pour ChoiceGameView.xaml
    /// </summary>
    public partial class ChoiceGameView : UserControl
    {
        /// <summary>
        /// Modele de la vue
        /// </summary>
        private ModelChoiceGame model;

        /// <summary>
        /// Constructeur <see cref="ChoiceGameView"/> class.
        /// </summary>
        /// <param name="mI">Acces à la fenetre principale.</param>
        public ChoiceGameView(MainInterface mI)
        {
            InitializeComponent();
            model = new ModelChoiceGame(mI);
            DataContext =  model;
        }

        /// <summary>
        /// Event de la sélection d'une action dans la liste view
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var dataContext = button.DataContext;
            ListBoxItem clickedListBoxItem = list_View.ItemContainerGenerator.ContainerFromItem(dataContext) as ListBoxItem;
            clickedListBoxItem.IsSelected = true;
            int index = 0;
            index = list_View.SelectedIndex;
            model.ActionOnItem(index);
        }
    }
}
