using UnityEngine;

public class HealSpell : ISpell {
    private const int healthHeal = 1;
    private const float healDistance = 4f;
    public void Initialize(UIUnitSpellBase uiSpell) {
        var context = new UnitSpellContext {
            Name = "ЛЧН",
        };

        uiSpell.Initialize(context);
    }

    public bool Use(UnitBaseBehaviour owner, UnitBaseBehaviour target) {
        var distanceRich = Vector3.Distance(owner.transform.position, target.transform.position) <= healDistance;

        if (owner.PlayerTeam != target.PlayerTeam || !distanceRich) {
            return false;
        }

        target.Health.Refill(healthHeal);
        target.Buff.Remove<PoisonBuff>();

        return true;
    }
}
