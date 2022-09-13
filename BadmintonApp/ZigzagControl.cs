using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace BadmintonApp
{
    public class ZigzagControl : Control
    {
        Point[] _points;
        PointF[] _leftpoints;
        PointF[] _rightpoints;
        PointF[] _boundpoints;
        int _thickness;
        int _pointnum;
        public ZigzagControl(Point[] points, int thickness = 1)
        {
            _points = points;
            _thickness = thickness;
            _pointnum = _points.Length;
            LineColor = Color.Black;
            _leftpoints = new PointF[_pointnum];
            _rightpoints = new PointF[_pointnum];
            CalcBoundPoints();
            CalcControlSizeAndLocation();
        }
        private void CalcFirstPointPair()
        {
            float u0, v0, p0, q0;
            double x0, y0, x1, y1;
            double dx, dy, l;
            double w = _thickness;
            x0 = _points[0].X;
            y0 = _points[0].Y;
            x1 = _points[1].X;
            y1 = _points[1].Y;

            dx = x1 - x0;
            dy = y1 - y0;
            l = Math.Sqrt(dx * dx + dy * dy);

            u0 = (float)(x0 + w * dy / l);
            v0 = (float)(y0 - w * dx / l);
            _leftpoints[0] = new PointF(u0, v0);

            p0 = (float)(x0 - w * dy / l);
            q0 = (float)(y0 + w * dx / l);
            _rightpoints[0] = new PointF(p0, q0);

        }
        private void CalcMidlePointPair(int pairIndex)
        {
            float u, v, p, q;
            double u1, v1, u2, v2;
            double p1, q1, p2, q2;
            double x1, y1, x2, y2, x3, y3;
            double dx, dy, l;
            double a11, a12, b1;
            double a21, a22, b2;
            double det, det1, det2;
            double w = _thickness;

            x1 = _points[pairIndex - 1].X;
            y1 = _points[pairIndex - 1].Y;
            x2 = _points[pairIndex].X;
            y2 = _points[pairIndex].Y;
            x3 = _points[pairIndex + 1].X;
            y3 = _points[pairIndex + 1].Y;

            dx = x2 - x1;
            dy = y2 - y1;
            l = Math.Sqrt(dx * dx + dy * dy);
            u1 = x1 + w * dy / l;
            v1 = y1 - w * dx / l;

            a11 = y2 - y1;
            a12 = -(x2 - x1);
            b1 = (y2 - y1) * u1 - (x2 - x1) * v1;

            dx = x3 - x2;
            dy = y3 - y2;
            l = Math.Sqrt(dx * dx + dy * dy);
            u2 = x2 + w * dy / l;
            v2 = y2 - w * dx / l;

            a21 = y3 - y2;
            a22 = -(x3 - x2);
            b2 = (y3 - y2) * u2 - (x3 - x2) * v2;

            det = a11 * a22 - a21 * a12;
            det1 = b1 * a22 - b2 * a12;
            det2 = a11 * b2 - a21 * b1;
            u = (float)(det1 / det);
            v = (float)(det2 / det);
            _leftpoints[pairIndex] = new PointF(u, v);

            dx = x2 - x1;
            dy = y2 - y1;
            l = Math.Sqrt(dx * dx + dy * dy);
            p1 = x1 - w * dy / l;
            q1 = y1 + w * dx / l;

            a11 = y2 - y1;
            a12 = -(x2 - x1);
            b1 = (y2 - y1) * p1 - (x2 - x1) * q1;

            dx = x3 - x2;
            dy = y3 - y2;
            l = Math.Sqrt(dx * dx + dy * dy);
            p2 = x2 - w * dy / l;
            q2 = y2 + w * dx / l;

            a21 = y3 - y2;
            a22 = -(x3 - x2);
            b2 = (y3 - y2) * p2 - (x3 - x2) * q2;

            det = a11 * a22 - a21 * a12;
            det1 = b1 * a22 - b2 * a12;
            det2 = a11 * b2 - a21 * b1;
            p = (float)(det1 / det);
            q = (float)(det2 / det);
            _rightpoints[pairIndex] = new PointF(p, q);

        }
        private void CalcLastPointPair()
        {
            float un, vn, pn, qn;
            double xn, yn, xn_1, yn_1;
            double dx, dy, l;
            double w = _thickness;
            int n = _pointnum - 1;
            xn = _points[n].X;
            yn = _points[n].Y;
            xn_1 = _points[n - 1].X;
            yn_1 = _points[n - 1].Y;

            dx = xn_1 - xn;
            dy = yn_1 - yn;
            l = Math.Sqrt(dx * dx + dy * dy);

            pn = (float)(xn + w * dy / l);
            qn = (float)(yn - w * dx / l);
            _rightpoints[n] = new PointF(pn, qn);

            un = (float)(xn - w * dy / l);
            vn = (float)(yn + w * dx / l);
            _leftpoints[n] = new PointF(un, vn);
        }
        private void CalcBoundPoints()
        {
            int i;

            CalcFirstPointPair();
            for (i = 1; i < _pointnum - 1; i++) CalcMidlePointPair(i);
            CalcLastPointPair();

            int j = 0;
            int n = 2 * _pointnum + 1;
            _boundpoints = new PointF[n];
            for (i = 0; i < _pointnum; i++)
            {
                _boundpoints[j] = _leftpoints[i];
                j++;
            }
            for (i = _pointnum - 1; i >= 0; i--)
            {
                _boundpoints[j] = _rightpoints[i];
                j++;
            }

            _boundpoints[n - 1] = _leftpoints[0];
        }
        private void CalcControlSizeAndLocation()
        {
            float minX, minY, maxX, maxY;
            minX = maxX = _leftpoints[0].X;
            minY = maxY = _leftpoints[0].Y;
            int n = _boundpoints.Length;
            for (int i = 0; i < n; i++)
            {
                if (_boundpoints[i].X < minX) minX = _boundpoints[i].X;
                if (_boundpoints[i].X > maxX) maxX = _boundpoints[i].X;
                if (_boundpoints[i].Y < minY) minY = _boundpoints[i].Y;
                if (_boundpoints[i].Y > maxY) maxY = _boundpoints[i].Y;
            }

            int width = (int)Math.Ceiling(maxX - minX);
            int height = (int)Math.Ceiling(maxY - minY);

            this.Size = new Size(width, height);
            this.Location = new Point((int)minX, (int)minY);

            for (int i = 0; i < n; i++)
            {
                _boundpoints[i].X -= minX;
                _boundpoints[i].Y -= minY;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddLines(_boundpoints);
            this.Region = new Region(graphicsPath);
        }
        public Color LineColor
        {
            get
            {
                return BackColor;
            }
            set
            {
                if (value == BackColor) return;
                BackColor = value;
            }
        }
        public int Thickness
        {
            get
            {
                return _thickness;
            }
            set
            {
                if (value == _thickness) return;
                _thickness = value;
                CalcBoundPoints();
                CalcControlSizeAndLocation();
                Invalidate();
            }
        }
    }
}
