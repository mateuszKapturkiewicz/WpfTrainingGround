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
        public MainWindow()
        {
            InitializeComponent();

            CustomWindow customWindow = new CustomWindow();
            customWindow.Width = 225;
            customWindow.Height = 120;
            customWindow.FontSize = 18;
            customWindow.Padding = new Thickness(20);
            customWindow.Content = "Please see this message!";
            customWindow.Show();
        }
    }
}
