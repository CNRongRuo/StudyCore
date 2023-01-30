// See https://aka.ms/new-console-template for more information

internal class Program
{
    public static int e = 3;

    public const int f = 4; //常量：编译时候已知，且不能改变

    //public const int g = e;//常数表达式是在编译时可被完全计算的表达式。因此不能从一个变量中提取的值来初始化常量
    public const int h = f;

    //public static const int i= 1;//const都是静态的，不能使用static修饰。
    public readonly int j = 2;
    public readonly int k;
    public static readonly int l = 3; //readonly不能改变

    public Program()
    {
        e = 4;
        k = 2;
        //赋值号左边必须是变量，属性，索引器
        //f = 5;
        //无法对静态只读字段赋值（静态构造函数或者变量初始化中除外）
        //l = 4;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
    public void method()
    {
        // k = 3;
        //l = 4;
    }
}