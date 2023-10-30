// описание полиморфизма на примере разных машин и одного человека, т е логика объектов одного вида,
// но с разными реализациями
Person person = new();
    
person.Drive(new SportCar());
Car car = new SportCar();
class Car
{
    protected virtual void StartEngine() //protected - недоступен на уровне экземпляра класса, 
    {                                    //но доступен в наследниках, а private не там и не там
        Console.WriteLine("The engine is running!"); 
    }
    public virtual void Drive()
    {
        StartEngine();  
        Console.WriteLine("drive)");
    }
}
class SportCar: Car
{
    
    public override void Drive()
    {
        StartEngine();
        Console.WriteLine("i drive very fast!");
    }
}
 
class Person
{
    public void Drive(Car car)
    {
        car.Drive();    
    }
}

