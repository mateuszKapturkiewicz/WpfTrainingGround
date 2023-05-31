using MasteringWpf.Controls.Enums;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using MediaColor = System.Windows.Media.Color;

namespace MasteringWpf.Controls
{
    [TemplatePart(Name = "PART_Background", Type = typeof(Ellipse))]
    [TemplatePart(Name = "PART_Glow", Type = typeof(Ellipse))]
    public class Sphere : Control
    {
        private RadialGradientBrush greenBackground =
            new RadialGradientBrush(new GradientStopCollection()
            {
                new GradientStop(MediaColor.FromRgb(0,254,0),0),
                new GradientStop(MediaColor.FromRgb(1,27,0),0.974),
            });

        private RadialGradientBrush greenGlow =
            new RadialGradientBrush(new GradientStopCollection()
            {
                new GradientStop(MediaColor.FromArgb(205,67,255,46),0),
                new GradientStop(MediaColor.FromArgb(102,88,254,72),0.426),
                new GradientStop(MediaColor.FromArgb(0,44,191,32),1),
            });

        private RadialGradientBrush redBackground =
            new RadialGradientBrush(new GradientStopCollection()
            {
                new GradientStop(MediaColor.FromRgb(254,0,0),0),
                new GradientStop(MediaColor.FromRgb(27,0,0),0.974),
            });

        private RadialGradientBrush redGlow =
            new RadialGradientBrush(new GradientStopCollection()
            {
                new GradientStop(MediaColor.FromArgb(205,255,46,46),0),
                new GradientStop(MediaColor.FromArgb(102,254,72,72),0.426),
                new GradientStop(MediaColor.FromArgb(0,191,32,32),1),
            });

        static Sphere()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Sphere), new FrameworkPropertyMetadata(typeof(Sphere)));
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(double), typeof(Sphere), new PropertyMetadata(50.0));

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(nameof(Color), typeof(SphereColor), typeof(Sphere), new PropertyMetadata(SphereColor.Green, OnColorChanged));


        public SphereColor Color
        {
            get { return (SphereColor)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        private static void OnColorChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            ((Sphere)dependencyObject).SetEllipseColors();
        }

        public override void OnApplyTemplate()
        {
            SetEllipseColors();
        }

        private void SetEllipseColors()
        {
            Ellipse backgroundElipse = GetTemplateChild("PART_Background") as Ellipse;
            Ellipse glowElilipse = GetTemplateChild("PART_Glow") as Ellipse;

            if (backgroundElipse != null)
            {
                backgroundElipse.Fill = Color == SphereColor.Green ? greenBackground : redBackground;
            }
            if (glowElilipse != null)
            {
                glowElilipse.Fill = Color == SphereColor.Green ? greenGlow : redGlow;
            }
            base.OnApplyTemplate();
        }
    }
}
