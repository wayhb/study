// 1-2 program

//Напишите программу, которая запрашивает у пользователя ввод двух чисел и делит одно число на другое.
//Обработайте возможные исключения, такие как деление на ноль и ввод нечисловых значений.
//
//Модифицируйте программу из предыдущего задания так, чтобы она обрабатывала различные типы
//исключений отдельно и выводила соответствующие сообщения об ошибках.
//
//Добавьте в программу из задания 2 блок finally, который будет выполняться независимо от того,
//произошло исключение или нет. В этом блоке выведите сообщение о завершении программы.
//
//Создайте свой класс исключения InvalidInputException, который будет использоваться для обработки
//некорректного ввода пользователя. Модифицируйте программу из предыдущих заданий, чтобы использовать
//это исключение.
using System.Collections.Concurrent;
using System.Reflection.Metadata.Ecma335;

Console.WriteLine("Enter 2 numbers: ");

try
{
int num1 = Int32.Parse(Console.ReadLine());
int num2 = Int32.Parse(Console.ReadLine());
Console.WriteLine(num1 / num2);
}
catch (DivideByZeroException)
{
Console.WriteLine("исключение: на 0 делить нельзя!");
}
catch (FormatException)
{
Console.WriteLine("То что вы ввели не является числом!");
}
finally
{
Console.WriteLine("Program is completed");
}

//4

try
{
int num1 = Int32.Parse(Console.ReadLine());
int num2 = Int32.Parse(Console.ReadLine());
Console.WriteLine(num1 / num2);
}
catch (InvalidInputException e)
{
Console.WriteLine("ошибка: {0}", e.Message);
}
catch (FormatException e)
{
Console.WriteLine("ошибка: {0}", e.Message);
}
public class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message) { }
}
public class InvalidInputException2 : FormatException
{
    public InvalidInputException2(string message) : base(message) { }
}


int num1, num2;
num1 = Int32.Parse(Console.ReadLine());
num2 = Int32.Parse(Console.ReadLine());

Console.WriteLine($"result is {function(num1, num2)}");
int function(int first, int second)
{
    int overflow = 0;
    try
    {
        checked
        {
            overflow = first * second;
        }
    }
    catch (OverflowException e)
    {
        Console.WriteLine("overflow!");
    }
    return overflow;
}