using System.Diagnostics;
using System.Threading;

namespace demo
{
    /// <summary>
    /// 首先， Thread.sleep 只是放弃时间片的剩余时间，让系统重新选择调度一个合适的线程(其优先级等于或者高于当前线程)。在没有其他活动线程的情况下，使用 sleep(0) 还是选上原来线程即连任，如果连任了，系统不会对其做上下文切换，所以有:
    /// 其次，Thread.Yield() 是什么呢? 跟 Thread.sleep 有点像，但是它跟 Thread.sleep(0) 有点区别: 系统选择继任时可以选择优先级比原来低的线程
    /// 最后， Thread.sleep(1) 是什么情况呢? 前面说了， Thread.sleep 只是放弃时间片的剩余时间让系统重新选择调度一个合适的线程。但是 Thread.sleep(1) 却让当前线程沉睡了 (即使只有1ms)。也就是说，主动放弃下次竟选，所以不可能连任，系统上下文必然发生切换(优先级低于原线程的家伙也有机会)。
    /// 
    ///sleep是使当前线程休眠指定的时间，线程本身不会失去任何监控信息，比如sleep(0)的话，如果没有其他线程竞争，在恢复的时候还是会继续执行任务
    ///yield：A hint to the scheduler that the current thread is willing to yield its current use of a processor.The scheduler is free to ignore this hint.
    ///yield是明确指出了让出当前的处理器
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                //Thread.Sleep(0);
            }
            t.Join();//阻止主线程，ThreadMethod执行完毕
        }

        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadProc: {i}");
                Thread.Sleep(0);
            }

        }
    }
}