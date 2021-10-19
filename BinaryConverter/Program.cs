using System;

namespace BinaryConverter
{
    class Program
    {

        static void Main()
        {
            Console.WriteLine("Welcome to the number converter");
            Console.WriteLine("Choose options:");
            Console.WriteLine("1. Convert from decimal to binary");
            Console.WriteLine("2. Convert from binary to decimal");
            Console.WriteLine("3. Creator ");
            Console.WriteLine("4. Exit");

            int select = int.Parse(Console.ReadLine());
            switch (select)
            {
                case 1:
                    Console.Clear();
                    EnterDecimalNumber();
                    break;
                case 2:
                    Console.Clear();
                    EnterBinaryNumber();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Program created by Mateusz Tórz");
                    Console.WriteLine("Press any button to continue");
                    Console.ReadKey();
                    Console.Clear();
                    Main();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Please enter a valid choice");
                    Console.WriteLine();
                    Main();
                    break;
            }
        }

        static void EnterDecimalNumber()
        {
            Console.WriteLine("Give a number");
            bool isNumber = int.TryParse(Console.ReadLine(), out int number);
            if (isNumber)
            {
                int[] result = ConvertToBinary(number);
                for (int i = 0; i < result.Length; i++)
                {
                    Console.Write(result[i]);
                }
                Console.WriteLine();
                Console.WriteLine("Press the '1' key to convert to another number, or any button to continue");
                int select = int.Parse(Console.ReadLine());
                Console.Clear();
                if (select == 1)
                {
                    EnterDecimalNumber();
                }
                else
                {
                    Main();
                }
                Console.Clear();
                Main();
            }
            else
            {
                Console.WriteLine("Please enter a valid number");
                Console.WriteLine("Press any button to continue ");
                Console.ReadLine();
                Console.Clear();
                EnterDecimalNumber();
            }

        }

        static void EnterBinaryNumber()
        {
            Console.WriteLine("Please enter some binary number");
            string binary = Console.ReadLine();
            bool isNumberB = int.TryParse(binary, out int numberBin);
            int lenght = binary.Length;
            char[] numb = new char[lenght];
            int place = 0;
            bool isBinary = false;

            for (int a = 0; a < lenght; a++)
            {
                numb[place] = binary[place];
                if (numb[place] - '0' == 1 || numb[place] - '0' == 0)
                {
                    isBinary = true;
                }
                else
                {
                    isBinary = false;
                }
                place++;
            }

            if (isNumberB)
            {
                if (isBinary)
                {
                    Console.WriteLine(ConvertToDecimal(binary));
                    Console.WriteLine();
                    Console.WriteLine("Press the '1' key to convert to another number, or any button to continue ");
                    int select = int.Parse(Console.ReadLine());
                    if (select == 1)
                    {
                        Console.Clear();
                        EnterBinaryNumber();
                    }
                    else
                    {
                        Console.Clear();
                        Main();
                    }

                }
                else
                {
                    Console.WriteLine("Please enter a valid number ");
                    Console.WriteLine("Press any button to continue ");
                    Console.ReadLine();
                    Console.Clear();
                    EnterBinaryNumber();
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number");
                Console.WriteLine("Press any button to continue ");
                Console.ReadLine();
                Console.Clear();
                EnterBinaryNumber();
            }
        }

        static int[] ConvertToBinary(int number)
        {
            int bin;
            int max = 0;
            int numberMax = number;
            while (numberMax > 0)
            {
                numberMax /= 2;
                max++;
            }
            int place = max;
            int[] numberBin = new int[max];
            place--;
            while (number > 0)
            {
                bin = number % 2;
                number /= 2;
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
