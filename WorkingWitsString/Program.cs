using System;
using System.Linq;

namespace WorkingWitsString
{
    class Program
    {
        static bool IsTextCorrect (string str)
        {

            bool f = true;
            for (int i = 0; i < str.Length; i++)
            {
                if (!(Char.IsLetter(str[i]) || Char.IsPunctuation(str[i]) || Char.IsWhiteSpace(str[i])))
                    f = false;
            }
            return f;
        }
        static string LargestWord(string str)
        {
            char[] PunctuationMarks = { ' ', ',', '.', ':', '-', '(', ')', '!', '?' };
            var allWords = str.Split(PunctuationMarks, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int maxLength = allWords[1].Length;
            string maxWord = allWords[1];
            for (int i = 0; i < allWords.Length; i++)
            {
                if (maxLength < allWords[i].Length)
                {
                    maxLength = allWords[i].Length;
                    maxWord = allWords[i];
                }    
            }
            return maxWord;
        }
        static string CoorectMax(string str)
        {
            string maxWord = LargestWord(str);
            if (maxWord.Length % 2 == 0)
                maxWord = maxWord.Substring(maxWord.Length / 2);
            else
            {
                maxWord = maxWord.Replace(maxWord[maxWord.Length / 2], '*');
            }
            return maxWord;
        }
        static string[] SentenceArray(string str)
        {
            string[] PunctuationMarks = {".", "(", ")", "!", "?",". ", "! ", "? " };
            var sentence = str.Split(PunctuationMarks, StringSplitOptions.RemoveEmptyEntries).ToArray();
            return sentence;
        }
        static int NumberOfPunctuationMarks(string str)
        {
            int nWords = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsPunctuation(str[i]))
                    nWords++;
            }
            return nWords;
        }

        static string[] UniqueWordsArray(string str)
        {
            char[] PunctuationMarks = { ' ', ',', '.', ':', '-', '(', ')', '!', '?' };
            var uniqeWords = str.Split(PunctuationMarks, StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
           return uniqeWords;

        }
        static void Main(string[] args)
        {
            string str;
            bool f;
            int count=0;
            do
            {
                if (count > 0)
                {
                    Console.Clear();
                    Console.WriteLine("некорректный ввод. попробуйте еще раз");
                }
                str = Console.ReadLine();
                f = IsTextCorrect(str);
                count++;
            }
            while (!f);

            Console.WriteLine($"количество знаков препинания: { NumberOfPunctuationMarks(str)}");

            Console.WriteLine("предложения текста: ");
            var output = SentenceArray(str);
            foreach (var i in output)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("уникальные слова текста: ");
            var output2 = UniqueWordsArray(str);
            foreach (var i in output2)
            {
                Console.WriteLine(i,',');
            }

            Console.WriteLine($"самое длинное слово: {LargestWord(str)} : {CoorectMax(str)}");

        }
    }
}
