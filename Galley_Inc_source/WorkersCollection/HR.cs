using System.Collections;
using TGL_Practice_2.Persons;
using TGL_Practice_2.Workers;

namespace TGL_Practice_2.WorkersCollection;

internal class GalleyHR : IHR
{
    private List<IWorker> _workers;
    private event Action<IWorker> WorkerAdded;
    private event Action<IWorker> WorkerRemoved;

    public GalleyHR(Action<IWorker> workerAddedAction, Action<IWorker> workerRemovedAction)
    {
        _workers = new List<IWorker>();
        WorkerAdded = workerAddedAction;
        WorkerRemoved = workerRemovedAction;
    }

    public void Add(IPerson newWorker, int salary)
    {
        var worker = new Junior(newWorker.Name, newWorker.BirthDate, salary, Promote, Dismiss);
        _workers.Add(worker);
        WorkerAdded.Invoke(worker);
        Console.WriteLine($"{newWorker.Name} joined the GaleraInc!");
    }

    public void Add(IWorker newWorker)
    {
        IWorker copy = newWorker.Copy();
        _workers.Add(copy);
        WorkerAdded.Invoke(copy);
        Console.WriteLine($"{copy.Name} joined the GaleraInc!");
    }

    public void Dismiss(IWorker worker)
    {
        WorkerRemoved.Invoke(worker);
        _workers.Remove(worker);
        Console.WriteLine($"{worker.Name} is no longer in the GaleraInc");
    }

    public void Promote(IWorker worker)
    {
        if (worker == null || worker.SkillsAmount < 5) return;

        int index = _workers.IndexOf(_workers.Where(x => x.ID == worker.ID).FirstOrDefault());
        WorkerRemoved.Invoke(_workers[index]);
        if (worker is Junior)
        {
            _workers[index] =
                new Middle(worker.Name, worker.BirthDate, worker.Salary, Promote, Dismiss);
            Console.WriteLine($"{worker.Name} was promoted to Middle!");
        }
        else if (worker is Middle)
        {
            _workers[index] =
                new Senior(worker.Name, worker.BirthDate, worker.Salary, Promote, Dismiss);
            Console.WriteLine($"{worker.Name} was promoted to Senior!");
        }
        WorkerAdded.Invoke(_workers[index]);
    }

    public IEnumerator<IWorker> GetEnumerator()
    {
        return _workers.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool IsEmpty()
    {
        return _workers.Count == 0;
    }
}
