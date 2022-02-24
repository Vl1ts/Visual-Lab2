using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class RomanNumber : ICloneable, IComparable
    {
        private ushort value;
        private StringBuilder? stringValue;
        //Конструктор получает число n, которое должен представлять объект
        public RomanNumber(ushort n)
        {
            try
            {
                if (n < 1 || n > 3999)
                {
                    throw new RomanNumberException("Incorrect number: out of range!");
                }

                value = (ushort)n;
                stringValue = new StringBuilder();

                const ushort combinationAmount = 7 + 6;
                ushort[] combinationValues = new ushort[combinationAmount] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
                string[] combinationStringValues = new string[combinationAmount] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

                for (int i = 0; i < combinationAmount; ++i)
                {
                    while (n >= combinationValues[i])
                    {
                        stringValue.Append(combinationStringValues[i]);
                        n -= combinationValues[i];
                    }
                }

                if (stringValue == null)
                {
                    throw new RomanNumberException("Construction failed!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        //Сложение римских чисел
        public static RomanNumber Add(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
            {
                throw new RomanNumberException("One of numbers is null!");
            }

            return new RomanNumber((ushort)(n1.value + n2.value));
        }
        //Вычитание римских чисел
        public static RomanNumber Sub(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
            {
                throw new RomanNumberException("One of numbers is null!");
            }

            return new RomanNumber((ushort)(n1.value - n2.value));
        }
        //Умножение римских чисел
        public static RomanNumber Mul(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
            {
                throw new RomanNumberException("One of numbers is null!");
            }

            return new RomanNumber((ushort)(n1.value * n2.value));
        }
        //Целочисленное деление римских чисел
        public static RomanNumber Div(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
            {
                throw new RomanNumberException("One of numbers is null!");
            }

            return new RomanNumber((ushort)(n1.value / n2.value));
        }
        //Возвращает строковое представление римского числа
        public override string ToString()
        {
            if (stringValue == null)
            {
                throw new RomanNumberException("Number is null!");
            }

            return stringValue.ToString();
        }
        //Реализация интерфейса IClonable
        public object Clone()
        {
            return new RomanNumber(value);
        }
        //Реализация интерфейса IComparable
        public int CompareTo(object? obj)
        {
            if (obj == null)
            {
                return 1;
            }

            RomanNumber? new_obj = obj as RomanNumber;

            return value.CompareTo(new_obj.value);
        }
    }
}
