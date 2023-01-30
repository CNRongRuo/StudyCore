using static System.Net.Mime.MediaTypeNames;

namespace 委托中的协变和逆变
{
    /// <summary>
    /// 委托中的协变： 就是允许方法的返回类型是委托的返回类型的子类
    ///委托中的逆变，方法的参数是委托的参数的基类
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            XieBianDelegate.Test();

            Console.ReadKey();
        }
    }
    class Animal
    { }

    class Dog : Animal { }

    class XieBianDelegate
    {
        public delegate Animal HandlerMethod();
        public static Animal FirstHandler()
        {
            Console.WriteLine("Animal");
            return null;
        }
        public static Dog SecondHandler()
        {
            Console.WriteLine("Dog");
            return null;
        }
        public static void Test()
        {
            HandlerMethod handler1 = FirstHandler;
            // Covariance allows this delegate.
            HandlerMethod handler2 = SecondHandler;
        }
    }
    #region   委托中的逆变，方法的参数是委托的参数的基类

    class NiBianDelegate

    {
        public delegate Dog HandlerNibianMethod(Dog dogs);

        public Dog FirstHandlerNibian(Animal mammals)
        {
            return null;
        }
        void Test()
        {
            Dog dogs = new Dog();
            HandlerNibianMethod handNibian1 = FirstHandlerNibian;
        }
    }
    #endregion
}