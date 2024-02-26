using System.Reflection;
Class cat = new Class();
cat.MethodPu();
Type type =  cat.GetType();
var attributes = type.GetCustomAttributes<CustomAttribute>(true);

foreach (var attribute in attributes)
{
    Console.WriteLine($"{attribute.num} - {attribute.GetHashCode()}");
}

var Method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
foreach (var method in Method)
{
    var Attrib = method.GetCustomAttribute<CustomAttribute>(true);
    if(Attrib!= null)
    {
        Console.WriteLine($"{method.Name} - {Attrib.num}");
    }
 
}
var turr = type.GetInterface(nameof(IhAV));
if(turr!=null)
{
    Console.WriteLine(turr);
}
if (type.IsSubclassOf(typeof(Bup)))
{
    Console.WriteLine("yes");
}
//do
//[AttributeUsage(AttributeTargets.Method)]

public class CustomAttribute: Attribute
{
    public int num = 8;
    public CustomAttribute(int varib) 
    { 
        num = varib; 
        Console.WriteLine("аттрибут создан"); 
    }
}
[Custom(4)]
public sealed class Class:Bup , IhAV
{
    public Class() 
    {
        Console.WriteLine("создан экземпляр класса");
    }
    public void MethodPu()
    {
        Console.WriteLine($"это публичный: {number}");
    }
    [Custom(9)]
    private void MethodPr(int nu)
    {
        Console.WriteLine($"я ПРИВАТНЫЙ: {nu}");
    }
    public int number;
    private int num;
}
public interface IhAV
{

} 
public class Bup
{

}