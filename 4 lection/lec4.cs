class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        TestLada test = new();
        test.list.ForEach(test.Show);
        //test.list.ForEach(x=> Console.WriteLine(x));
        Console.WriteLine( test.list.Find(v => v == 66));
    }

    
}

public class TestLada
{
    public List<int> list = new List<int>() { 12, 55, 66, 101  };
    public void Show(int elment)
    {
        Console.WriteLine(elment);
    }
}