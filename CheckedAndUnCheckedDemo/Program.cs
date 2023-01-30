// See https://aka.ms/new-console-template for more information

// checked 和 unchecked 语句指定整型算术运算和转换的溢出检查上下文
// Checked抛出异常（溢出检查）
// UnChecked返回一个值

uint a = uint.MaxValue;

unchecked
{
    Console.WriteLine(a + 1); // output: 0
}

try
{
    checked
    {
        Console.WriteLine(a + 1);
    }
}
catch (OverflowException e)
{
    Console.WriteLine(e.Message); // output: Arithmetic operation resulted in an overflow.
}


double da = double.MaxValue;

int b = unchecked((int)da);
Console.WriteLine(b); // output: -2147483648

try
{
    b = checked((int)da);
}
catch (OverflowException e)
{
    Console.WriteLine(e.Message); // output: Arithmetic operation resulted in an overflow.
}