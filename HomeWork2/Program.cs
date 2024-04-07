// See https://aka.ms/new-console-template for more information
/*
 Всем привет, домашнее задание Считать строку текста из консоли (продвинутое задание: из файла).
Строка содержит буквы латинского алфавита, знаки препинания и цифры.
Реализовать меню выбора действий:
+ Найти слова, содержащие максимальное количество цифр.
+ Найти самое длинное слово и определить, сколько раз оно встретилось в тексте.
+ Заменить цифры от 0 до 9 на слова «ноль», «один», ..., «девять».
+ Вывести на экран сначала вопросительные, а затем восклицательные предложения.
- Вывести на экран только предложения, не содержащие запятых.
- Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву.
Приложение не должно падать ни при каких условиях
*/

String textFromFile = ReadFileHelpers.ReadAllWordsInFile();
Console.WriteLine(textFromFile);
/*
Console.WriteLine();
ReadFileHelpers.GetWordsWithMaxDigits(textFromFile);

Console.WriteLine();
ReadFileHelpers.GetLongestWordAndItsNumOccurrences(textFromFile);

Console.WriteLine();
ReadFileHelpers.InsertNumeralsInText(textFromFile);
*/
Console.WriteLine();
ReadFileHelpers.GetSentetencesWithExclamationPoint(textFromFile);

Console.WriteLine();
ReadFileHelpers.GetSentetencesWithQuestionMark(textFromFile);