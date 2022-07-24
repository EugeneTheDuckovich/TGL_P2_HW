namespace TGL_Practice_2.Workers;

internal class Middle : Worker
{
    public Middle(string name, DateOnly birthDate, int salary, 
        Action<Worker> promotionAction, Action<Worker> dismissAction) : 
        base(name, birthDate, salary, promotionAction, dismissAction)
    {}

    public override int GetUsability()
    {
        return 5 + SkillsAmount * 4;
    }
    public override void Suffer()
    {
        SufferingAmount += random.Next(1, 8);
        base.Suffer();
    }
    public override IWorker Copy() =>
        new Middle(Name, BirthDate, Salary, _promotionAction, _dismissingAction);
}
