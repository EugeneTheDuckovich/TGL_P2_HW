namespace TGL_Practice_2.Workers;

internal class Senior : Worker
{
    public Senior(string name, DateOnly birthDate, int salary, Action<Worker> promotionAction, Action<Worker> dismissAction) : base(name, birthDate, salary, promotionAction, dismissAction)
    {}

    public override int GetUsability()
    {
        return 25 + SkillsAmount * 8;
    }
    public override void Suffer()
    {
        SufferingAmount += random.Next(1, 10);
        base.Suffer();
    }
    public override void OnProjectFinished()
    {
        if (SkillsAmount < 5) SkillsAmount++;
    }
    public override IWorker Copy() =>
        new Senior(Name, BirthDate, Salary, _promotionAction, _dismissingAction);
}
