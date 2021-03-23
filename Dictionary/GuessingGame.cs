using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class GuessingGame
    {
        public List<Word> WordsToBeGuessed { get; set; }
        private static Random Rng = new Random();
        public int NoOfGuessedWords;
        public int IndexOfCurrentWord;

        public GuessingGame(int noOfWords)
        {
            if (MyDictionary.Words == null) return;

            if (MyDictionary.Words.Count < noOfWords) return;

            WordsToBeGuessed = new List<Word>();

            ShuffleExtension.Shuffle(MyDictionary.Words);
            for (int i = 0; i < noOfWords; i++)
            {
                WordsToBeGuessed.Add(MyDictionary.Words.ElementAt(i));
            }
        }

        public bool ShowTip()
        {
            if (Rng.Next() % 2 == 0 || WordsToBeGuessed.ElementAt(IndexOfCurrentWord).ImagePath.Equals
                    ("D:\\FACULT 2020-2021\\MVP\\Dictionary\\Dictionary\\Resources\\noimage.png"))
                return false;
            return true;
        }

        public bool GuessMade(string wordName)
        {
            if (wordName.ToLower() == WordsToBeGuessed.ElementAt(IndexOfCurrentWord).Name.ToLower())
                return true;
            return false;
        }

        public bool IsFinished()
        {
            if (IndexOfCurrentWord == WordsToBeGuessed.Count() - 1)
                return true;
            return false;
        }
    }
}
