//“Чаепитие с дедом Вовой”

//Цель: Еще раз написать программу которая использует абстракцию, интерфейсы, делегаты, наследования и полиморфизм.

//Компоненты программы: Стол, 4 пользователя, 3 вида чая и 3 вида кофе.

//Задача: Сделать симулятор чаепития, все пользователи подходят к столу и случайно получают напиток от стола, который выпивают. Когда выполняется метод “Выпить напиток”, в консоль выводиться следующее сообщение : 
//“[*имя пользователя*]: Пьет* название напитка* !”

Table table = new();

User user1 = new();
User user2 = new();
User user3 = new();
User user4 = new();

user1.ApproachTheTable(table);
user2.ApproachTheTable(table);
user3.ApproachTheTable(table);
user4.ApproachTheTable(table);

table.Service();

user1.StepAwayFromTheTable(table);
user2.StepAwayFromTheTable(table);
user3.StepAwayFromTheTable(table);
user4.StepAwayFromTheTable(table);

public class User
{
    public string Name { get; set; }
    public void ApproachTheTable(Table table)
    {
        table.Choiced += Choice;
    }
    public void StepAwayFromTheTable(Table table)
    {
        table.Choiced -= Choice;
    }
    private void Choice(Action<User, drinks> callback)
    {
        Random rand = new Random();
        List<drinks> Drinks = new List<drinks>() { Ulun, Puer, DaHongPao, Espresso, Latte, Cappuccino };
        int choice = rand.Next(0,5);
        callback?.Invoke(this, Drinks[choice]);
    }
}

public class Table : IDrink
{
    protected Dictionary<User, drinks> _archive = new();
    public event Action<Action<User, drinks>> Choiced;
    public virtual void Drinkaet(User user, drinks drink)
    {
        _archive.Add(user, drink);
        Console.WriteLine($"{user.Name}: пьет {drink.Name}!");
    }
    public void Service()
    {
        Choiced?.Invoke(Drinkaet);
    }
}
public abstract class drinks
{
    public abstract string Name { get; }
}
public abstract class Coffee: drinks
{
    public abstract int Level { get; }
}
public abstract class Tea : drinks
{
    public abstract string Сolor { get; }
}
class Ulun :Tea
{
    public override string Name => "Ulun";
    public override string Сolor => "green";
}
class Puer : Tea
{
    public override string Name => "Puer";
    public override string Сolor => "green";
}
class DaHongPao : Tea
{
    public override string Name => "DaHongPao";
    public override string Сolor => "red";
}
class Espresso : Coffee
{
    public override string Name => "Espresso";

    public override int Level => 1;
}
class Cappuccino : Coffee
{
    public override string Name => "Сappuccino";

    public override int Level => 85;
}
class Latte : Coffee
{
    public override string Name => "Latte";

    public override int Level => 85;
}
public interface IDrink
{
    void Drinkaet(User user, drinks drink);
}