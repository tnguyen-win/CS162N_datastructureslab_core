using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryNumbersQueue {
    class Program {
        static void Main() {
            Queue<string> allBinaryNumbers = new Queue<string>();

            allBinaryNumbers.Enqueue("0000"); // 0
            allBinaryNumbers.Enqueue("0001"); // 1
            allBinaryNumbers.Enqueue("0010"); // 2
            allBinaryNumbers.Enqueue("0011"); // 3
            allBinaryNumbers.Enqueue("0100"); // 4
            allBinaryNumbers.Enqueue("0101"); // 5
            allBinaryNumbers.Enqueue("0110"); // 6
            allBinaryNumbers.Enqueue("0111"); // 7
            allBinaryNumbers.Enqueue("1000"); // 8
            allBinaryNumbers.Enqueue("1001"); // 9
            allBinaryNumbers.Enqueue("1010"); // 10
            allBinaryNumbers.Enqueue("1011"); // 11
            allBinaryNumbers.Enqueue("1100"); // 12
            allBinaryNumbers.Enqueue("1101"); // 13
            allBinaryNumbers.Enqueue("1110"); // 14
            allBinaryNumbers.Enqueue("1111"); // 15

            Console.Write("Enter a number between 0-15: ");

            try {
                int promptInt = int.Parse(Console.ReadLine());

                if (promptInt >= 0 && promptInt <= 15) Console.WriteLine($"\n\n\nHere is your sentence in binary:\n{allBinaryNumbers.ElementAt(promptInt)}\n\n");
                else Console.WriteLine("\n\n\nYou did not enter a number between 0-15. Try again.\n\n");
            } catch (FormatException) {
                Console.WriteLine("\n\n\nYou did not enter a number. Try again.\n\n");
            }
        }
    }
}