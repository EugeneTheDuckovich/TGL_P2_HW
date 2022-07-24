using TGL_Practice_2.Persons;

namespace TGL_Practice_2.Workers;

internal abstract class Worker : Person, IWorker
{
    protected Random random;
    private static uint id = 0;
    public int Salary { get; protected set; }
    public int SufferingAmount { get; protected set; }
    public int SkillsAmount { get; protected set; }

    public uint ID { get; }

    protected Action<Worker> _promotionAction;
    protected Action<Worker> _dismissingAction;

    protected event Action<Worker> _askForDismiss;
    protected event Action<Worker> _askForPromotion;

    public Worker(string name, DateOnly birthDate, int salary,
        Action<Worker> promotionAction, Action<Worker> dismissAction)
        : base(name, birthDate)
    {
        Salary = salary;
        SufferingAmount = 0;
        SkillsAmount = 0;
        _promotionAction = promotionAction;
        _dismissingAction = dismissAction;
        _askForPromotion = _promotionAction;
        _askForDismiss = _dismissingAction;
        random = new Random();
        ID = id++;
    }

    private Worker(string name, DateOnly birthDate, int salary,
        Action<Worker> promotionAction, Action<Worker> dismissAction, uint otherID) 
        : this(name, birthDate,salary, promotionAction, dismissAction)
    {
        ID = id;
    }

    public abstract int GetUsability();

    public virtual void Suffer()
    {
        if (SufferingAmount >= 100) _askForDismiss.Invoke(this);
    }

    public virtual void OnProjectFinished()
    {
        SufferingAmount -= Salary / 100;
        if (SkillsAmount == 5) _askForPromotion.Invoke(this);
        else SkillsAmount++;
    }

    public abstract IWorker Copy();
}