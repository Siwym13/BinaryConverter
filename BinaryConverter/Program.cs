using System;

namespace BinaryConverter
{
    class Program
    {
        static int number;
        static int bin;
        static int place;
        static int max;
        static bool ifNumber;

        static void Main()
        {
            Console.WriteLine("Welcome to the number converter");
            Console.WriteLine("Choose options:");
            Console.WriteLine("1. Convert from decimal to binary");
            Console.WriteLine("2. Convert from binary to decimal");
            Console.WriteLine("3. Creator ");
            Console.WriteLine("4. Exit");

            int.TryParse(Console.ReadLine(), out int select);
            switch (select)
            {
                case 1:
                    Console.Clear();
                    Program.EnterDecimalNumber();
                    break;
                case 2:
                    Console.Clear();
                    Program.EnterBinaryNumber();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Program created by Mateusz Tórz");
                    Console.WriteLine("Press any button to continue");
                    Console.ReadKey();
                    Console.Clear();
                    Program.Main();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Please enter a valid choice");
                    Console.WriteLine();
                    Program.Main();
                    break;
            }
        }
        static void EnterDecimalNumber()
        {
            Console.WriteLine("Give a number");
            ifNumber = int.TryParse(Console.ReadLine(), out number);
            if (ifNumber)
            {
                int[] result = ConvertToBinary(number);
                for (int i = 0; i < result.Length; i++)
                {
                    Console.Write(result[i]);
                }
                Console.WriteLine();
                Console.WriteLine("Press the '1' key to convert to another number, or any button to continue");
                int.TryParse(Console.ReadLine(), out int select);
                if (select == 1)
                {
                    Console.Clear();
                    Program.EnterDecimalNumber();
                }
                else
                {
                    Console.Clear();
                    Program.Main();
                }
                Console.Clear();
                Program.Main();
            }
            else
            {
                Console.WriteLine("Please enter a valid number");
                Console.WriteLine("Press any button to continue ");
                Console.ReadLine();
                Console.Clear();
                Program.EnterDecimalNumber();
            }

        }
        static void EnterBinaryNumber()
        {
            Console.WriteLine("Please enter some binary number");
            string binary = Console.ReadLine();
            bool ifNumberB = int.TryParse(binary, out int numberBin);
            int i = binary.Length;
            char[] numb = new char[i];
            int place = 0;
            bool ifBinary = false;

            for (int a = 0; a < i; a++)
            {
                numb[place] = binary[place];
                if (numb[place] - '0' == 1 || numb[place] - '0' == 0)
                {
                    ifBinary = true;
                }
                else
                {
                    ifBinary = false;
                }
                place++;
            }

            if (ifNumberB)
            {
                if (ifBinary)
                {
                    Console.WriteLine(Program.ConvertToDecimal(binary));
                    Console.WriteLine();
                    Console.WriteLine("Press the '1' key to convert to another number, or any button to continue ");
                    int.TryParse(Console.ReadLine(), out int select);
                    if (select == 1)
                    {
                        Console.Clear();
                        Program.EnterBinaryNumber();
                    }
                    else
                    {
                        Console.Clear();
                        Program.Main();
                    }

                }
                else
                {
                    Console.WriteLine("Please enter a valid number ");
                    Console.WriteLine("Press any button to continue ");
                    Console.ReadLine();
                    Console.Clear();
                    Program.EnterBinaryNumber();
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number");
                Console.WriteLine("Press any button to continue ");
                Console.ReadLine();
                Console.Clear();
                Program.EnterBinaryNumber();
            }
        }
        static int[] ConvertToBinary(int number)
        {
            max = 0;
            int numberM = number;
            while (numberM > 0)
            {
                numberM = numberM / 2;
                max++;
            }
            place = max;
            int[] numberBin = new int[max];
            place--;
            while (number > 0)
            {
                bin = number % 2;
                number = number / 2;
                numberBin[place] = bin;
                place--;
            }

            return numberBin;
        }
        static int ConvertToDecimal(string binary)
        {
            int endResult = 0;
            int result;
            int a = 0;

            for (int i = binary.Length - 1; i >= 0; i--)
            {
                int number = binary[i] - '0';
                result = (int)(number * Math.Pow(2, a));
                a++;
                endResult += result;
            }

            return endResult;

        }
    }
}
