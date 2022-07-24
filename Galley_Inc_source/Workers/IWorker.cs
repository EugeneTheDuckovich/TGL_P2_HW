using TGL_Practice_2.Persons;

namespace TGL_Practice_2.Workers
{
    internal interface IWorker : IPerson
    {
        uint ID { get; }
        int Salary { get; }
        int SkillsAmount { get; }
        int SufferingAmount { get; }

        int GetUsability();
        void OnProjectFinished();
        void Suffer();
        IWorker Copy();
    }
}