using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    public static class ConsoleInterface
    {
        public static void OutputOfProgramTitle()
        {
            Console.Clear();
            var programTitle = "Программа для работы с тесктовыми файлами С#\r";
            Console.WriteLine(programTitle);
            Console.WriteLine(new string('-', programTitle.Length));
            Console.WriteLine();
        }

        public static string GetPathToTheFile()
        {
            string path = Console.ReadLine();
            while (File.Exists(path) == false)
            {
                Console.WriteLine("Не верный путь к файлу, введите путь до файла еще раз: ");
                path = Console.ReadLine();
            }

            return path;
        }

        internal static void OperationsMenu(string pathToFile)
        {
            Console.Clear();
            OutputOfProgramTitle();
            Console.WriteLine("""
                              Список доступных операций текстом в вашем файле:
                                1 - Найти слова, содержащие максимальное количество цифр.
                                2 - Найти самое длинное слово и определить, сколько раз оно встретилось в тексте.
                                3 - Заменить цифры от 0 до 9 на слова «ноль», «один», ..., «девять».
                                4 - Вывести на экран сначала вопросительные, а затем восклицательные предложения.
                                5 - Вывести на экран только предложения, не содержащие запятых.
                                6 - Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву.
                              """);
            Console.Write("\nВведите номер операции, который вы хотите сделать, или выведите 'q' для выхода из программы: ");
        }

        internal static void MakeOperationsOnText(string numberOfOperation, string pathToFile)
        {
            switch (numberOfOperation)
            {
                case "1":
                    TextHandler.GetWordsWithMaxDigits(pathToFile);
                    break;
                case "2":
                    TextHandler.GetLongestWordAndItsNumOccurrences(pathToFile);
                    break;
                case "3":
                    TextHandler.InsertNumeralsInText(pathToFile);
                    break;
                case "4":
                    TextHandler.GetSentencesWithExclamationPoint(pathToFile);
                    TextHandler.GetSentencesWithQuestionMark(pathToFile);
                    break;
                case "5":
                    TextHandler.GetSentencesWithoutWashedDown(pathToFile);
                    break;
                case "6":
                    TextHandler.GetWordsStartsAnsEndWithTheSameLetter(pathToFile);
                    break;
            }
        }
    }
}
