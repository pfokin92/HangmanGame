using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HangmanGame
{
    class Hangman
    {
        private string guessWord { get; set; }
        private int errors { get; set; }
        public string hiddenWord { get; set; }
        public Hangman()
        {
            guessWord = getWord();
        }
        private string getWord()
        {
            Random random = new Random();
            string[] allLines = File.ReadAllLines("WordsStockRus.txt");
            int index = random.Next(0, allLines.Length - 1);
            return allLines[index];
        }
        private void showChar(char insertChar, int lengthWord)
        {
            string temp = "";
            for (int i = 0; i < lengthWord; i++)
            {
                if (guessWord[i] == insertChar)
                {
                    temp += guessWord[i];
                }
                else if (hiddenWord[i] != '_')
                {
                    temp += hiddenWord[i];
                }
                else
                {
                    temp += "_";
                }
            }
            hiddenWord = temp;
        }
        public void startGame()
        {
            int lengthWord = guessWord.Length;
            string insertChar;
            for (int i = 0; i < lengthWord; i++)
            {
                hiddenWord += "_";
            }
            do
            {
                Console.WriteLine(hiddenWord);
                insertChar = Console.ReadLine();
                if (insertChar.ToCharArray().Length != 1)
                {
                    Console.WriteLine("Enter 1 char");
                }
                else if (hiddenWord.Contains(insertChar))
                {
                    Console.WriteLine("This char was here");
                }
                else if (guessWord.Contains(insertChar))
                {
                    showChar(insertChar.ToCharArray()[0], lengthWord);
                }
                else
                {
                    errors += 1;
                }
                Console.WriteLine($"{6 - errors} tries left");

            } while (errors < 6 && hiddenWord != guessWord);
            if (hiddenWord == guessWord)
            {
                Console.WriteLine("You win");
            }
            else
            {
                Console.WriteLine($"You lose\nWord:\n{guessWord}");
            }
            Console.ReadLine();
        }
    }
}
