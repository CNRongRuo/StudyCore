// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
Method();
Console.ReadLine();

static async void Method()
{
    await Task.Run(new Action(() =>
    {
        throw new Exception();
    }));

}