/*

Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.

b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; 5,5)

*/

// Метод возвращает число из консоли
double GetNumber(string message)
{
    double result = 0;
    string errorMessage = "Вы ввели не число. Введите корректное число.";

    while (true)
    {

        Console.Write(message);

        if (double.TryParse(Console.ReadLine(), out result))
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

// Метод ищет координаты точки пересечения прямых y = k1 * x + b1,  y = k2 * x + b2
void FoundXY(double k1, double b1, double k2, double b2)
{
    double x, y;
    
    // Прямые параллельны, точек пересечения нет
    if (k1 == k2)
    {
        Console.WriteLine("Прямые параллельны, точек пересечения нет");
    }
    // В остальных случаях вычисляем координаты
    else
    {
        x = (b2 - b1)/(k1 - k2);
        y = k2 * x + b2;
        Console.WriteLine();
        Console.WriteLine($"Точка пересечения: ({x}, {y}).");
    }
}



Console.WriteLine("Будем искать точку пересечения двух прямых:");
Console.WriteLine("y = k1 * x + b1");
Console.WriteLine("y = k2 * x + b2");
double k1 = GetNumber("Введите k1 = ");
double b1 = GetNumber("Введите b1 = ");
double k2 = GetNumber("Введите k2 = ");
double b2 = GetNumber("Введите b2 = ");

FoundXY(k1, b1, k2, b2);

