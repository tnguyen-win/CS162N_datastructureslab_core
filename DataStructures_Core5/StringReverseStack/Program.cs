using System;
using System.Collections.Generic;

namespace StringReverseStack {
    class Program {
        static void Main() {
            Console.Write("Enter a sentence/phrase: ");

            string promptString = Console.ReadLine();

            Stack<char> stackOfStrings = new Stack<char>();

            for (int s = 0; s < promptString.Length; s++) stackOfStrings.Push(promptString[s]);

            Console.WriteLine($"\n\nHere is your sentence in reverse:");

            foreach (char str in stackOfStrings) Console.Write(str);

            Console.WriteLine("\n");
        }
    }
}