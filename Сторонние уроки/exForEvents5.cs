// ссылки на методы и ссылки на объекты

MyClass A = new MyClass(100);
MyClass B = A;
MyDelegate apply = A.set;
A = new MyClass(200);
Console.WriteLine(A);
Console.WriteLine(B);
apply(300);
Console.WriteLine();
Console.WriteLine(A);
Console.WriteLine(B);
delegate void MyDelegate(int n);

class MyClass
{
    private int number;
    public MyClass(int n)
    {
        set(n);

    }
    public void set(int n)
    {
        number = n;
    }
    public override string ToString()
    {
        return "Поле number = "+number;
    }
}