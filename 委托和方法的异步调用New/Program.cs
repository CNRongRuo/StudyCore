namespace 委托和方法的异步调用New
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Client application started!\n");
            Thread.CurrentThread.Name = "Main Thread";
            Calculator cal = new Calculator();
            AddDelegate add=new AddDelegate(cal.Add);
            //从.NET Framework 4.5开始，基于任务的异步模式(TAP)是推荐的异步模型。因此，而且由于异步委托的实现取决于远程处理但.NET Core不存在的功能，BeginInvoke和EndInvoke委托调用不.NET Core支持
            //IAsyncResult result =add.BeginInvoke(2,5,null,null);
            var workTask = Task.Run(() => { return add.Invoke(2,5); });
            // 做某些其它的事情，模拟需要执行3 秒钟
            for (int i = 1; i <= 3; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(i));
                Console.WriteLine("{0}: Client executed {1} second(s).", Thread.CurrentThread.Name, i);
            }
            //int rtn = add.EndInvoke(result);
            int rtn =  workTask.Result;
            Console.WriteLine("Result: {0}\n", rtn);
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }
    }

    public delegate int AddDelegate(int x, int y);
    public class Calculator
    {
        public int Add(int x, int y)
        {
            if (Thread.CurrentThread.IsThreadPoolThread)
            {
                Thread.CurrentThread.Name = "Pool Thread";
            }

            Console.WriteLine("Method invoked!");

            // 执行某些事情，模拟需要执行2 秒钟
            for (int i = 1; i <= 2; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(i));
                Console.WriteLine("{0}: Add executed {1} second(s).", Thread.CurrentThread.Name, i);
            }

            Console.WriteLine("Method complete!");
            return x + y;
        }
    }
}