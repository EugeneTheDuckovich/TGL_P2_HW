namespace TGL_Practice_2.Workers;

internal class Junior : Worker
{
    public Junior(string name, DateOnly birthDate, int salary, 
        Action<Worker> promotionAction, Action<Worker> dismissAction) 
        : base(name, birthDate, 1000, promotionAction, dismissAction)
    {}

    public override int GetUsability()
    {
        if (SkillsAmount == 0) return 1;
        return SkillsAmount;
    }

    public override void Suffer()
    {
        SufferingAmount += random.Next(1,5);
        base.Suffer();
    }

    public override IWorker Copy() => 
        new Junior(Name, BirthDate, Salary, _promotionAction,_dismissingAction);
}
