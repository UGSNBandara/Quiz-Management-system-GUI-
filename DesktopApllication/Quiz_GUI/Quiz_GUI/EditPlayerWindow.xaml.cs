using Quiz_GUI.Models;
using Quiz_GUI.Stores;
using Quiz_GUI.ViewModels;
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

namespace Quiz_GUI
{
    /// <summary>
    /// Interaction logic for EditPlayerWindow.xaml
    /// </summary>
    public partial class EditPlayerWindow : Window
    {
        public EditPlayerWindow(Player player, PlayerDetailsViewModel playerDetails, PlayerListStore playerListStore)
        {
            InitializeComponent();
            var viewModel = new EditPlayerViewModel(player, playerListStore, playerDetails);
            this.DataContext = viewModel; // Set the DataContext to the ViewModel
        }
    }
}
