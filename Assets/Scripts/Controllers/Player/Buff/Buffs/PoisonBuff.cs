public class PoisonBuff : IBuff {
    private const int countSteps = 1;
    private UnitBaseBehaviour unit;
    private UIUnitPoisonBuff view;
    private readonly IContext context;

    public int Steps { get; private set; }
    public PoisonBuff(IContext context) {
        this.context = context;
    }

    public void SetUnit(UnitBaseBehaviour unit) {
        this.unit = unit;
    }

    public void Setup(IStatsController stats) {
        view = context.FactoryService.Get<UIFactory>().Create<UIUnitPoisonBuff>(stats.BuffRoot);
        ReBuff();
        unit.Health.Damage(1);
    }

    public void Step() {
        unit.Health.Damage(1);
        Steps--;
    }

    public void Clear() {
        UnityEngine.GameObject.Destroy(view.gameObject);
    }

    public void ReBuff() {
        Steps = countSteps;
    }
}
