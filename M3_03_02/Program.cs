using System;

namespace BOOPM3_03_02
{
    class Program
    {
		readonly struct immutableRectangleStruct
		{
			public readonly double Width { get; init; }
			public readonly double Height { get; init; }

			public static bool operator ==(immutableRectangleStruct r1, immutableRectangleStruct r2) => Equals(r1, r2);
			public static bool operator !=(immutableRectangleStruct r1, immutableRectangleStruct r2) => !Equals(r1, r2);

			public override string ToString() =>
				$"{nameof(immutableRectangleStruct)} {{ {nameof(Width)}={Width}, {nameof(Height)}={Height} }}";
			public immutableRectangleStruct(double width, double height)
			{ 
				(Width, Height) = (width, height);
			}
			public immutableRectangleStruct GetQuad()
			{
				var result = new immutableRectangleStruct { Height = 2 * this.Height, Width = 2 * this.Width };
				return result;
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
			public immutableRectangleClass GetQuad()
			{
				var result = new immutableRectangleClass(this.Width *2, this.Height*2);
				return result;
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
			Console.WriteLine(irs1.GetQuad());
			Console.WriteLine();

			var irc1 = new immutableRectangleClass { Width = 400, Height = 100 };
			var irc2 = new immutableRectangleClass(irc1);
			var irc3 = new immutableRectangleClass();
			Console.WriteLine(irc1);
			Console.WriteLine(irc1 == irc2);
			Console.WriteLine(irc1 == irc3);
			Console.WriteLine(irc1.GetQuad());
		}
	}
}
//2.    In your solution DeckOfCards, make an immutable version of PlayingCard.

