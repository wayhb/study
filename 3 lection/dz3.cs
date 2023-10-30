using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz3
{
    internal class first
    {
        //1 - Ответить на вопросы:
        //Есть множественное наследование в C#?
        //Множественное наследование в данном языке есть (пример: наследование интерфейсов)

        //Может ли структура наследоваться от другой структуры?
        //нет, только интерфейс от интерфейса



        //Абстрактный класс — это класс, у которого не реализован один или больше методов (некоторые языки
        //требуют такие методы помечать специальными ключевыми словами).
        //Интерфейс — это абстрактный класс, у которого ни один метод не реализован, все они публичные и
        //нет переменных класса.

        //2 - Практика Интерфейсы.
        //Создать класс Дерево, Собака, Еж, Трава и Камень.
        //Создать интерфейс с методом “Расти”, реализовать этот интерфейс в классах, который могут выполнять
        //этот метод.
        //Создать интерфейс с методом “Питаться”, реализовать этот интерфейс в классах, который могут
        //выполнять этот метод.
        //Создать интерфейс с методом “Голос”, реализовать этот интерфейс в классах, который могут выполнять
        //этот метод.


        //интерфейс - это аспект языка, который служит для того, чтобы формировать интерфейс взаимодействия класса

        public interface IGrow
        {
            public void Grow();
        }
        public interface IEat
        { public void Eat(); }

        public interface IVoice
        { public void Voice(); }

        public class Tree : IGrow, IEat
        {
            double height;
            string name;
            int energy;

            public void Grow()
            {
                energy--;
            }
            public void Eat()
            {
                energy++;
            }
        }
        public class Dog : Animal
        {

            public override void Voice()
            {
                Eat();
            }
        }
        public class Hedgehog : Animal
        {
            double weight;

            public override void Voice()//virtual
            {
                Console.WriteLine("Ежа никто не услышал!");
            }

            public override void Do()
            {
                //base.Do();
                name = "Kill";
            }
        }

        public abstract class Animal : IVoice, IEat, IGrow
        {
            public int protein, energy;
            public string name;
            public void Eat()
            {
                protein++;
                energy++;
            }

            public void Grow()
            {
                protein--;
                energy--;
            }

            public abstract void Voice();

            public virtual void Do()
            {
                name = "pop";
            }
        }

        public class Grass : IGrow
        {
            string kind;
            int energy;
            public void Grow()
            {
                energy--;
            }
            public void Eat()
            {
                energy++;
            }

        }
        public class Stone
        {
            string color;

        }





        //3 - Практика Наследования + Абстракции
        //Создать единый класс для всех классов из пункта 2 (Дерево, Собака, Еж, Трава и Камень) - НЕ ПОНЯЛА
        //Создать общий класс для Собаки и Ежа.
        //Создать общий класс для Дерева и Травы.
        //Правильно выполнить наследование всех этих классов с учетов логики и здравого смысла.

        public class Grass_Tree : Tree
        {
            string kind;
        }
        public class Dog_Hedgehog : Hedgehog
        {
            int voice;
            string nickname;
            int energy, protein;
            public void Eat()
            {
                energy++;
                protein++;
            }
            public void Voice() { Console.WriteLine("voice"); }
        }


        //4 - Практика Полиморфизм
        //При работе метода “Расти” у Дерева и Травы, тратиться энергия
        //При работе метода “Питаться” у Дерева и Травы, пополняется энергия  
        //При работе метода “Расти” у Собаки и Ежа, тратиться энергия и белок
        //При работе метода “Питаться” у Собаки и Ежа, пополняется энергия и белок
        //При работе метода “Голос” у Собаки, вызывается метод “Питаться”  
        //При работе метода “Голос” у Ежа, выводиться сообщение в консоль “Ежа никто не услышал!”


    }
}
