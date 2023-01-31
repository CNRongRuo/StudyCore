namespace DelegateDemo2._0
{

    /// <summary>
    /// 委托是一个类，定义方法类型
    /// </summary>
    /// <param name="name"></param>
    public delegate void GreetingDelegate(string name);
    public class Program
    {
        private static void EnglishGreeting(string name)
        {
            Console.WriteLine("Good Morning, " + name);
        }

        private static void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好, " + name);
        }
        public static void GreetPeople(string name, GreetingDelegate MakeGreeting)
        {
            MakeGreeting(name);
        }

        static void Main(string[] args)
        {

            //1
            //GreetPeople("Liker",EnglishGreeting);
            //GreetPeople("杰伦",ChineseGreeting);


            //2
            GreetingDelegate delegate1;
            delegate1 = EnglishGreeting;//=是赋值
            delegate1 += ChineseGreeting;//+=是绑定,对应的解绑为-=
            GreetPeople("Liker", delegate1);


            //3
            GreetingDelegate delegate2;
            delegate2 = EnglishGreeting;
            delegate2 += ChineseGreeting;
            delegate2("Liker");


            //4
            GreetingDelegate delegate3 = new GreetingDelegate(EnglishGreeting);
            delegate3 += ChineseGreeting;



            Console.ReadLine();
        }
    }
}