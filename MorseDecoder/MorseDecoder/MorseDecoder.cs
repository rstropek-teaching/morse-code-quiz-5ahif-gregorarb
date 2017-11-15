using System;
using System.IO;

namespace MorseLibrary
{
    public class MorseDecoder
    {
        private MorseDictionary MorseDict { get; set; }

        // Constructor
        public MorseDecoder() => MorseDict = new MorseDictionary();

        /// <summary>
        /// Reads from a file and writes to a different file
        /// This allows the text to decode to be very long (file can hold more letters than a string)
        /// </summary>
        /// <param name="InputFile_Path">Path of the file to be read from</param>
        /// <param name="OutputFile_Path">Path of the file to be written to</param>
        public void Decode(string InputFile_Path, string OutputFile_Path) {
            // for reading from a file
            string CurrentLine;
            try
            { 
                // if the input file cannot the found, the output file will not be created
                using (var readerFile = new StreamReader(InputFile_Path))
                using (var writer = new StreamWriter(OutputFile_Path))
                {
                    // goes through all lines
                    while ((CurrentLine = readerFile.ReadLine()) != null)
                    {
                        // decodes all words in a line
                        foreach (string item in MorseDict.DecodeLine(CurrentLine))
                        {
                            // Check if an unknown character, unknown morse code or something like that was found
                            // if yes, just don't decode that line
                            if (MorseDict.UnknownChar)
                            {
                                Console.Error.WriteLine("There was an unknown character in your morse code");
                            } else
                            {
                                // writes a word to the stream
                                writer.Write(item);
                            } 
                        }
                        writer.WriteLine();
                    }
                    readerFile.Close();
                }
            }
            catch (Exception e)
            {
                // Writes the error message to stderr
                Console.Error.Write(e.Message);
            }
        }
    }
}
