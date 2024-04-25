/*Задание - “Банк и очередь клиентов”

Описание: “Есть банк, который выдает депозит по n-ставке клиентам. 
Клиент сам принимает решение открыть депозит, если его удовлетворяет ставка.  
В банк приходить сразу много клиентов, обслуживание происходит моментально”

Внимание: В данном задание приоритет отдается ДЕЛЕГАТАМ, любыми циклами запрещено 
пользоваться.

Шаги:
1 - Разработать класс Банка, который должен включать в себя коллекцию открытых депозитов
и ставку которую выдает. А также методы обслуживания всех клиентов, открытия депозита.
Подсказка: В данном классе есть делегаты и вложенный объект о хранение инфы клиента и его
депозите.

2 - Разработать класс Пользователь, который должен содержать Имя, деньги и методы вхождение
в банк, уход из банка и принятие решения о создание счета в банке или нет. 
Если ставка банка устраивает пользователя, то он открывает депозит и кладет в него случайную
сумму денег.

3 - Практика. Создать несколько клиентов с разными предпочтением по ставке и начальным
деньгам. Создать банк с некоторой ставкой по депозиту.
Все клиенты идут в банк, после банк вызывает метод обслуживание ВСЕХ клиентов, в результате
некоторые клиенты открывают депозиты, после клиенты покидают банк.
*/
Bank bank = new BankTea();
User user1 = new(6.8);

User user2 = new(7.9);
User user3 = new(2);
user1.EnterBank(bank);
user2.EnterBank(bank);
user3.EnterBank(bank);

bank.Obsluzhivanie();

user1.ExitBank(bank);
user2.ExitBank(bank);
user3.ExitBank(bank);


public abstract class Bank : IDeposit
{
    public abstract string Name { get; }

    public abstract double Rate { get; }




    public event Action<double, Action<User, double>> Bup;
    public abstract double CloseDeposit(User user, double sum);
    public virtual void OpenDeposit(User user, double sum)
    {
        var info = new Info();
        info.rate = Rate;
        info.currentSum = 0;
        info.startSum = sum;
        info.months = 0;
        _archive.Add(user, info);
    }
    protected Dictionary<User, Info> _archive = new();

    public void Obsluzhivanie()
    {
        Bup?.Invoke(Rate, OpenDeposit);
    }

    protected struct Info
    {
        public double rate;
        public double currentSum;
        public double startSum;
        public int months;
    }
}
public class BankTea : Bank
{
    public override string Name => "Чай";

    public override double Rate { get => 10; }

    public override double CloseDeposit(User user, double sum)
    {
        return sum;
    }

    public override void OpenDeposit(User user, double sum)
    {
        
    }
}
public class User 
{
    public User(double targetRate) 
    {
        TargetRate = targetRate;
    }
    
    public string Name{get; set;}
    public double Money { get; set; }
    public double TargetRate { get; set; }

    public void EnterBank(Bank bank)
    {
        bank.Bup += Choice;
    }
    public void ExitBank(Bank bank)
    {
        bank.Bup -= Choice;
    }
    private void Choice(double rate, Action <User, double> callback)
    {
        if(rate > TargetRate) // банка и пользователя ставка
        {
            Random rand = new Random();
            double denga = rand.NextDouble() * Money;
            Money -= denga;
            callback?.Invoke(this, denga);
        }
    }
}
public interface IDeposit
{
    double Rate { get; }
    void OpenDeposit(User user, double sum);
    double CloseDeposit(User user, double sum);
}
