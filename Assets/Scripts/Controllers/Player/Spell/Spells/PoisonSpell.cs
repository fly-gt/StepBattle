public class PoisonSpell : ISpell {
    private readonly IContext context;
    public PoisonSpell(IContext context) {
        this.context = context;
    }

    public void Initialize(UIUnitSpellBase uiSpell) {
        var uiContext = new UnitSpellContext {
            Name = "ОТРВ",
        };

        uiSpell.Initialize(uiContext);
    }

    public bool Use(UnitBaseBehaviour owner, UnitBaseBehaviour target) {
        if (owner.PlayerTeam == target.PlayerTeam) {
            return false;
        }

        PoisonBuff buff = new(context);
        buff.SetUnit(target);
        target.Buff.SetBuff(buff);

        return true;
    }
}
