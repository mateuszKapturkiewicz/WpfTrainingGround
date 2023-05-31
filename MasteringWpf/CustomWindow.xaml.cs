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

namespace MasteringWpf
{
    /// <summary>
    /// Interaction logic for CustomWindow.xaml
    /// </summary>
    public partial class CustomWindow : Window
    {
        public CustomWindow()
        {
            MouseLeftButtonDown += (o, e) => DragMove();
            InitializeComponent();
        }

        static CustomWindow()
        {
            BorderBrushProperty.OverrideMetadata(typeof(CustomWindow), new FrameworkPropertyMetadata(
                new SolidColorBrush(Color.FromArgb(255, 238, 156, 88))));
            HorizontalContentAlignmentProperty.OverrideMetadata(typeof(CustomWindow), new FrameworkPropertyMetadata(HorizontalAlignment.Center));
            VerticalContentAlignmentProperty.OverrideMetadata(typeof(CustomWindow), new FrameworkPropertyMetadata(VerticalAlignment.Center));
        }

        public new Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        public new static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register(nameof(Background), typeof(Brush), typeof(CustomWindow),
                new PropertyMetadata(
                    new LinearGradientBrush(Colors.White, Color.FromArgb(255, 250, 191, 143), 90)));


    }
}
