// знакомство с делегатами 59-67
static char getLast(int k, string txt)
{
    return txt[txt.Length - k - 1];
}
MyClass moy = new MyClass(5);

MyDelegate meth = new MyDelegate(moy.GetChar);
Console.WriteLine($"Symbol {meth(4, "alpha")}");
moy.code = 1;
Console.WriteLine($"Symbol {meth(4, "alpha")}");
meth = MyClass.GetFirst;
Console.WriteLine($"Symbol {meth(2, "alpha")}");
meth = getLast;
Console.WriteLine($"Symbol {meth(1, "alpha")}");


delegate char MyDelegate(int k, string txt);
public class MyClass
{
    public int code;
    public MyClass(int n) { code = n; }
    public char GetChar(int k, string txt)
    {
        return (char)(txt[k]+code);
    }
    public static char GetFirst(int k, string txt)
    {
        return txt[k];
    }
}






