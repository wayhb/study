//главное меню
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

Bank bank = new BankTea();
User user = new();
//создать несколько пользователей, которые входят в банк
Console.WriteLine($"Добрый день! Вас приветствует банк \"{bank.Name}\". \n" +
    "Чтобы открыть счет по выгодной ставке нажмите клавишу 1. ");


//do
//{
//    Console.WriteLine($"Добрый день! Вас приветствует банк {bank.Name}. \n" +
//        "Чтобы открыть счет по выгодной ставке нажмите клавишу 1. Чтобы узнать информацию о вашем счете нажмите 2");
//    try
//    {
//        choice = int.Parse(Console.ReadLine());
//    }
//    catch (FormatException)
//    {
//        Console.WriteLine("Ошибка: Введено не число!");
//        //Console.Clear();
//        continue;
//    }
//    if(choice<0 && choice>2)
//    {
//        Console.WriteLine("Вы ввели неправильное число");
//        continue;
//    }
    //switch (choice)
    //{
    //    case 0:
    //        break;
    //    case 1:
    //        user.OpenDeposit(); // открытие счета
    //    case 2:
    //        user.OutputInfoOfUsers(); //информация о пользователе
    //}
//}
//while (choice != 0);
//********************************************************************база данных с пользователями
//opendeposit --> отображение видов депозитов --> устраивает ли пользователя это -->
//да-> переход на создание infoofuser, нет -> choice меняется на 0 --> choice меняется на 0
public abstract class Bank : IDeposit
{
    public abstract string Name { get; }

    public abstract double Rate { get; }

    //public event Action OnOutputRate;
    //public event Action OnTypesOfDeposits;
    public event Action Ratee;
    //создать делегат который соответствует сигнатуре метода пользователя 
    //void Choice(double rate, Action <User, double> callback)
    //с action 
    public abstract double Calculator(double currentsum, int month);
    public abstract double CloseDeposit(double sum);
    public abstract void OpenDeposit(double sum);
    protected Dictionary<User, Info> _archive = new();

    //public void LowWeight()
    //    {
    //        weight--;
    //        OnChrust?.Invoke(); // ====> OnChrust();
    //        var user = OnWeig?.Invoke(weight);
    //        user.Nyam();

    //    }
    public double Service(User user)
    {
        Random r = new Random();
        int rate = r.Next(7, 15);
    }
    //создать метод, который будет обслуживать клиента 
    //подсказка: соответствует сигнатуре делегата в методе void Choice(double rate, Action <User, double> callback)
    //алгоритм создания депозита:
    //1. создаем новую информацию info и заполняем current = 0
    //2. добавить инфу в словарик

    protected struct Info
    {
        public double rate;
        public double currentSum;
        public double startSum;
        public int months;
    }
    //struct TypesOfDeposits
    //{
    //    List<string> nameOfDeposit = new List<string>() { "Contribution Best %", "Simple deposit", "Savings account" };
    //    List<double> rate = new List<double>() { 14, 12.75, 7 };
    //    List<double> sum = new List<double>() { 100000, 100000, 0 };// сумма вклада
    //    List<double> time = new List<double>() { 1, 1, 0 };//срок на который надо положить как минимум\
    //    List<string> conditions = new List<string>() { "Без пополнения и без снятия", "Есть пополнение, но без снятия", "Есть и пополнение и снятие" };
       
    //}

}
public class BankTea : Bank
{
    public override string Name => "Чай";

    public override double Rate { get => 10; }

    public override double Calculator(double currentsum, int month)
    {
        throw new NotImplementedException();
    }

    public override double CloseDeposit(double sum)
    {
        throw new NotImplementedException();
    }

    public override void OpenDeposit(double sum)
    {
        throw new NotImplementedException();
        User, double
    }
}
public class User
{
    // через делегат передать rate 
    
    public User() 
    {
        //bank.OnTypesOfDeposits += OutPutOfDeposits;
    }
    //Имя, деньги и методы вхождение в банк, 
    //уход из банка и принятие решения о создание счета в банке или нет.
    
    // Свойство класса
    public string Name{get; set;}
    public double Money { get; set; }
    public double TargetRate { get; set; }

    public void EnterBank(Bank bank)
    {

    }
    public void ExitBank(Bank bank)
    {

    }
    private void Choice(double rate, Action <User, double> callback)
    {
        // сделать проверку на targetrate с входящей ставкой, если да - случайно кол-во денег(не 0),
        // и вызываем колбэк( return callback)
    //целевая ставка и ставка пользователя
    }
    //Если ставка банка устраивает пользователя, то он открывает депозит и кладет
    //в него случайную сумму денег.
    // метод который приветствует пользователя и предлагает открыть счет в банке под проценты,
    //ответ пользователя - переход в конец с сообщением желаем снова встречи с вами либо вывод
    //сообщение что вы открыли счет на такую то сумму денег
}
//нач сумму и сумма накоплений и пользователя
public interface IDeposit
{
    double Rate { get; }
    void OpenDeposit(double sum);
    double CloseDeposit(double sum);
    double Calculator(double currentsum, int month);
}
