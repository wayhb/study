// передача метода в качестве аргумента
//77-80

int a = 0, b = 5;
Console.WriteLine("nechet");
display(f, a, b);
Console.WriteLine("chet");
display(g, a, b);
Console.WriteLine("number in quad");
display(h, a, b);

static int f(int n)
{
   return 1 + 2 * n;
}
static int g(int n)
{
    return 2 * n;
}static int h(int n)
{
    return n * n;
}
static void display(MyDelegate F, int a, int b)
{ 
    Console.WriteLine("{0,-4}|{1,4}", "x", " F(x)");
    Console.WriteLine("---------------");
    for(int k = a; k<=b;k++)
    {
        Console.WriteLine($"{k,-4}|{F(k),4}");
    }
    Console.WriteLine();
}

delegate int MyDelegate(int n);