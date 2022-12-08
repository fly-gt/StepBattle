using UnityEngine;

public class ClearUnit {
    private readonly ISpellController spell;
    private readonly IStatsController stats;
    private readonly UnitBaseBehaviour owner;

    public ClearUnit(ISpellController spell, IStatsController stats, UnitBaseBehaviour owner) {
        this.spell = spell;
        this.stats = stats;
        this.owner = owner;
    }

    public void Clear() {
        spell.Clear();
        stats.Clear();

        GameObject.Destroy(owner.gameObject);
    }
}
