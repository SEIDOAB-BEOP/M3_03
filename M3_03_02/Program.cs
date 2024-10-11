using System;

namespace BOOPM3_03_02
{
    class Program
    {
		readonly struct immutableRectangleStruct
		{
			public double Width { get; init; }
			public double Height { get; init; }

			public static bool operator ==(immutableRectangleStruct r1, immutableRectangleStruct r2) => Equals(r1, r2);
			public static bool operator !=(immutableRectangleStruct r1, immutableRectangleStruct r2) => !Equals(r1, r2);

			public override string ToString() =>
				$"{nameof(immutableRectangleStruct)} {{ {nameof(Width)}={Width}, {nameof(Height)}={Height} }}";
			public immutableRectangleStruct(double width, double height)
			{ 
				(Width, Height) = (width, height);
			}
			public immutableRectangleStruct SetWith (double width)
			{
				return new immutableRectangleStruct { Width = width, Height = this.Height}; 
			}
			public immutableRectangleStruct SetHeight(double height)
			{
				return new immutableRectangleStruct { Width = this.Width, Height = height}; 
			}
			public void Deconstruct(out double width, out double height)
			{
				width = Width;
				height = Height;
			}
		}
		class immutableRectangleClass
		{
			public double Width { get; init; }
			public double Height { get; init; }

			public static bool Equals(immutableRectangleClass r1, immutableRectangleClass r2) =>
				(r1.Width, r1.Height) == (r2.Width, r2.Height);
            public static bool operator ==(immutableRectangleClass r1, immutableRectangleClass r2) => Equals(r1, r2);
			public static bool operator !=(immutableRectangleClass r1, immutableRectangleClass r2) => !Equals(r1, r2);
			public override string ToString() => 
				$"{nameof(immutableRectangleClass)} {{ {nameof(Width)}={Width}, {nameof(Height)}={Height} }}";
			public immutableRectangleStruct SetWith (double width)
			{
				return new immutableRectangleStruct { Width = width, Height = this.Height}; 
			}
			public immutableRectangleStruct SetHeight(double height)
			{
				return new immutableRectangleStruct { Width = this.Width, Height = height}; 
			}


			public immutableRectangleClass() { }
			public immutableRectangleClass(double width, double height) => (Width, Height) = (width, height);
			
			//Copy Constructor
			public immutableRectangleClass(immutableRectangleClass original)
			{
				Width = original.Width;
				Height = original.Height;
			}

			public void Deconstruct(out double width, out double height)
			{
				width = Width;
				height = Height;
			}
		}
		static void Main(string[] args)
        {
			var irs1 = new immutableRectangleStruct { Width = 400, Height = 100 };
			var irs2 = irs1;
			var irs3 = new immutableRectangleStruct ();
			Console.WriteLine(irs1);
			Console.WriteLine(irs1 == irs2);
			Console.WriteLine(irs1 == irs3);
			Console.WriteLine(irs1.SetHeight(25));
			Console.WriteLine(irs1.SetWith(25));
			Console.WriteLine();

			var irc1 = new immutableRectangleClass { Width = 400, Height = 100 };
			var irc2 = new immutableRectangleClass(irc1);
			var irc3 = new immutableRectangleClass();
			Console.WriteLine(irc1);
			Console.WriteLine(irc1 == irc2);
			Console.WriteLine(irc1 == irc3);
			Console.WriteLine(irc1.SetHeight(25));
			Console.WriteLine(irc1.SetWith(25));
		}
	}
}
//2.    In your solution DeckOfCards, make an immutable version of PlayingCard.

