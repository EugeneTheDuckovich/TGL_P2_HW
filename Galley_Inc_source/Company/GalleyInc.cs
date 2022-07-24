using TGL_Practice_2.Persons;
using TGL_Practice_2.Projects;
using TGL_Practice_2.Workers;
using TGL_Practice_2.WorkersCollection;

namespace TGL_Practice_2.Company;

internal class GalleyInc
{
    public readonly IHR Workers;
    private readonly Queue<IProject> _projects;
    public IProject? CurrentProject { get; private set; }

    private Mutex _galleyMutex;

    private event Action ProjectFinished;
    private void OnWorkerAdded(IWorker worker) => ProjectFinished += worker.OnProjectFinished;
    private void OnWorkerRemoved(IWorker worker) => ProjectFinished -= worker.OnProjectFinished;

    public GalleyInc()
    {
        Workers = new GalleyHR(OnWorkerAdded, OnWorkerRemoved);
        _projects = new ();
        _galleyMutex = new();
    }

    public void AddProject(IProject project) => _projects.Enqueue(project);

    private bool TryGetNewProject()
    {
        if(CurrentProject != null) return true;
        
        if (_projects.TryDequeue(out IProject project))
        {
            CurrentProject = project;
            Console.WriteLine($"GalleyInc started working on project {CurrentProject.Name}!");
            return true;
        }

        Console.WriteLine("There are no more projects to do!");
        return false;
    }

    private bool TryMakeSlavesWork()
    {
        if (!TryGetNewProject() || Workers.IsEmpty())
        {
            Console.WriteLine("GalleyInc is not able to work or there are no projects to do!");
            return false; 
        }

        foreach(var worker in Workers.ToList())
        {
            CurrentProject.MakeWork(worker.GetUsability());
            worker.Suffer();
        }

        if (CurrentProject.AmountOfWorkLeft == 0)
        {
            Console.WriteLine($"Project {CurrentProject.Name} was finished!");
            CurrentProject = null;
            ProjectFinished.Invoke();
        }
        else Console.WriteLine($"Working session ended. {CurrentProject.GetPercentage()}");
        return true;
    }

    public async Task WorkAsync()
    {
        await Task.Run(async () =>
        {
            while (true)
            {
                await Task.Delay(1000);
                _galleyMutex.WaitOne();
                var isWorkSucceded = TryMakeSlavesWork();
                _galleyMutex.ReleaseMutex();
                if (!isWorkSucceded) 
                    break;
            }
        });
    }

    public async Task AddRandomWorkersAsync()
    {
        await Task.Run(async () =>
        {
            while (true)
            {
                await Task.Delay(10000);
                Random rnd = new();
                var randomSalary = rnd.Next(5, 8) * 100;
                _galleyMutex.WaitOne();
                Workers.Add(RandomPersonGenerator.GetRandomPerson(),randomSalary);
                _galleyMutex.ReleaseMutex();
            }
        });
    }

    public async Task AddRandomProjectsAsync()
    {
        await Task.Run(async () =>
        {
            uint projectNumber = 0;
            while (true)
            {
                await Task.Delay(4000);
                Random rnd = new();
                _galleyMutex.WaitOne();
                _projects.Enqueue(new Project($"Project {projectNumber}",rnd.Next(200, 500)));
                _galleyMutex.ReleaseMutex();
                projectNumber++;
            }
        });
    }
}