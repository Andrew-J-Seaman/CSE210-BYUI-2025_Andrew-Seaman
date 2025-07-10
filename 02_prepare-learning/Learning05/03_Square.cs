using System;

namespace Learning05
{
    class Square : Shape
    {
        // ATTRIBUTES

        // A1.
        private double _side;

        // CONSTRUCTORS

        // C1.
        public Square(string num, string color, double side) : base(num, color)
        {
            _side = side;
         }

        // GETTERS AND SETTERS

        // G1.
        public override double GetArea()
        {
            // Calcualte are of square
            return (double)(_side * _side);
        }
        
    }
}
