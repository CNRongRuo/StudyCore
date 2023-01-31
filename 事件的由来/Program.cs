namespace 事件的由来
{

    public delegate void GreetingDelegate(string name);
    public class GreetingManager
    {
        public void GreetPeople(string name, GreetingDelegate MakeGreeting)
        {
            MakeGreeting(name);
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {

            //1
            GreetingManager gm=new GreetingManager();
            gm.GreetPeople("Liker",EnglishGreeting);
            gm.GreetPeople("杰伦", ChineseGreeting);


            //2


        }
        private static void EnglishGreeting(string name)
        {
            Console.WriteLine("Good Morning, " + name);
        }

        private static void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好, " + name);
        }
    }
}