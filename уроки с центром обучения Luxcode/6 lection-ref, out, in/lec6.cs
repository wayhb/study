// работа с ref, out, in
public class Test
{
    public int number;
}

public struct Info
{
    public int number;
}

class Program
{
    static void Main(string[] args)
    {
        var test = new Test();
        var info = new Info(); 

        test.number = 55;
        info.number = 45;

        var unitTest = new UnitTest();
        unitTest.Execute(test);// 56 +
        unitTest.Execute(info);// 46 -

        unitTest.Run(ref info);// 46 +// boxing info ====> object ----> in Heap

        var unitTestII = new UnitTestII();
        unitTestII.Execute(out test);//100
        unitTestII.Execute(out info);//150
    }
}
// in, ref, out
public class UnitTest
{
    public void Execute(Test test)
    {
        test.number++;
    }
    public void Execute(Info info)
    {
        info.number++;
    }
    public void Run(ref Test test)
    {
        test.number++;
    }

    public void Run(ref Info info)//!!! unboxing ==> object ----> info
        //сам info он находится в КУЧЕ Heap!!!!!
    {
        //(Info) object info
        info.number++;
    }
}

public class UnitTestII
{
    public void Execute(out Test test)
    {
        test = new Test();
        test.number = 100;
    }

    public void Execute(out Info info)
    {
        info = new Info();
        info.number = 150;
    }

    public void Run(in Test test)
    {
        //test = new Test(); ERROR!!!
        test.number++;
        test.ToString();    // 1 object
        test.GetHashCode(); // 2 object
        test.GetType();     // 3 object typeof(T)
        test.Equals(test);  // 4 object Hash!!!!
    }

    public void Run(in Info info)
    {
        int x = 10;
        x++;//11 ====> I - (x + 1 => int _ = 11) II - (_ 11 = x)

        //info = new Info(); ERROR!!!
        //info.number++;
        //1 - Info _ = info;
        //2 - _.number++;
        //3 info = _; <----ERROR!!!
    }
}