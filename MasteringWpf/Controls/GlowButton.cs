﻿using MasteringWpf.Controls.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace MasteringWpf.Controls
{
    [TemplatePart(Name ="PART_Root", Type =typeof(Grid))]
    public class GlowButton : ButtonBase
    {
        private RadialGradientBrush glowBrush = null;

        static GlowButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GlowButton), new FrameworkPropertyMetadata(typeof(GlowButton)));
        }


        public GlowMode GlowMode { get; set; } = GlowMode.FullCenterMovement;

        public static readonly DependencyProperty GlowColorProperty = 
            DependencyProperty.Register(nameof(GlowColor), typeof(Color), typeof(GlowButton), new PropertyMetadata(Color.FromArgb(121, 71, 0, 255), OnGlowColorChanged));

        public Color GlowColor
        {
            get { return (Color)GetValue(GlowColorProperty); }
            set { SetValue(GlowColorProperty, value); }
        }

        private static void OnGlowColorChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            ((GlowButton)dependencyObject).SetGlowColor((Color)e.NewValue);
        }

        public override void OnApplyTemplate()
        {
            Grid rootGrid = GetTemplateChild("PART_Root") as Grid;
            if (rootGrid != null)
            {
                rootGrid.MouseMove += Grid_MouseMove;
                glowBrush = (RadialGradientBrush)rootGrid.FindResource("GlowBrush");
                SetGlowColor(GlowColor);
            }
        }

        private void SetGlowColor(Color value)
        {
            GlowColor = Color.FromArgb(121, value.R, value.G, value.B);
            if (glowBrush != null)
            {
                GradientStop gradientStop = glowBrush.GradientStops[2];
                gradientStop.Color = GlowColor;
            }
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            Grid grid = (Grid)sender;
            if (grid.IsMouseOver && glowBrush != null)
            {
                Point mousePosition = e.GetPosition(grid);
                double x = mousePosition.X / ActualWidth;
                double y = GlowMode != GlowMode.HorizontalCenterMovement ? mousePosition.Y / ActualHeight : glowBrush.Center.Y;
                glowBrush.Center = new Point(x, y);
                if (GlowMode == GlowMode.HorizontalCenterMovement) glowBrush.GradientOrigin = new Point(x, glowBrush.GradientOrigin.Y);
                else if (GlowMode == GlowMode.FullCenterMovement) glowBrush.GradientOrigin = new Point(x, y);
            }
        }
    }
}
