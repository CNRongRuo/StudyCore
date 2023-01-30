// See https://aka.ms/new-console-template for more information

await CallAsync();
Task<int> t = Calculator.AddAsync(1, 2);

//一直在干活

Console.WriteLine($"result: {t.Result}");

Console.Read();
Console.WriteLine("Hello, World!");

static async Task<DateTime> GetDateTimeAsync()
{
    return await Task.FromResult(DateTime.Now);
}

async Task CallAsync1()
{
    DateTime now = await GetDateTimeAsync();
}

static async Task CallAsync()
{
    Thread.Sleep(4000);
    //在另一个异步方法的调用方式
    DateTime now = await GetDateTimeAsync();

    //换种方式调用
    Task<DateTime> t = GetDateTimeAsync();
    DateTime now2 = await t;
    //输出的结果对比
    Console.WriteLine($"now: {now}");
    Console.WriteLine($"now2: {now2}");
    Console.WriteLine($"t.Result: {t.Result}");
}

internal class Calculator
{
    private static int Add(int n, int m)
    {
        return n + m;
    }

    public static async Task<int> AddAsync(int n, int m)
    {
        int val = await Task.Run(() => Add(n, m));

        return val;
    }
}