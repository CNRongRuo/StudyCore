// See https://aka.ms/new-console-template for more information

internal class Program
{
    public abstract record Person(string FirstName, string LastName);

    public record Teacher(string FirstName, string LastName, int Grade):Person (FirstName,LastName);
    public record Student(string FirstName, string LastName, int Grade):Person (FirstName,LastName);
    public static void Main(string[] args)
    {
        Person teacher = new Teacher("Nancy", "Davolio", 3);
        Person student = new Student("Nancy", "Davolio", 3);
        Console.WriteLine(teacher == student); // output: False

        Student student2 = new Student("Nancy", "Davolio", 3);
        Console.WriteLine(student2 == student); // output: True
        Person_InitExample initExample = new Person_InitExample() { YearOfBirth = 1994 };
        //initExample.YearOfBirth = 1999;//Not allowed, as its value can only be set once in the constructor
    }
}
public record Person
{
    public string FirstName { get; init; } = default;
    public string LastName { get; init; } = default;
};
class Person_InitExample
{
    private int _yearOfBirth;

    public int YearOfBirth
    {
        get { return _yearOfBirth; }
        init { _yearOfBirth = value; }
    }


}