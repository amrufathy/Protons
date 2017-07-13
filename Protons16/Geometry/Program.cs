using System;

namespace Geometry
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ProtonsPoint p = ReadPoint();
            ProtonsPoint otherP = ReadPoint();

            Console.WriteLine(p.Distance(otherP));

            p.MoveTo(5, 78);
            Console.WriteLine(p.TransformToString());

            Console.ReadKey();
        }

        private static ProtonsPoint ReadPoint()
        {
            Console.WriteLine("Enter the X coordinate of the point");
            string userInputX = Console.ReadLine();
            int xCoordinate = int.Parse(userInputX);

            Console.WriteLine("Enter the Y coordinate of the point");
            string userInputY = Console.ReadLine();
            int yCoordinate = int.Parse(userInputY);

            return new ProtonsPoint(xCoordinate, yCoordinate);
        }
    }
}