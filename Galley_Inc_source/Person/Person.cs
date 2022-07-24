namespace TGL_Practice_2.Persons;

internal class Person : IPerson
{
    public string Name { get; }
    public DateOnly BirthDate { get; }

    public Person(string name, DateOnly birthDate)
    {
        Name = name;
        BirthDate = birthDate;
    }
}
