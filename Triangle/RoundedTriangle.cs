namespace Zeroit.Framework.MiscControls
{
    #region RoundedTriangle

    //class ZeroitRoundedTriangle : Control
    //{
    //    public ZeroitRoundedTriangle()
    //    {

    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        base.OnPaint(e);

    //        var G = e.Graphics;
    //        G.SmoothingMode = SmoothingMode.HighQuality;
    //        G.Clear(BackColor);

    //        PointF angular = new PointF(10, 10);

    //        this.DrawRoundedCorner(G, new PointF(0, 10), new PointF(30, 40), new PointF(10, 80), 5);
    //    }

    //    private void DrawRoundedCorner(Graphics graphics, PointF angularPoint,
    //                            PointF p1, PointF p2, float radius)
    //    {
    //        //Vector 1
    //        double dx1 = angularPoint.X - p1.X;
    //        double dy1 = angularPoint.Y - p1.Y;

    //        //Vector 2
    //        double dx2 = angularPoint.X - p2.X;
    //        double dy2 = angularPoint.Y - p2.Y;

    //        //Angle between vector 1 and vector 2 divided by 2
    //        double angle = (Math.Atan2(dy1, dx1) - Math.Atan2(dy2, dx2)) / 2;

    //        // The length of segment between angular point and the
    //        // points of intersection with the circle of a given radius
    //        double tan = Math.Abs(Math.Tan(angle));
    //        double segment = radius / tan;

    //        //Check the segment
    //        double length1 = GetLength(dx1, dy1);
    //        double length2 = GetLength(dx2, dy2);

    //        double length = Math.Min(length1, length2);

    //        if (segment > length)
    //        {
    //            segment = length;
    //            radius = (float)(length * tan);
    //        }

    //        // Points of intersection are calculated by the proportion between 
    //        // the coordinates of the vector, length of vector and the length of the segment.
    //        var p1Cross = GetProportionPoint(angularPoint, segment, length1, dx1, dy1);
    //        var p2Cross = GetProportionPoint(angularPoint, segment, length2, dx2, dy2);

    //        // Calculation of the coordinates of the circle 
    //        // center by the addition of angular vectors.
    //        double dx = angularPoint.X * 2 - p1Cross.X - p2Cross.X;
    //        double dy = angularPoint.Y * 2 - p1Cross.Y - p2Cross.Y;

    //        double L = GetLength(dx, dy);
    //        double d = GetLength(segment, radius);

    //        var circlePoint = GetProportionPoint(angularPoint, d, L, dx, dy);

    //        //StartAngle and EndAngle of arc
    //        var startAngle = Math.Atan2(p1Cross.Y - circlePoint.Y, p1Cross.X - circlePoint.X);
    //        var endAngle = Math.Atan2(p2Cross.Y - circlePoint.Y, p2Cross.X - circlePoint.X);

    //        //Sweep angle
    //        var sweepAngle = endAngle - startAngle;

    //        //Some additional checks
    //        if (sweepAngle < 0)
    //        {
    //            startAngle = endAngle;
    //            sweepAngle = -sweepAngle;
    //        }

    //        if (sweepAngle > Math.PI)
    //            sweepAngle = Math.PI - sweepAngle;

    //        //Draw result using graphics
    //        var pen = new Pen(Color.Black);

    //        graphics.Clear(Color.White);
    //        graphics.SmoothingMode = SmoothingMode.AntiAlias;

    //        graphics.DrawLine(pen, p1, p1Cross);
    //        graphics.DrawLine(pen, p2, p2Cross);

    //        var left = circlePoint.X - radius;
    //        var top = circlePoint.Y - radius;
    //        var diameter = 2 * radius;
    //        var degreeFactor = 180 / Math.PI;

    //        //One point for each degree. But in some cases it will be necessary 
    //        // to use more points. Just change a degreeFactor.
    //        int pointsCount = (int)Math.Abs(sweepAngle * degreeFactor);
    //        int sign = Math.Sign(sweepAngle);

    //        PointF[] points = new PointF[pointsCount];

    //        for (int i = 0; i < pointsCount; ++i)
    //        {
    //            var pointX =
    //               (float)(circlePoint.X
    //                       + Math.Cos(startAngle + sign * (double)i / degreeFactor)
    //                       * radius);

    //            var pointY =
    //               (float)(circlePoint.Y
    //                       + Math.Sin(startAngle + sign * (double)i / degreeFactor)
    //                       * radius);

    //            points[i] = new PointF(pointX, pointY);
    //        }

    //        graphics.DrawArc(pen, left, top, diameter, diameter,
    //                         (float)(startAngle * degreeFactor),
    //                         (float)(sweepAngle * degreeFactor));
    //    }

    //    private double GetLength(double dx, double dy)
    //    {
    //        return Math.Sqrt(dx * dx + dy * dy);
    //    }

    //    private PointF GetProportionPoint(PointF point, double segment,
    //                                      double length, double dx, double dy)
    //    {
    //        double factor = segment / length;

    //        return new PointF((float)(point.X - dx * factor),
    //                          (float)(point.Y - dy * factor));
    //    }
    //}
    #endregion
}
