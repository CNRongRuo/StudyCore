namespace EventDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ToolMan toolMan = new ToolMan("A");

            LazyMan lazyMan1 = new LazyMan("B");
            LazyMan lazyMan2 = new LazyMan("C");
            LazyMan lazyMan3 = new LazyMan("D");

            toolMan.DownStair();

            toolMan.DownStairDelegate += lazyMan1.TakeFood;
            toolMan.DownStairDelegate += lazyMan2.TakePackage;
            toolMan.DownStairDelegate += lazyMan3.TakeFood;

            toolMan.DownStair();

            toolMan.DownStairDelegate -= lazyMan1.TakeFood;
            toolMan.DownStairDelegate -= lazyMan2.TakePackage;

            toolMan.DownStair();
        }
    }

    //定义委托，可以让其他构造函数调用
    delegate void DownStairDelegate();

    /// <summary>
    /// 工具人类
    /// </summary>
    class ToolMan
    {
        public string Name { get; private set; }

        //声明委托,event可以让外部无法直接访问这个委托
        public event DownStairDelegate DownStairDelegate = null;

        public ToolMan(string name)
        {
            Name = name;
        }

        public void DownStair()
        {
            Console.WriteLine("工具人" + Name + "下楼了");

            //在调用委托之前先检测委托是否为空
            if (DownStairDelegate != null)
                DownStairDelegate();
        }
    }


    class LazyMan
    {
        public string Name { get; private set; }

        public LazyMan(string name)
        {
            Name = name;
        }

        public void TakeFood()
        {
            Console.WriteLine("给" + Name + "拿了外卖");
        }

        public void TakePackage()
        {
            Console.WriteLine("给" + Name + "拿了快递");
        }
    }
}