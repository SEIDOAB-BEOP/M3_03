using System;


namespace BOOPM3_03_01
{
    class Program
    {
		struct RectangleStruct
		{
            public double d1 { get; set; }
            public double d2 { get; set; }
            public double d3 { get; set; }
            public double d4 { get; set; }

			public decimal m1 { get; set; }
            public decimal m2 { get; set; }
            public decimal m3 { get; set; }
            public decimal m4 { get; set; }

            public double Width { get; set; }
			public double Height { get; set; }
			public double Diagonal => Math.Sqrt(Width * Width + Height * Height);

			public RectangleStruct(double width, double height)
			{
				Width = width;
				Height = height;
			}
		}
		class RectangleClass
		{
            public double d1 { get; set; }
            public double d2 { get; set; }
            public double d3 { get; set; }
            public double d4 { get; set; }

            public decimal m1 { get; set; }
            public decimal m2 { get; set; }
            public decimal m3 { get; set; }
            public decimal m4 { get; set; }

			public double Width { get; set; }
			public double Height { get; set; }
			public double Diagonal => Math.Sqrt(Width * Width + Height * Height);

			public RectangleClass(double width, double height)
			{
				Width = width;
				Height = height;
			}
		}

		static void Main(string[] args)
		{
			const long arraySize = 10_000;
			long size1 = GC.GetTotalMemory(true);

			//Roughly 
			RectangleStruct[] arrayStruct = new RectangleStruct[arraySize];
			for (int i = 0; i < arraySize; i++)
			{
				arrayStruct[i] = new RectangleStruct(5,5);
            }

			long size2 = GC.GetTotalMemory(true);
			//Console.WriteLine($"Rough size of {nameof(arrayStruct)} immediatly allocated estimate: {2 * sizeof(double) * arraySize:N0} bytes");
			Console.WriteLine($"Rough size of {nameof(arrayStruct)} immediatly allocated by GC:  {size2-size1:N0} bytes");
			Console.WriteLine();

			//Roughly 
			RectangleClass[] arrayClass = new RectangleClass[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                arrayClass[i] = new RectangleClass(5, 5);
            }

			long size3 = GC.GetTotalMemory(true);
			
			//Console.WriteLine($"Rough size of {nameof(arrayClass)} immediatly allocated estimate: {sizeof(long) * arraySize:N0} bytes");
			Console.WriteLine($"Rough size of {nameof(arrayClass)} immediatly allocated by GC:  {size3 - size2:N0} bytes");
		}
	}
}
