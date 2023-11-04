// изучение делегатов посредством написания программы, как пользователь кушает
class Program
{
    static void Main(string[] args)
    {
        User user = new();
        user.Eat();
    }
}
public class Apple : IDisposable
{
    double weight = 10;
    public event Action OnChrust;
    public event Func<double, User> OnWeig;

    //Этот метод метит объект класса для Мусорщика(GC) под удаление
    public void Dispose()
    {
        OnChrust = null;
        OnWeig = null;
        GC.SuppressFinalize(this);
    }

    public void LowWeight()
    {
        weight--;
        OnChrust?.Invoke(); // ====> OnChrust();
        var user = OnWeig?.Invoke(weight);
        user.Nyam();

    }

    //public void Reset()
    //{
    //    OnChrust = null;
    //    OnWeig = null;
    //}
}

public class User
{
    Apple apple = new();

    public User()
    {
        apple.OnWeig += CheckWeight;
        apple.OnChrust += () => Console.WriteLine(" хруст! ");//local token method - 100001
        apple.OnChrust += Do;//done
    }

    ~User()
    {
        apple.OnWeig -= CheckWeight;
        apple.OnChrust -= () => Console.WriteLine(" хруст! ");//local token method - 100002
        apple.OnChrust -= Do;//done
                             //apple.Dispose();
    }

    private void Do()
    {
        Console.WriteLine(" хруст! ");
    }
    public void Eat()
    {
        using (apple)
        {
            apple.LowWeight();
        }//автоматом вызывается apple.Dispose();
    }

    public void Nyam()
    {
        Console.WriteLine(" кусь ");
    }

    public User CheckWeight(double weight)
    {
        Console.WriteLine($" вес {weight}");
        return this;
    }
}
    