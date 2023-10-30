using System;
// класс это ссылочный тип , а структура - значимый тип
//скорость выполнения кода класса значительно меньше, нежели в структуре(так как не вызывается сборщик
//мусора в структуре)
namespace TestC
{
    public interface IOtherSuper : ISuper
    {
        public void Test();
    }
    public interface ISuper //c public и буквы I
    {
        const int Ar = 9;
        int Value { get; }
        event Action OnRun;
        void Run();
    }

    public struct MyStruct : IOtherSuper
    {
        public int Value => throw new NotImplementedException();

        public event Action OnRun;

        public void Run()
        {
            throw new NotImplementedException();
        }

        void IOtherSuper.Test()
        {
            throw new NotImplementedException();
        }
    }

    public class TestA : ISuper //alt+enter( в интерфейс)
    {
        #region
        //явное преобразование
        //int ISuper.Value => throw new NotImplementedException();

        //event Action ISuper.OnRun
        //{
        //    add
        //    {
        //        throw new NotImplementedException();
        //    }

        //    remove
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        void ISuper.Run()
        {
            throw new NotImplementedException();
        }
        #endregion

        //неявное преобразование
        public int Value => throw new NotImplementedException();

        public event Action OnRun;

        //public void Run()
        //{
        //    throw new NotImplementedException();
        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            //OnRun - event
            var test = new TestA();
            test.Run();
            test.OnRun += Execute;//1
            test.OnRun += Voice;//2
            //222222
            test.OnRun -= Execute;
            test.OnRun += Execute;

            //()

            /*
            test.OnRun = null;

            test.OnRun?.Invoke();

            if (test.OnRun != null)
                test.OnRun.Invoke();

            //*/
            Voice();
        }

        public static void Execute()// Action
        {

        }
        public static void Voice()
        {

        }
    }
}

