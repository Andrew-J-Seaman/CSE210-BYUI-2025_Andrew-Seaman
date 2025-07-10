using System;
using System.Globalization;

namespace Learning05
{
    abstract class Shape
    {
        // ATTRIBUTES

        // A1.
        protected string _num;
        // A2.
        protected string _color; // Paper color; different for each shape
        

        // CONSTRUCTOR

        // C1.
        public Shape(string num, string color)
        {
            _num = num;
            _color = color;
        }

        // GETTERS AND SETTERS

        // G1.
        public string GetColor()
        {
            return _color;
        }

        // S1.
        public void SetColor(string color)
        {
            _color = color;
        }

        // G2.
        public string GetNum()
        {
            return _num;
        }

        // G3.
        public abstract double GetArea(); // Area is calculated differently.

    }
}

