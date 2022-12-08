public class HealSpell : ISpell {
    private const int healthHeal = 1;
    public void Initialize(UIUnitSpellBase uiSpell) {
        var context = new UnitSpellContext {
            Name = "ЛЧН",
        };

        uiSpell.Initialize(context);
    }

    public bool Use(UnitBaseBehaviour owner, UnitBaseBehaviour target) {
        if (owner.PlayerTeam != target.PlayerTeam) {
            return false;
        }

        target.Health.Refill(healthHeal);
        target.Buff.Remove<PoisonBuff>();

        return true;
    }
}
