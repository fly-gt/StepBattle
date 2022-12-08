public interface ISpell {
    void Initialize(UIUnitSpellBase uiSpell);
    bool Use(UnitBaseBehaviour owner, UnitBaseBehaviour target);
}
