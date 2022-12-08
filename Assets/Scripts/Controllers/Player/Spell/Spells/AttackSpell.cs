public class AttackSpell : ISpell {
    private const int damage = 3;

    public void Initialize(UIUnitSpellBase uiSpell) {
        var context = new UnitSpellContext {
            Name = "АТК",
        };

        uiSpell.Initialize(context);
    }

    public bool Use(UnitBaseBehaviour owner, UnitBaseBehaviour target) {
        if (owner.PlayerTeam == target.PlayerTeam) {
            return false;
        }

        target.Health.Damage(damage);

        return true;
    }
}
