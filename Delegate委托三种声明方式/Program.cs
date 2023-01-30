namespace Delegate委托三种声明方式
{

    /// <summary>
    ///1.委托类似于 C++ 函数指针，但它们是类型安全的。
    ///2.委托允许将方法作为参数进行传递。
    ///3.委托可用于定义回调方法。
    ///4.委托可以链接在一起；例如，可以对一个事件调用多个方法。
    ///5.方法不必与委托签名完全匹配。（委托中的协变和逆变）
    ///6.C# 2.0 版引入了匿名方法的概念，此类方法允许将代码块作为参数传递，以代替单独定义的方法。C# 3.0 引入了 Lambda 表达式，利用它们可以更简练地编写内联代码块。匿名方法和 Lambda 表达式（在某些上下文中）都可编译为委托类型。这些功能统称为匿名函数
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            TestAllDelegate();
            TestReturn();
            Console.ReadKey();
        }

        delegate void TestDelegate(string s);

        delegate bool TestDelegateReturn(int i);
        public static void TestAllDelegate()
        {
            //.net1.0
            TestDelegate en = new TestDelegate(M);
            en("jack");
            TestDelegate china = China;
            china("wangdeshui");

            //.net2.0
            TestDelegate dele2 = delegate (string s) { Console.Out.WriteLine(s + ":这是一个2.0的方式"); };
            dele2("2.0 delegate declare");

            //.net3.0
            TestDelegate dele3 = (string s) => { Console.Out.WriteLine(s + ":这是3.0的方式"); };
            dele3("3.0 delegate declare");


        }

        private static void China(string s)
        {
            Console.Out.WriteLine(s + ":Good Morning");
        }

        private static void M(string s)
        {
            Console.Out.WriteLine(s + ":早上好");
        }

        private static void TestReturn()
        {
            TestDelegateReturn dele4 = new TestDelegateReturn(IsBig);
            bool i = dele4(11);
            Console.Out.WriteLine("dele4:" + i);

            TestDelegateReturn dele5 = delegate (int j)
            {
                return j > 10 ? true : false;
            };

            bool test5 = dele5(5);
            Console.Out.WriteLine("dele5:" + test5);

            TestDelegateReturn dele6 = (int k) => { return k > 10 ? true : false; };
            bool test6 = dele6(50);
            Console.Out.WriteLine("dele6:" + test6);
        }

        private static bool IsBig(int i)
        {
            return i > 10 ? true : false;
        }
    }
}