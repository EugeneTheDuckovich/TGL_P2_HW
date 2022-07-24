using TGL_Practice_2.Company;
using TGL_Practice_2.Persons;
using TGL_Practice_2.Projects;
using TGL_Practice_2.Workers;

namespace TGL_Practice_2;
internal class Program
{
    static async Task Main(string[] args)
    {
        GalleyInc galley = new();
        Worker[] workers = new Worker[]  { 
            new Junior("James", new DateOnly(2001, 8, 8), 500, galley.Workers.Promote, galley.Workers.Dismiss),
            new Junior("Radion", new DateOnly(1998, 12, 1), 600, galley.Workers.Promote, galley.Workers.Dismiss),
            new Junior("Dmitro", new DateOnly(1995, 1, 5), 700, galley.Workers.Promote, galley.Workers.Dismiss),
            new Junior("Fidel", new DateOnly(2003, 2, 13), 800, galley.Workers.Promote, galley.Workers.Dismiss),
            new Junior("Kim", new DateOnly(2002, 10, 18), 900, galley.Workers.Promote, galley.Workers.Dismiss),
            new Middle("Ed", new DateOnly(1990, 5, 15), 1800, galley.Workers.Promote, galley.Workers.Dismiss),
            new Middle("Kyle", new DateOnly(1985, 12, 12), 2000, galley.Workers.Promote, galley.Workers.Dismiss),
            new Senior("Helen", new DateOnly(1978, 10, 11), 4000, galley.Workers.Promote, galley.Workers.Dismiss),
        };
        
        foreach(var worker in workers) galley.Workers.Add(worker);

        galley.AddProject(new Project("First Project", 200));

        galley.AddRandomWorkersAsync();
        galley.AddRandomProjectsAsync();
        await galley.WorkAsync();
    }
}