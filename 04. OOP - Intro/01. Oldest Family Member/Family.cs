
using System.Collections.Generic;

class Family
{
    private List<Person> members = new List<Person>();

    public void AddMember(Person member)
    {
        members.Add(member);
    }

    public void GetOldestMember()
    {
        int oldestMember = int.MinValue;
        Person oldestPerson = null;

        for (int i = 0; i < this.members.Count; i++)
        {
            if (this.members[i].Age > oldestMember)
            {
                oldestMember = this.members[i].Age;
                oldestPerson = this.members[i];
            }
        }
        System.Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
    }

   
}
