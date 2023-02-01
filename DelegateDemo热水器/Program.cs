namespace DelegateDemo热水器
{

    /// <summary>
    /// 假设我们有个高档的热水器，我们给它通上电，当水温超过95 度的时候：1、扬声器会开始发出语音，告诉你水的温度；2、液晶屏也会改变水温的显示，来提示水已经快烧开了。
    ///现在我们需要写个程序来模拟这个烧水的过程，我们将定义一个类来代表热水器，我们管它叫：Heater，它有代表水温的字段，叫做 temperature；当然，还有必不可少的给水加热方法 BoilWater()，一个发出语音警报的方法 MakeAlert()，一个显示水温的方法，ShowMsg()。
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
          Heater ht= new Heater();
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
        /// 烧水
        /// </summary>
        public void BoilWater()
        {
            for (int i = 0; i < 100; i++)
            {
                _temperature = i;
                if(_temperature>95)
                {
                    MakeAlert(_temperature);
                    ShowMsg(_temperature);
                }
            }
        }

        /// <summary>
        /// 发出语音警报
        /// </summary>
        private void MakeAlert(int  param)
        {
            Console.WriteLine("Alarm：嘀嘀嘀，水已经 {0} 度了：", param);
        }


        /// <summary>
        /// 显示水温
        /// </summary>
        /// <param name="param"></param>
        private void ShowMsg(int param)
        {
            Console.WriteLine("Display：水快开了，当前温度：{0}度。", param);
        }
    }


}