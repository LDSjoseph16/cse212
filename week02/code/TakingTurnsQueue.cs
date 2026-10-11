public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new PersonQueue();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.Length == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        Person person = _people.Dequeue();

        // If turns <= 0, infinite turns (re-enqueue without changing)
        // If turns > 1, decrement and re-enqueue
        // If turns == 1, they are done (do not re-enqueue)
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)
        {
            person.Turns -= 1;
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}