
int a = 1, h = 5;

Console.WriteLine($"a = {a}, h = {h}");

Swap(ref a, ref h);

Console.WriteLine($"a = {a}, h = {h}");

Foo<int>(); 
static void Swap<T>(ref T a, ref T b)
{ 
    T temp = a;
    a = b;
    b = temp;
}

static T Foo<T>()
{
    return default(T);
}
public class MyList<T>
{
    private T[] _array = Array.Empty<T>();

    public T this[int index]
    {
        get { return _array[index]; }
        set { _array[index] = value;}
    }

    public int Count { get { return _array.Length; } }

    public void Add(T value)
    {
        var newArray = new T[_array.Length + 1];
        for (int i = 0; i < _array.Length; i++)
        {
            newArray[i] = _array[i];
        }
        newArray[_array.Length] = value;
        _array = newArray;
    }
}
