using TGL_Practice_2.Persons;
using TGL_Practice_2.Workers;

namespace TGL_Practice_2.WorkersCollection
{
    internal interface IHR : IEnumerable<IWorker>
    {
        void Add(IPerson newWorker, int salary);
        void Add(IWorker newWorker);
        void Dismiss(IWorker worker);
        void Promote(IWorker worker);
        bool IsEmpty();
    }
}