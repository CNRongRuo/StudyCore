namespace DONET_框架中的委托与事件
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Heater heater = new Heater();
            Alarm alarm = new Alarm();
            heater.BoilEvent += alarm.MakeAlert;
            heater.BoilEvent += Display.ShowMsg;

            heater.BoilWater();
        }
    }

    public class Heater
    {
        private int temperature;
        public string type = "RealFire 001"; // 添加型号作为演示
        public string area = "China Xian"; // 添加产地作为演示

        public delegate void BoilEventHandler(Object sender, BoilEventArgs e);

        public event BoilEventHandler BoilEvent;


        public class BoilEventArgs : EventArgs
        {
            public readonly int temperature;
            public BoilEventArgs(int tem)
            {
                this.temperature = tem;
            }
        }
        protected virtual void OnBoil(BoilEventArgs e)
        {
            if (BoilEvent != null)
            {
                BoilEvent(this, e);
            }
        }
        public void BoilWater()
        {
            for (int i = 0; i < 100; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                   OnBoil(new BoilEventArgs(temperature));
                }
            }
        }

    }

    public class Alarm
    {

        public void MakeAlert(object sender ,Heater.BoilEventArgs e)
        {
            Heater heater = (Heater)sender;

            // 访问 sender 中的公共字段
            Console.WriteLine("Alarm：{0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Alarm: 嘀嘀嘀，水已经 {0} 度了：", e.temperature);
            Console.WriteLine();
        }

    }

    public class Display
    {
        public static void ShowMsg(object sender,Heater.BoilEventArgs e) // 静态方法
        {
            Heater heater = (Heater)sender;
            Console.WriteLine("Display：{0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Display：水快烧开了，当前温度：{0}度。", e.temperature);
            Console.WriteLine();
        }
    }

}