using System;

namespace Learning05
{
    class Rectangle : Shape
    {
        // ATTRIBUTES

        // A1.
        private double _length;
        // A2.
        private double _width;

        // CONSTRUCTORS

        // C1.
        public Rectangle(string num, string color, double length, double width) : base(num, color)
        {
            _length = length;
            _width = width;
         }

        // GETTERS AND SETTERS

        // G1.
        public override double GetArea()
        {
            // Calcualte area of rectangle
            return (double)(_length * _width);
        }
    }
}
