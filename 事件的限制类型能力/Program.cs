namespace 事件的限制类型能力
{

    public delegate void NumberChangedEventHandler(int count);

    /// <summary>
    /// 发布者
    /// </summary>
    public class Publisher
    {
        private int _count;
        //申明委托变量
        //public NumberChangedEventHandler _numberChanged;


        //申明事件（事件本质是一个封装的委托变量）
        public event NumberChangedEventHandler _numberChanged;
        public void DoSomething()
        {
            if (_numberChanged != null)
            {
                _count++;
                _numberChanged(_count);
            }
        }
    }


    /// <summary>
    /// 订阅者
    /// </summary>
    public class Subcriber
    {

        /// <summary>
        /// 这里还有一个约定俗称的规定，就是订阅事件的方法的命名，通常为“On 事件名”，比如这里的OnNumberChanged。
        /// </summary>
        /// <param name="count"></param>
        public void OnNumberChanged(int count)
        {
            Console.WriteLine("Subscriber notified: count = {0}", count);
        }
    }


    /// <summary>
    /// 事件应该由事件发布者触发，而不应该由事件的客户端（客户程序）来触发
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            Subcriber sub = new Subcriber();
            pub._numberChanged += new NumberChangedEventHandler(sub.OnNumberChanged);
            pub.DoSomething();// 应该通过DoSomething()来触发事件
            //pub._numberChanged(100);// 但可以被这样直接调用，对委托变量的不恰当使用
        }
    }
}