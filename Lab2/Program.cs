using System;
using System.Text;

namespace Lab2
{
    public static class Program
    {
        static void Main()
        {
            Random rand = new Random();

            RomanNumber testNumber = new RomanNumber(783);
            RomanNumber AddSub = new RomanNumber(31);
            RomanNumber MulDiv = new RomanNumber(2);

            Console.WriteLine($"{testNumber.ToString()} + {AddSub.ToString()} = {RomanNumber.Add(testNumber, AddSub)}");
            Console.WriteLine($"{testNumber.ToString()} - {AddSub.ToString()} = {RomanNumber.Sub(testNumber, AddSub)}");
            Console.WriteLine($"{testNumber.ToString()} * {MulDiv.ToString()} = {RomanNumber.Mul(testNumber, MulDiv)}");
            Console.WriteLine($"{testNumber.ToString()} / {MulDiv.ToString()} = {RomanNumber.Div(testNumber, MulDiv)}");

            const ushort elementsAmount = 7;
            RomanNumber[] romanArray = new RomanNumber[elementsAmount];

            Console.WriteLine("\nBefore sorting: ");
            for (int i = 0; i < elementsAmount; ++i)
            {
                ushort number = (ushort)rand.Next(1, 3999);
                romanArray[i] = new RomanNumber(number);
                Console.WriteLine($"{number,5}   ->   {romanArray[i].ToString()}");
            }

            Console.WriteLine("\nAfter sorting: ");
            Array.Sort<RomanNumber>(romanArray);
            foreach (RomanNumber roman in romanArray)
            {
                Console.WriteLine(roman.ToString());
            }
        }
    }
}