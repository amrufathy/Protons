using System;

namespace Geometry
{
    internal class ProtonsPoint
    {
        private double x;
        private double y;

        //ProtonsPoint p = new ProtonsPoint(x,y)
        //Puts x in X
        //Puts y in Y
        public ProtonsPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double Distance(ProtonsPoint anotherP)
        {
            return Math.Sqrt(Math.Pow(this.x - anotherP.x, 2)
                + Math.Pow(this.y - anotherP.y, 2));
        }

        public double Slope(ProtonsPoint anotherP)
        {
            return (this.y - anotherP.y) / (this.x - anotherP.x);
        }

        public void MoveTo(double newX, double newY)
        {
            this.x = newX;
            this.y = newY;
        }

        public string TransformToString()
        {
            return $"({x},{y})";
        }
    }
}