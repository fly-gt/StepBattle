public class ProtectionSpell : ISpell {
    public void Initialize(UIUnitSpellBase uiSpell) {
        var context = new UnitSpellContext {
            Name = "ЗЩТ",
        };

        uiSpell.Initialize(context);
    }

    public bool Use(UnitBaseBehaviour owner, UnitBaseBehaviour target) {
        if (owner.PlayerTeam != target.PlayerTeam) {
            return false;
        }

        ProtectionBuff buff = new();
        target.Buff.SetBuff(buff);

        return true;
    }
}