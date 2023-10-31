using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz3
{
    internal class first
    {
        public interface IGrow
        {public void Grow();}
        public interface IEat
        { public void Eat(); }
        public interface IBreath
        { public void Breath(); }
        public interface IMultiply
        { public void Multiply(); }
        
        public interface IVoice
        { public void Voice(); }

        public class Tree : LivingOrganisms
        {
            double height;
            string name;
            int energy, quantity;

            public override void Grow()
            {
                energy--;
            }
            public override void Eat()
            {
                energy++;
            }

            public override void Multiply()
            {
                quantity += 2;
            }
        }
        public class Dog : LivingOrganisms
        {
            int quantity;
            public override void Eat()
            {
                protein++;
                energy++;
            }
            public override void Grow()
            {
                protein--;
                energy--;
            }

            public override void Multiply()
            {
                quantity += 3;
            }
        }
        public class Hedgehog : LivingOrganisms
        {
            double weight;
            int quantity;
            public override void Eat()
            {
                protein++;
                energy++;
            }
            public override void Grow()
            {
                protein--;
                energy--;
            }

            public override void Multiply()
            {
                quantity += 2;
            }
        }


        public class Grass : LivingOrganisms
        {
            string kind;
            int energy, quantity;
            public override void Grow()
            {
                energy--;
            }
            public override void Eat()
            {
                energy++;
            }

            public override void Multiply()
            {
                quantity += 15;
            }

        }
        
        public abstract class LivingOrganisms : IEat, IGrow, IBreath, IMultiply
        {
            public int protein, energy;
            public string name;
            public abstract void Eat();

            public abstract void Grow();
            public void Breath()
            {
                Console.WriteLine("Тяжело вздохнул");
            }

            public abstract void Multiply();
        }
    }
}
