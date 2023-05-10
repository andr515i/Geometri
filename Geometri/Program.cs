using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
	public class Program
	{
		static void Main(string[] args)
		{
			double testA = -4.1;
			double testB = 13;
			double testC = 0.1;
			double testD = 48;
			double testAngle = 48;


			int amountOfShapesToCreateInForLoopOnLine33 = 1;  // amount of times the for loop should loop to create lines

			Square square = new Square(testA);
			parallelogram parallelogram = new parallelogram(testA, testB, testAngle);
			Rectangle rect = new Rectangle(testA, testB);
			Trapeze trapeze = new Trapeze(testA, testB, testC, testD);
			Triangle triangle = new Triangle(testA, testB, testC);

			List<Shape> shapes = new List<Shape>();

			for (int i = 0; i < amountOfShapesToCreateInForLoopOnLine33; i++)
			{
				shapes.Add(square);
				shapes.Add(parallelogram);
				shapes.Add(rect);
				shapes.Add(trapeze);
				shapes.Add(triangle);
			}



			foreach (Shape item in shapes)
			{
				Console.WriteLine(item.Area());
				Console.WriteLine(item.Perimeter());
			}



			Console.ReadLine();
		}
	}

	public abstract class Shape
	{
		private string shapeName;

		public string ShapeName
		{
			get { return shapeName; }
			set { shapeName = value; }
		}

		// since it makes no sense to have any shape be negative lengths, lets make sure they always are positive. 
		protected double a;

		protected double A
		{
			get { return a; }
			set
			{
				try // we make sure the length of the given value is positive so we make shapes that actually makes sense, and not some 4th dimensional supertetrahedra type goofy shapes.
				{
					if (value > 0) a = value;
					else
					{
						throw new NumberWasNegativeException();   // wanted to try a custom exception 
					}

				}
				catch (NumberWasNegativeException)
				{
					Console.WriteLine($"Side a was a negative for {GetType()}, converting to positive number");
					a = -value;
				}
			}
		}

		protected double b;

		internal double B
		{
			get { return b; }
			set
			{
				try // we make sure the length of the given value is positive so we make shapes that actually makes sense, and not some 4th dimensional supertetrahedra type goofy shapes.
				{
					if (value > 0) b = value;
					else
					{
						throw new NumberWasNegativeException();   // wanted to try a custom exception 
					}

				}
				catch (NumberWasNegativeException)
				{
					Console.WriteLine($"Side b was a negative for {GetType()}, converting to positive number");
					b = -value;
				}
			}
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
			this.A = A;
		}
		public Shape(double A, double B)
		{
			this.A = A;
			this.B = B;
		}
	}
	public class Square : Shape
	{
		public Square(double A) : base(A)
		{
			ShapeName = "Square";
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
			set { if (value < 180 && value > 0) angle = value; }
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

			GetHeightAndSemiPerimeter();
		}

		private void GetHeightAndSemiPerimeter()
		{
			s = (A + B - C + D) / 2;
			height = (2 / (A - C)) * (Math.Sqrt(s * (s - A + C) * (s - B) * (s - D)));
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
			return A * A;
		}
		public override double Area()
		{
			return 4 * A;
		}
	}

	public class Triangle : Shape
	{
		private double c;

		public double C
		{
			get { return c; }
			set
			{
				try
				{
					if (value > 0) c = value;  // we make sure the length of the given value is positive so we make shapes that actually makes sense, and not some 4th dimensional supertetrahedra type goofy shapes.
					else
					{
						throw new NumberWasNegativeException();   // wanted to try a custom exception 
					}

				}
				catch (NumberWasNegativeException)
				{
					Console.WriteLine($"Side c was a negative {GetType()}, converting to positive number");
					c = -value;
				}
			}
		}
		public Triangle(double A, double B, double C) : base(A, B)
		{
			this.c = C;
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



