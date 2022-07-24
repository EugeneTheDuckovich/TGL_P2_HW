namespace TGL_Practice_2.Projects
{
    internal interface IProject
    {
        int AmountOfWorkLeft { get; }
        string Name { get; }

        string GetPercentage();
        void MakeWork(int work);
    }
}