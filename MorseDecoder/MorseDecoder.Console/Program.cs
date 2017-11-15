using MorseLibrary;
using System;

namespace MorseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the path to the file with the morse code: ");
            string inputPath = Console.ReadLine();
            Console.WriteLine("Please enter the path to the file into which the decoded text should be written: ");
            string outputPath = Console.ReadLine();

            try { 
                MorseDecoder md = new MorseDecoder();
                md.Decode(inputPath, outputPath);
            } catch(Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
