using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dictionary
{
    class MyDictionary
    {
        public static List<Word> Words { get; set; }
        private const string myWords = @"..\..\Resources\words.json";

        public static void InitializeDictionary()
        {
            try
            {
                string jsonString = File.ReadAllText(myWords);
                Words = JsonSerializer.Deserialize<List<Word>>(jsonString);
            }
            catch (IOException)
            {
                Words = new List<Word>();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public static void FinalizeDictionary()
        {
            string jsonString = JsonSerializer.Serialize(Words);
            File.WriteAllText(myWords, jsonString);
        }

        public static void AddWord(string inputName, string inputDescription, string inputCategory, string path)
        {
            if (path == null)
            {
                Word word = new Word(inputName, inputDescription, inputCategory);
                Words.Add(word);
            }
            else
            {
                Word word = new Word(inputName, inputDescription, inputCategory, path);
                Words.Add(word);
            }
        }

        public static void UpdateWord(string wordName, string inputName, string inputDescription, string inputCategory)
        {
            var wordToBeUpdated = Words.Find(w => (w.Name.Equals(wordName)));
            wordToBeUpdated.Name = inputName;
            wordToBeUpdated.Description = inputDescription;
            wordToBeUpdated.Category = inputCategory;
        }

        public static void RemoveWord(string wordName)
        {
            Words.Remove(Words.Find(w => (w.Name.Equals(wordName))));
        }
    }
}
