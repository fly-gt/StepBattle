public class PlayerController : UnitBaseBehaviour {
    private SpellRandom spellRandom;

    public override void Initialize() {
        base.Initialize();

        spellRandom = new SpellRandom(Context, spell);
        spell.SetSpell(spellRandom.GetSpell());
    }

    public override void BattleStep() {
        base.BattleStep();
        spell.SetSpell(spellRandom.GetSpell());
    }

    public override void Turn(bool turn) {
        spell.SetActive(turn);
    }
}
