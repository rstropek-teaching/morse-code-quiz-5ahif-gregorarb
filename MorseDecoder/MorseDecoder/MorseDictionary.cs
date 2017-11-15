using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MorseLibrary
{
    public class MorseDictionary
    {
        // Used to store string pairs - perfect for assigning a morse code to a letter/number
        private Dictionary<string, string> DecryptionDictionary { get; set; }
        public Boolean UnknownChar { get; set; }

        public MorseDictionary()
        {
            AssignLettersAndNumbers();
        }

        /// <summary>
        /// Fills the dictionary with all letters and numbers from the "International Morse Code"
        /// </summary>
        private void AssignLettersAndNumbers()
        {
            DecryptionDictionary = new Dictionary<string, string>
            {
                // All letters
                { "A", ".-" },
                { "B", "-..." },
                { "C", "-.-." },
                { "D", "-.." },
                { "E", "." },
                { "F", "..-." },
                { "G", "--." },
                { "H", "...." },
                { "I", ".." },
                { "J", ".---" },
                { "K", "-.-" },
                { "L", ".-.." },
                { "M", "--" },
                { "N", "-." },
                { "O", "---" },
                { "P", ".--." },
                { "Q", "--.-" },
                { "R", ".-." },
                { "S", "..." },
                { "T", "-" },
                { "U", "..-" },
                { "V", "...-" },
                { "W", ".--" },
                { "X", "-..-" },
                { "Y", "-.--" },
                { "Z", "--.." },
                // All numbers
                { "1", ".----" },
                { "2", "..---" },
                { "3", "...--" },
                { "4", "....-" },
                { "5", "....." },
                { "6", "-...." },
                { "7", "--..." },
                { "8", "---.." },
                { "9", "----." },
                { "0", "-----" }
            };
        }

        /// <summary>
        /// Extracts all words in the current line of the file
        /// </summary>
        /// <param name="CurrentLine">Current line of a file, words are extracted in this line</param>
        /// <returns>all words in the current line as a string array</returns>
        public String[] GetWords(string CurrentLine)
        {
            // words are separated using 4 blanks
            string[] wordsInCurrentLine = CurrentLine.Split("    ");
            return wordsInCurrentLine;
        }

        /// <summary>
        /// Extracs all chars of the given word
        /// </summary>
        /// <param name="CurrentWord">Current word that should be split into chars</param>
        /// <returns>all chars of the given word</returns>
        public String[] GetCharsFromWord(string CurrentWord)
        {
            // chars are separated using single blanks
            string[] charsOfCurrentWord = CurrentWord.Split(" ");
            return charsOfCurrentWord;
        }

        /// <summary>
        /// splits a line into words, the words into chars, decodes the chars and put them together to words again
        /// </summary>
        /// <param name="currentLine">current line to be decoded</param>
        /// <returns>the decoded line</returns>
        public ArrayList DecodeLine(string currentLine)
        {
            UnknownChar = false;
            ArrayList DecodedLine = new ArrayList();
            string[] EncodedWords = GetWords(currentLine); ;
            string[] EncodedChars;
            string DecodedWord = "";

            foreach (string currentWord in EncodedWords)
            {
                EncodedChars = GetCharsFromWord(currentWord);
                foreach (string currentChar in EncodedChars)
                {
                    // Gets the key (Number, letter) that matches the morse code in currentChar and adds it to the DecodedWord
                    var key = DecryptionDictionary.FirstOrDefault(morseCode => morseCode.Value == currentChar).Key;
                    if(key==null || key.Trim() == "")
                    {
                        UnknownChar = true;
                    } else
                    {
                        DecodedWord += key;
                    }
                }
                DecodedLine.Add(DecodedWord);
                // add a whitespace to seperate two words
                DecodedLine.Add(" ");
                DecodedWord = "";
            }

            return DecodedLine;
        }
    }
}

