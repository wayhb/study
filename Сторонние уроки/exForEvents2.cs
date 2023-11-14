
static void madeLine()
{
    Console.WriteLine("------");
}
MyClass A = new("Object A");
MyClass B = new("Object B");
MyClass C = new("Object C");
MyDelegate meth;
meth = A.Show;
meth();
meth = madeLine;
meth += A.Show;
meth += B.Show;
meth = meth + C.Show;
meth();
meth -= B.Show;
meth();
meth = meth - A.Show;
meth();


delegate void MyDelegate();
class MyClass
{
    public string Name { get; set; }

    public MyClass(string txt)
    {
        Name = txt;
    }
    public void Show()
    {
        Console.WriteLine(Name);
    }
}