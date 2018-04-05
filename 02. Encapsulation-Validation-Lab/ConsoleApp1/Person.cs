class Person
{
    private string firstname;
    private string lastname;
    private int age;

    public Person(string firstname, string lastname, int age)
    {
        this.firstName = firstname;
        this.lastName = lastname;
        this.Age = age;
    }

    public string firstName
    {
       get => this.firstname;

        set => this.firstname = value;
    }

    public string lastName
    {
        get => this.lastname;

        set => this.lastname = value;
    }


    public int Age
    {
       get => this.age;

        set => this.age = value;
    }

   

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} is a {this.Age} years old.";
    }
}
