namespace Reflection1
{
    public class Program
    {
        static void Main()
        {
            var name = Console.ReadLine();
            var age = Console.ReadLine();
            var person = new Person {Name = name, Age = age};
            person.Validate();
        }
    }
}

