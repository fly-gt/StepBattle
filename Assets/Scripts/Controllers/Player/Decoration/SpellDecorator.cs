public class SpellDecorator {
    private readonly ISpellController spell;
    public SpellDecorator(ISpellController spell) {
        this.spell = spell;
    }

    public void SetSelect(bool select) {
        spell.SetActive(select);
    }
}