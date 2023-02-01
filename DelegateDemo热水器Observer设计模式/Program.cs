using System;

namespace DelegateDemo热水器Observer设计模式
{



    //    Observer 设计模式中主要包括如下两类对象：

    //Subject：监视对象，它往往包含着其他对象所感兴趣的内容。在本范例中，热水器就是一个监视对象，它包含的其他对象所感兴趣的内容，就是 temprature 字段，当这个字段的值快到100 时，会不断把数据发给监视它的对象。

    //Observer：监视者，它监视Subject，当 Subject 中的某件事发生的时候，会告知Observer，而Observer 则会采取相应的行动。在本范例中，Observer 有警报器和显示器，它们采取的行动分别是发出警报和显示水温。

    //在本例中，事情发生的顺序应该是这样的：

    //1. 警报器和显示器告诉热水器，它对它的温度比较感兴趣(注册)。

    //2. 热水器知道后保留对警报器和显示器的引用。

    //3. 热水器进行烧水这一动作，当水温超过 95 度时，通过对警报器和显示器的引用，自动调用警报器的MakeAlert()方法、显示器的ShowMsg()方法。



    //类似这样的例子是很多的，GOF 对它进行了抽象，称为 Observer 设计模式：Observer 设计模式是为了定义对象间的一种一对多的依赖关系，以便于当一个对象的状态改变时，其他依赖于它的对象会被自动告知并更新。Observer 模式是一种松耦合的设计模式。
    ///Observer 模式是一种松耦合的设计模式


    /// <summary>
    /// 现在假设热水器由三部分组成：热水器、警报器、显示器，它们来自于不同厂商并进行了组装。那么，应该是热水器仅仅负责烧水，它不能发出警报也不能显示水温；在水烧开时由警报器发出警报、显示器显示提示和水温。
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Heater ht= new Heater();
            Alarm alarm=new Alarm();
            Display display=new Display();
            ht.BoilEvent += alarm.MakeAlert;
            ht.BoilEvent += display.ShowMsg;
            ht.BoilWater();
        }
    }


    /// <summary>
    /// 热水器
    /// </summary>
    public class Heater
    {
        private int _temperature;
        /// <summary>
        /// 尽管并非必需，但是我们发现很多的委托定义返回值都为 void，为什么呢？这是因为委托变量可以供多个订阅者注册，如果定义了返回值，那么多个订阅者的方法都会向发布者返回数值，结果就是后面一个返回的方法值将前面的返回值覆盖掉了，因此，实际上只能获得最后一个方法调用的返回值。可以运行下面的代码测试一下。除此以外，发布者和订阅者是松耦合的，发布者根本不关心谁订阅了它的事件、为什么要订阅，更别说订阅者的返回值了，所以返回订阅者的方法返回值大多数情况下根本没有必要。
        /// </summary>
        /// <param name="param"></param>
        public delegate void BoilHandler(int param);
        public event BoilHandler BoilEvent;
        public void BoilWater()
        {
            for (int i = 0; i < 100; i++)
            {
                _temperature = i;
                if (_temperature > 95)
                {
                    if (BoilEvent != null)
                    {
                        BoilEvent(_temperature);
                    }
                }
            }

        }
    }


    /// <summary>
    /// 警报器
    /// </summary>
    public class Alarm
    {
        public void MakeAlert(int param)
        {
            Console.WriteLine("Alarm：嘀嘀嘀，水已经 {0} 度了：", param);
        }
    }

    public class Display
    {
        public void ShowMsg(int param)
        {
            Console.WriteLine("Display：水已烧开，当前温度：{0}度。", param);
        }
    }

}

