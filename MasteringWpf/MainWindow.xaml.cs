using MasteringWpf.ViewModels;
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

namespace MasteringWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Initialises a new MainWindow object.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Closed += MainWindow_Closed;

            CustomWindow customWindow = new CustomWindow();
            customWindow.Width = 225;
            customWindow.Height = 120;
            customWindow.FontSize = 18;
            customWindow.Padding = new Thickness(20);
            customWindow.Content = "Please see this message!";
            customWindow.Show();

            int renderingTier = RenderCapability.Tier >> 16;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            viewModel.LoadSettings();
            DataContext = viewModel;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            MainWindowViewModel viewModel = (MainWindowViewModel)DataContext;
            viewModel.SaveSettings();
        }


    }
}
