
using System.Collections;
Test test = new();
test.Execute();
public class Piano
{
    public int NumberOfKeys { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

}
public class Test
{
    List<Piano> collection = new List<Piano>();
    public Test() 
    {
        Piano pin = new()
        {
            NumberOfKeys = 80,
            Name = "Master",
            Price = 100.7
        };
        Piano opa = new()
        {
            NumberOfKeys = 82,
            Name = "Margarita",
            Price = 200
        };
        Piano opa2 = new()
        {
            NumberOfKeys = 80,
            Name = "Mandarino",
            Price = 1000
        };
        collection.AddRange(new Piano[]{ pin, opa, opa2});
        
    }
    public void Show(IEnumerable collection)
    {
        foreach(var p in collection)
        {
            Console.WriteLine(p);
        }
    }
    public void Execute()
    {
        //var result = collection.Select(piano => piano.Name);
        //var result2 = collection.Select(piano => piano.NumberOfKeys);
        //var resul3 = from piano in collection select piano.Name;
        //Show(result2);


        var result = collection.Where(piano => piano.Price > 200).Select(piano => piano.Name);
        var filtr = collection.Where(piano => piano.Name.Length >5).Select(piano => piano.Name);
        var filtr2 = collection.Where(piano => piano.NumberOfKeys == 80 && piano.Price<200).Select(piano => piano.Name);
        Show(filtr2);
        var v1 = new Value<List<Piano>>(collection);
        var v2 = new Value<int>(5);
    }
}
public class Value<T>
    //where T: System.System32
{
    public T value { get; }
    public Value(T tak)
    {
        value = tak;
    }

}