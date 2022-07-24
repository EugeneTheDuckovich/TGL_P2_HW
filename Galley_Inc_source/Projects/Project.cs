namespace TGL_Practice_2.Projects;

internal class Project : IProject
{
    public string Name { get; }
    public int AmountOfWorkLeft { get; private set; }
    private int FullWorkAmount { get; }

    public Project(string name, int fullWorkAmount)
    {
        Name = name;
        FullWorkAmount = fullWorkAmount;
        AmountOfWorkLeft = fullWorkAmount;
    }

    public string GetPercentage()
    {
        int percentage = (int)((FullWorkAmount - AmountOfWorkLeft) / (FullWorkAmount / 100.0));
        return $"{percentage} % of project {Name} is done";
    }

    public void MakeWork(int work)
    {
        if (work >= AmountOfWorkLeft) AmountOfWorkLeft = 0;
        else AmountOfWorkLeft -= work;
    }
}