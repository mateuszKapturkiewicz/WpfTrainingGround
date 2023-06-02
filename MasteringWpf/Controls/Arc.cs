using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MasteringWpf.Controls
{
    public class Arc : Shape
    {
        public static readonly DependencyProperty StartAngleProperty =
            DependencyProperty.Register(nameof(StartAngle), typeof(double), typeof(Arc), new PropertyMetadata(180.0));

        public double StartAngle
        {
            get { return (double)GetValue(StartAngleProperty); }
            set { SetValue(StartAngleProperty, value); }
        }

        public static readonly DependencyProperty EndAngleProperty =
            DependencyProperty.Register(nameof(EndAngle), typeof(double), typeof(Arc), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public double EndAngle
        {
            get { return (double)GetValue(EndAngleProperty); }
            set { SetValue(EndAngleProperty, value); }
        }

        protected override Geometry DefiningGeometry
        {
            get { return GetArcGeometry(); }
        }

        public Geometry GetArcGeometry()
        {
            Point startPoint = ConvertToPoint(Math.Min(StartAngle, EndAngle));
            Point endPoint = ConvertToPoint(Math.Max(StartAngle, EndAngle));
            Size arcSize = new Size(
                Math.Max(0, (RenderSize.Width - StrokeThickness) / 2),
                Math.Max(0, (RenderSize.Height - StrokeThickness) / 2));
            bool isLargeArc = Math.Abs(EndAngle - StartAngle) > 180;
            StreamGeometry streamGeometry = new StreamGeometry();
            using (StreamGeometryContext context = streamGeometry.Open())
            {
                context.BeginFigure(startPoint, false, false);
                context.ArcTo(endPoint, arcSize, 0, isLargeArc, SweepDirection.Counterclockwise, true, false);
            }
            streamGeometry.Transform = new TranslateTransform(StrokeThickness / 2, StrokeThickness / 2);
            streamGeometry.Freeze();
            return streamGeometry;

        }

        private Point ConvertToPoint(double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * Math.PI / 180;
            double radiusX = (RenderSize.Width - StrokeThickness) / 2;
            double radiusY = (RenderSize.Height - StrokeThickness) / 2;
            return new Point(radiusX * Math.Cos(angleInRadians) + radiusX,
                radiusY * Math.Sin(-angleInRadians) + radiusY);
        }
    }
}
