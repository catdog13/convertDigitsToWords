using System;
using System.Globalization;

namespace convertDigitsToWords
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter number to convert: ");
                string consoleInput = Console.ReadLine();
                // quit if need be
                if (consoleInput == "quit")
                {
                    break;
                }
                decimal convertNumber;
                // check to see if input is a valid number
                bool inNumber = decimal.TryParse(consoleInput, NumberStyles.Currency,
                    CultureInfo.CurrentCulture.NumberFormat, out convertNumber);
                // do these things if it is a number
                int intConvertNumber = (int)convertNumber;
                if (inNumber && intConvertNumber <= 9999)
                {
                    // declare my arrays
                    string[] ones =
                    {
                        "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
                        "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
                        "Seventeen", "Eightteen", "Nineteen"
                    };
                    string[] tens =
                    {
                        "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty",
                        "Ninety"
                    };
                    string outString = "";
                    if (intConvertNumber > 1000) // for numbers greter than 1000
                    {
                        int thousands = intConvertNumber / 1000;
                        outString = string.Concat(outString, $"{ones[thousands]} Thousand ");
                        intConvertNumber = intConvertNumber % 1000;
                    }
                    if (intConvertNumber <= 999 && intConvertNumber >= 100) // for number between 999 and 100
                    {
                        int hundreds = intConvertNumber / 100;
                        outString = string.Concat(outString, $"{ones[hundreds]} Hundred ");
                        intConvertNumber = intConvertNumber % 100;
                    }
                    if (intConvertNumber <= 99 && intConvertNumber >= 20) // for numbers between 99 and 20
                    {
                        int lessHundred = intConvertNumber / 10;
                        outString = string.Concat(outString, $"{tens[lessHundred]} ");
                        intConvertNumber = intConvertNumber % 10;
                    }
                    if (intConvertNumber <= 19 && intConvertNumber > 0) // for numbers bwetween 19 and 0
                    {
                        int lessTwenty = intConvertNumber / 1;
                        outString = string.Concat(outString, $"{ones[lessTwenty]} ");
                    }
                    Console.WriteLine($"{outString}dollars"); // outputs the sting that was built
                }
                // do this things if it isn't a valid input
                else
                {
                    Console.WriteLine("Please use a valid input.");
                }
            }
        }
    }
}