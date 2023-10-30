Player player = new();

Weapon[] inventory = { new Gun(), new LazerGun(), new Bow() };
foreach(Weapon weapon in inventory)
{
    player.CheckInfo(weapon);
    player.Fire(weapon);
    Console.WriteLine();
}
class Player
{
    public void Fire(Weapon weapon)
    {
        weapon.Fire();
    }
    public void CheckInfo(Weapon weapon)
    {
        weapon.ShowInfo();
    }
}
class Gun : Weapon
{
    public override int Damage { get { return 5;} }

    public override void Fire()
    {
        Console.WriteLine("Пыщ!");
    }
}
class LazerGun : Weapon
{
    public override int Damage => 8;

    public override void Fire()
    {
        Console.WriteLine("Пиу!");
    }
}
class Bow : Weapon
{
    public override int Damage => 3;

    public override void Fire()
    {
        Console.WriteLine("Тррр!");
    }
}
abstract class Weapon
{
    public abstract int Damage { get;  } // изменять не можем
    public void ShowInfo()
    {
        Console.WriteLine($"{GetType().Name} Damage: {Damage}");
    }
    public abstract void Fire();
}