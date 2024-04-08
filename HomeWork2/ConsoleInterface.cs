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

        public static void OperationsMenu()
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

        public static void MakeOperationsOnText(string numberOfOperation, string textFromFile)
        {
            switch (numberOfOperation)
            {
                case "1":
                    TextHandler.GetWordsWithMaxDigits(textFromFile);
                    Console.WriteLine("\nНажмите любую клавишу чтобы продолжить");
                    Console.ReadKey(true);
                    break;
                case "2":
                    TextHandler.GetLongestWordAndItsNumOccurrences(textFromFile);
                    Console.WriteLine("\nНажмите любую клавишу чтобы продолжить");
                    Console.ReadKey(true);
                    break;
                case "3":
                    TextHandler.InsertNumeralsInText(textFromFile);
                    Console.WriteLine("\nНажмите любую клавишу чтобы продолжить");
                    Console.ReadKey(true);
                    break;
                case "4":
                    TextHandler.GetSentencesWithExclamationPoint(textFromFile);
                    TextHandler.GetSentencesWithQuestionMark(textFromFile);
                    Console.WriteLine("\nНажмите любую клавишу чтобы продолжить");
                    Console.ReadKey(true);
                    break;
                case "5":
                    TextHandler.GetSentencesWithoutWashedDown(textFromFile);
                    Console.WriteLine("\nНажмите любую клавишу чтобы продолжить");
                    Console.ReadKey(true);
                    break;
                case "6":
                    TextHandler.GetWordsStartsAnsEndWithTheSameLetter(textFromFile);
                    Console.WriteLine("\nНажмите любую клавишу чтобы продолжить");
                    Console.ReadKey(true);
                    break;
            }
        }
    }
}
