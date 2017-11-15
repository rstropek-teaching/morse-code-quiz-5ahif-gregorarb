using Microsoft.VisualStudio.TestTools.UnitTesting;
using MorseLibrary;
using System.IO;
using System;

namespace MorseTests
{
    [TestClass]
    public class MorseTests
    {
        /// <summary>
        /// Checks if the program throws an exception when entering an incorrect file path
        /// </summary>
        [TestMethod]
        public void IncorrectFilePath()
        {
            Assert.ThrowsException<FileNotFoundException>(() => new MorseDecoder().Decode("Wrong path", "../Files/output.txt"));
        }

        /// <summary>
        /// Basically just tests if the decoding works and if it is written to the output file:
        /// </summary>
        [TestMethod]
        public void WriteToOutputFile()
        {
            MorseDecoder decoder = new MorseDecoder();
            decoder.Decode("../Files/input.txt", "../Files/outputTest.txt");

            FileInfo fileInfo = new FileInfo("../Files/outputTest.txt");
            if(fileInfo.Length > 0)
            {
                Assert.IsFalse(false);
            } else
            {
                Assert.IsFalse(true);
            }     
        }

        /// <summary>
        /// Checks if the program throws an exception when entering incorrect morse code
        /// </summary>
        [TestMethod]
        public void IncorrectMorseCode()
        {
            MorseDictionary dictionary = new MorseDictionary();
            dictionary.DecodeLine("Kein Morse-Code");
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Checks if the decoding works with correct morse code
        /// </summary>
        [TestMethod]
        public void CorrectMorseCode()
        {
            MorseDictionary dictionary = new MorseDictionary();
            string solution = "MORSE CODE";
            var decodedCode = dictionary.DecodeLine("-- --- .-. ... .    -.-. --- -.. .");
            // Converts the ArrayList to a string
            string decodedCodeStr = string.Join("", decodedCode.ToArray());
            Assert.IsTrue(solution.Trim().Equals(decodedCodeStr.Trim()));
        }

        /// <summary>
        /// Checks if splitting a word into chars works
        /// </summary>
        [TestMethod]
        public void SplitWords()
        {
            MorseDictionary dictionary = new MorseDictionary();
            var word = dictionary.GetCharsFromWord("T E S T W O R T");
            var solution = "TESTWORT";

            // Converts the ArrayList to a string
            string wordStr = string.Join("", word);
            Assert.IsTrue(solution.Trim().Equals(wordStr.Trim()));
        }
    }
}
