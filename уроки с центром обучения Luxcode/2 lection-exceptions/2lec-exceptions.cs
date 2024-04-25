//исключения
try
{
    int devizor = 0;
    int result = 10 / devizor;
}
catch (DivideByZeroException ex)
{
    System.Console.WriteLine($"ERROR: {ex.Message}");
}
finally
{
    System.Console.WriteLine("This code is run");
}



int age = int.MaxValue;
checked{
    age++;
} //контроль переполнения
if (age < 0)
{
    throw new InvalidAgeException("Age can't be negative");
}
public class InvalidAgeException : Exception
{
    public InvalidAgeException(string message) : base(message) { }

}
