// See https://aka.ms/new-console-template for more information

/// 5.	对于引用类型（string除外），==比较的是引用类型在栈中的地址，equals方法比较的是引用类型在托管堆中的存储信息的内容。
/// ==比较栈里面的内容，equals比较堆中的内容

int INTA = 1;
int INTB = INTA;
Console.WriteLine(INTA == INTB);         //True

Console.WriteLine(INTA.Equals(INTB));    //True

Console.WriteLine(object.Equals(INTA, INTB));    //True   比较对象是否相同

Console.WriteLine(object.ReferenceEquals(INTA, INTB));       //False  //这里值类型在返回到方法之前进行了装箱(NEW 对象)，so比较对象的引用肯定不同，

string strA = "Hello";
//string strC = string.Copy(strA);
string strB = strA;

Console.WriteLine(strA == strB);         //True

Console.WriteLine(strA.Equals(strB));    //True

Console.WriteLine(object.Equals(strA, strB));    //True

Console.WriteLine(object.ReferenceEquals(strA, strB));       //True



MyClass oA = new MyClass();

MyClass oB = new MyClass();

Console.WriteLine(oA == oB);   //False

Console.WriteLine(oA.Equals(oB));  //False

Console.WriteLine(object.Equals(oA, oB));  //False

Console.WriteLine(object.ReferenceEquals(oA, oB)); //False

class MyClass

{

    public int value = 1;

}