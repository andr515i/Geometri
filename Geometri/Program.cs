using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
	public class Program
	{
		static void Main(string[] args)
		{
			double testA = 4.1;
			double testB = 13;
			double testC = 0.1;
			double testD = 48;
			double testAngle = 48;

			Square square = new Square(testA);
			parallelogram parallelogram = new parallelogram(testA, testB, testAngle);
			Rectangle rect  = new Rectangle(testA, testB);
			Trapeze trapeze = new Trapeze(testA, testB, testC, testD);
			Triangle triangle = new Triangle(testA, testB, testC);

			Console.WriteLine("Square Perimeter: " + square.Perimeter());
			Console.WriteLine("Square Area: " + square.Area());

			Console.WriteLine("Parallelogram Perimeter: " + parallelogram.Perimeter());
			Console.WriteLine("Parallelogram Area: " + parallelogram.Area());

			Console.WriteLine("Trapeze Perimeter: " + trapeze.Perimeter());
			Console.WriteLine("Trapeze Area: " + trapeze.Area());

			Console.WriteLine("rect Perimeter: " + rect.Perimeter());
			Console.WriteLine("rect Area: " + rect.Area());

			Console.WriteLine("triangle Perimeter: " + triangle.Perimeter());
			Console.WriteLine("triangle Area: " + triangle.Area());





			Console.ReadLine();
		}
	}

	public abstract class Shape
	{


		protected double a;

		internal double A
		{
			get { return a; }
			set { a = value; }
		}

		protected double b;

		internal double B
		{
			get { return b; }
			set { b = value; }
		}



		/// <summary>
		/// Omkreds
		/// </summary>
		/// <returns>double</returns>
		public abstract double Perimeter();

		/// <summary>
		/// areal
		/// </summary>
		/// <returns>double</returns>
		public abstract double Area();

		public Shape(double A)
		{
			a = A;
		}
		public Shape(double A, double B)
		{
			a = A;
			b = B;
		}
	}
	public class Square : Shape
	{
		public Square(double A) : base(A)
		{

		}

		public override double Perimeter()
		{
			return 4 * A;
		}
		public override double Area()
		{
			return A * A;
		}
	}
	public class parallelogram : Shape
	{
		protected double angle;

		internal double Angle
		{
			get { return angle; }
			set { angle = value; }
		}
		public parallelogram(double A, double B, double Angle) : base(A, B)
		{
			angle = Angle;
		}
		public override double Perimeter()
		{
			return 2 * A + 2 * B;
		}
		public override double Area()
		{
			return A * B * Math.Sin(angle * (Math.PI / 180));
		}
	}

	public class Trapeze : Shape
	{
		protected double c;

		internal double C
		{
			get { return c; }
			set { c = value; }
		}
		protected double d;

		internal double D
		{
			get { return d; }
			set { d = value; }
		}

		private double s;
		private double height;
		public Trapeze(double A, double B, double C, double D) : base(A, B)
		{
			c = C;
			d = D;


		}

		private void GetHeightAndSemiPerimeter()
		{
			s = (a + b - c + d) / 2;
			height = (2 / (a - c)) * (Math.Sqrt(s * (s - a + c) * (s - b) * (s - d)));
		}
		public override double Perimeter()
		{
			return A + B + C + D;
		}
		public override double Area()
		{
			return 0.5 * (a + b) * height;
		}
	}

	public class Rectangle : Shape
	{
		public Rectangle(double A, double B) : base(A, B)
		{

		}

		public override double Perimeter()
		{
			return 4 * A;
		}
		public override double Area()
		{
			return A * A;
		}
	}

	public class Triangle : Shape
	{
		private double c;
		public Triangle(double A, double B, double C) : base(A, B)
		{
			c = C;
		}
		public override double Perimeter()
		{
			return a + b + c;
		}
		public override double Area()
		{
			return 0.5 * a * b;
		}
	}

}



