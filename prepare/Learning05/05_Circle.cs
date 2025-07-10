using System;

namespace Learning05
{
    class Circle : Shape
    {
        // ATTRIBUTES

        // A1.
        private double _radius; // Radius for circles; not used in other shapes

        // CONSTRUCTORS

        // C1.
        public Circle(string num, string color, double radius) : base(num, color)
        {
            _radius = radius;
        }

        // GETTERS AND SETTERS

        // G1.
        public override double GetArea()
        {
            // Calcualte are of circle
            return (double)(Math.PI * _radius * _radius);
        }
    }
}
