/*

Задача 41: 

1. Пользователь вводит количество чисел. Программа выбирает случайным образои нужное количество чисел и подсчитывает количество положительных среди них.
2. Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.

0, 7, 8, -2, -2 -> 2
1, -7, 567, 89, 223-> 3


*/

// Метод возвращает число из консоли
int GetNumber(string message)
{
    int result = 0;
    string errorMessage = "Вы ввели не число. Введите корректное число.";

    while (true)
    {

        Console.Write(message);

        if (int.TryParse(Console.ReadLine(), out result))
        {
            break;
        }
        else
        {
            Console.Clear();
            Console.WriteLine(errorMessage);
        }
    }

    return result;
}

// Метод возвращает заполненный массив заданной размерности 
int[] GetArray(int len)
{
    int[] arr = new int[len];
    Random randomizer = new Random();

    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = randomizer.Next(-99, 100);
    }

    return arr;
}

// Метод выводит в консоль массив и подсчитывает количесвтво положительных элементов
int CountAndPrint(int[] array)
{
    int result = 0;
    foreach (int item in array)
    {
        if (item > 0) result++;
        Console.Write($"{item} ");
    }

    return result;
}

// Метод проверяет элемент на >0, увеличивает счетчик, возвращает false, если элемент не распознан как число
bool CheckElement(string num, ref int result)
{
    int number;

    if (int.TryParse(num, out number))
    {
        if (number > 0) result++;
        return true;
    }
    else return false;

}

// Метод возвращает количество положительных чисел и факт ошибки при парсинге 
(int, bool) CountPositive(string msg)
{
    int result = 0;
    bool error = false;
    string num = string.Empty;

    //    Console.WriteLine($"Длина строки = {msg.Length}");

    for (int i = 0; i < msg.Length; i++)
    {
        if (msg[i] == ',')
        {

            if (!CheckElement(num, ref result))
            {
                //                Console.WriteLine($"error:  i = {i},    num = {num},    result = {result}");
                error = true;
                break;
            }
            else num = string.Empty;
        }
        else
        {
            if (i == msg.Length - 1)
            {
                if (!CheckElement(string.Concat(string.Empty, msg[i]), ref result)) error = true;
                //            Console.WriteLine($"i == msg.Length-1:  i = {i},    num = {num},    result = {result}");
            }
            else if (msg[i] != ' ')
            {
                num = string.Concat(num, msg[i]);
                //            Console.WriteLine($"msg[i] != ' ':  i = {i}    num = {num}    result = {result}");
            }
        }
    }
    return (result, error);
}

int number = GetNumber("Введите количество чисел: ");
int[] array = GetArray(number);
int count = CountAndPrint(array);
Console.WriteLine();
Console.WriteLine($"Среди заданных чисел {count} положительных.");

Console.Write("Введите числа вручную через запятую: ");
string numbers = Console.ReadLine();
(int cnt, bool err) = CountPositive(numbers);
if (!err) Console.WriteLine($"Среди введенных чисел {cnt} положительных!");
else Console.WriteLine("Данные введены некорректно");
