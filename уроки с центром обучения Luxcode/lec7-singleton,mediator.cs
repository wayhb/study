// одиночка
//public class Singleton
//{
//    private static Singleton _instance;
//    private Singleton ( ) { }
//    public static Singleton Instance {
//        get {
//            if (_instance==null)
//                _instance = new Singleton();

//            return _instance;
//        } 
//    }
//}
// посредник
//public class Mediator
//{
//    public void Execute(Itest test)
//    {
//        Console.WriteLine( "gav");
//    }
//}
//public class B
//{
//    public void Test()
//    {
//    }
//}
//public class A : Itest
//{
//    public A(Mediator m) {
//        Mediator = m;
//    }
//    public Mediator Mediator { get; }

//    public void Test()
//    {
//        Mediator.Execute(this);
//    }
//}
//public interface Itest
//{
//    public Mediator Mediator { get; }
//    public void Test();
//}

interface IMediator
{
    void Notify(Employee emp, string msg);
}
abstract class Employee
{
    protected IMediator mediator;
    public Employee(IMediator mediator)
    {
        this.mediator = mediator;
    }
    public void SetMediator(IMediator med) =>  this.mediator = med;

}
class Designer : Employee
{
    private bool isWorking;
    public Designer();
}
