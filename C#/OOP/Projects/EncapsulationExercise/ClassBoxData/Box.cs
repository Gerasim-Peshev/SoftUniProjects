using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Lenght
        {
            get { return this.length; }
            private set
            {
                if (value > 0)
                { this.length = value; }
                else
                {
                    throw new ArgumentException("Lenght cannot be zero or negative.");
                }
            }
        }
        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value > 0)
                { this.width = value; }
                else
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
            }
        }
        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value > 0)
                { this.height = value; }
                else
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
            }
        }

        public double SurfaceArea()
        {
            return (2 * this.Lenght * this.Height) + (2 * this.Width * this.Height) + (2 * this.Lenght * this.Width);
        }

        public double LateralSurfaceArea()
        {
            return (2 * this.Lenght * this.Height) + (2 * this.Width * this.Height);
        }

        public double Volume()
        {
            return this.Lenght * this.Width * this.Height;
        }
    }
}
