namespace 多播委托
{

    /// <summary>
    /// 调用委托时，它可以调用多个方法。这称为多路广播。若要向委托的方法列表（调用列表）中添加额外的方法，只需使用加法运算符或加法赋值运算符（“+”或“+=”）添加两个委托。
    ///注意：
    ///作为委托参数传递的方法必须与委托声明具有相同的签名。
    ///委托实例可以封装静态或实例方法。
    ///尽管委托可以使用 out 参数，但建议您不要将其用于多路广播事件委托，因为您无法知道哪个委托将被调用。
    ///多播委托传递值类型时，对参数的修改不会传到下一个
    ///多播委托传递引用类型时，对引用参数的修改会传到下一个
    /// </summary>
    internal class TestMultiCastDelegate
    {
        /// <summary>
        /// 多播委托传递值类型时，对参数的修改不会传到下一个
        ///多播委托传递引用类型时，对引用参数的修改会传到下一个
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Test();
        }

        public static void Test()
        {
            //多播委托

            Del d1 = MethodA;

            Del d2 = MethodB;

            Del d3 = MethodC;

            Del AllDelegateMethod = d1 + d2;

            AllDelegateMethod += d3;

            AllDelegateMethod("Jack");
            Console.Out.WriteLine("---------------------");

            AllDelegateMethod -= d3;

            AllDelegateMethod("wangds");

            //测试引用类型

            DelRef dref1 = MethodRefA;

            DelRef dref2 = MethodRefB;

            DelRef Alldref = dref1 + dref2;

            Person p = new Person { Address = "USA", Name = "America" };

            Alldref(p);
        }
        public delegate void Del(string message);

        delegate void DelRef(Person p);
        static void MethodA(string s)
        {
            Console.Out.WriteLine("Method A:" + s);
        }
        static void MethodB(string s)
        {
            Console.Out.WriteLine("Method B:" + s);
        }
        static void MethodC(string s)
        {
            Console.Out.WriteLine("Method C:" + s);
        }
        class Person

        {

            public string Name { get; set; }

            public string Address { get; set; }



        }



        static void MethodRefA(Person p)

        {

            //Console.Out.WriteLine(p.Name + "," + p.Address);

            Console.Out.WriteLine("----------MethodRefA---------");

            //p.Name = "Jack";

            //p.Address = "China";



            Console.Out.WriteLine(p.Name + "," + p.Address);

            Console.Out.WriteLine("----------MethodRefA---------");

        }



        static void MethodRefB(Person p)

        {

            Console.Out.WriteLine("--------MethodRefB----------");

            Console.Out.WriteLine(p.Name + "," + p.Address);

            Console.Out.WriteLine("--------MethodRefB----------");

        }
    }
}